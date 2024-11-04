using EPiServer.DataAccess;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.Security;
using EPiServer.Web;
using EPiServer.Web.Routing;
using HomeProperty.Models.Media;
using HomeProperty.Models.Pages;
using Quartz;
using System.Text.RegularExpressions;
using Wangkanai.Extensions;


namespace HomeProperty.Business.Initialization.Jobs.PropertiesImport
{
    [ScheduledPlugIn(DisplayName = "Properties Detail Import Schedule Job",
        GUID = "4097c341-66bb-4b27-a200-0c74d3742e9c")]
    public class PropertiesDetailImportScheduleJob : ScheduledJobBase
    {
        private bool _stopSignaled;

        private string parentFolder = "Properties";

        private string csvFileName = "properties.csv";

        private readonly ILogger<PropertiesDetailImportScheduleJob> _logger;
        private readonly IContentRepository _contentRepository;
        private readonly IContentTypeRepository _contentTypeRepository;
        private readonly IContentLoader _contentLoader;
        private readonly IContentTypeRepository<PageType> _pageTypeRepository;
        private readonly IUrlResolver _urlResolver;
        private readonly IUrlSegmentCreator _urlSegmentCreator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISiteDefinitionRepository _siteDefinitionRepository;

        private readonly HttpClient client = new HttpClient();

        ContentReference parentLink = new ContentReference(158);

        public PropertiesDetailImportScheduleJob(
            ILogger<PropertiesDetailImportScheduleJob> logger,
            IContentRepository contentRepository,
            IContentTypeRepository contentTypeRepository,
            IContentLoader contentLoader,
            IContentTypeRepository<PageType> pageTypeRepository,
            IUrlResolver urlResolver,
            IUrlSegmentCreator urlSegmentCreator,
            IWebHostEnvironment webHostEnvironment,
            ISiteDefinitionRepository siteDefinitionRepository)
        {
            IsStoppable = true;

            _logger = logger;
            _contentRepository = contentRepository;
            _contentTypeRepository = contentTypeRepository;
            _contentLoader = contentLoader;
            _pageTypeRepository = pageTypeRepository;
            _urlResolver = urlResolver;
            _urlSegmentCreator = urlSegmentCreator;
            _webHostEnvironment = webHostEnvironment;
            _siteDefinitionRepository = siteDefinitionRepository;
        }

        int successfulPropertyImports = 0;

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            return ExecuteAsync().GetAwaiter().GetResult();
        }

        private async Task<string> ExecuteAsync()
        {
            

            try
            {
                //Call OnStatusChanged to periodically notify progress of job for manually started jobs
                OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));

                _logger.LogInformation("Importing Properties Detail CSV file");
                string errorMessage = string.Empty;

                errorMessage = await Task.Run(() => ImportPropertiesDetailsItems());

                //For long running jobs periodically check if stop is signaled and if so stop execution
                if (_stopSignaled)
                {
                    return "Stop of job was called";
                }

                if (errorMessage.IsNotNullOrEmpty())
                {
                    OnStatusChanged("Import Properties encountered an error");
                    throw new InvalidOperationException(errorMessage);
                }

                OnStatusChanged("Async execution completed");
                return $"{successfulPropertyImports} properties imported successfully.";
            }
            catch (Exception ex)
            {
                throw new JobExecutionException(ex.Message);
            }
        }

        private async Task<string> ImportPropertiesDetailsItems()
        {
            var propertiesDetailItems = new List<PropertiesDetailDTO>();
            var csvFilePath = await Task.Run(() => GetCsvFileFromCMS(csvFileName));

            try
            {
                // When CSV file has value
                if (csvFilePath != null)
                {
                    var fileUrl = _urlResolver.GetUrl(csvFilePath.ContentLink);
                    string baseUrl = GetBaseUrl();
                    string csvFile = NormalizeUrl($"{baseUrl}{fileUrl}");

                    using (var response = await client.GetAsync(csvFile))
                    {
                        response.EnsureSuccessStatusCode();

                        var stream = await response.Content.ReadAsStreamAsync();

                        using (var reader = new StreamReader(stream))
                        {
                            reader.ReadLine();

                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();

                                var values = line.Split(',');                             

                                var propertiesItem = new PropertiesDetailDTO
                                {
                                    PropertyType = values[0],
                                    PropertyStatus = values[1],
                                    PropertyImages = values[2],
                                    PropertyName = values[3],
                                    PropertyPrice = int.Parse(values[4]),
                                    PropertyDescription = values[5],
                                    PropertyNumberOfRooms = int.Parse(values[6]),
                                    PropertyNumberOfBeds = int.Parse(values[7]),
                                    PropertyNumberOfBaths = int.Parse(values[8]),
                                    PropertySize = int.Parse(values[9]),
                                    PropertyFeaturesList = values[10],
                                    PropertyVideo = values[11],
                                    PropertyMapCoordinates = values[12],

                                };

                                CreateOrUpdatePropertiesDetailPage(propertiesItem, baseUrl);
                                successfulPropertyImports++;
                            }
                        }
                    }

                    return string.Empty;

                }
                else
                {
                    string errorMessage = $"{csvFileName} was not found in CMS";

                    _logger.LogError(errorMessage);
                    return errorMessage;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new InvalidOperationException(ex.Message);
            }

        }

        private void CreateOrUpdatePropertiesDetailPage(PropertiesDetailDTO propertiesDTO, string baseUrl)
        {
            PageType propertiesDetailPageType = _pageTypeRepository.Load(typeof(PropertiesDetailPage).Name);
            PropertiesDetailPage propertiesDetailPage = _contentRepository.GetDefault<PropertiesDetailPage>(parentLink, propertiesDetailPageType.ID);

            PropertiesDetailPage? existingProperty = _contentRepository.GetChildren<PropertiesDetailPage>(parentLink)
                .Where(property => property.MetaTitle == propertiesDTO.PropertyName).FirstOrDefault();

            if (existingProperty != null)
            {
                propertiesDetailPage = (PropertiesDetailPage?)existingProperty.CreateWritableClone();              
            }

            propertiesDetailPage.PropertyType = propertiesDTO.PropertyType;
            propertiesDetailPage.PropertyStatus = propertiesDTO.PropertyStatus;
            propertiesDetailPage.PropertyImages = [];

            if (propertiesDTO.PropertyImages.Length > 0)
            {
                foreach (var image in propertiesDTO.PropertyImages.Split(";"))
                {
                    propertiesDetailPage.PropertyImages.Add($"{baseUrl}{image}");
                }
            }

            propertiesDetailPage.Name = propertiesDTO.PropertyName;
            propertiesDetailPage.MetaTitle = propertiesDTO.PropertyName;
            propertiesDetailPage.PropertyPrice = propertiesDTO.PropertyPrice;
            propertiesDetailPage.PropertyDescription = new XhtmlString($"<p>{propertiesDTO.PropertyDescription}</p>");
            propertiesDetailPage.PropertyNumberOfRooms = propertiesDTO.PropertyNumberOfRooms;
            propertiesDetailPage.PropertyNumberOfBeds = propertiesDTO.PropertyNumberOfBeds;
            propertiesDetailPage.PropertyNumberOfBaths = propertiesDTO.PropertyNumberOfBaths;
            propertiesDetailPage.PropertySize = propertiesDTO.PropertySize;
            propertiesDetailPage.PropertyFeaturesList = propertiesDTO.PropertyFeaturesList.Replace(" | ", ",");
            propertiesDetailPage.PropertyVideo = propertiesDTO.PropertyVideo;
            propertiesDetailPage.PropertyMapCoordinates = propertiesDTO.PropertyMapCoordinates;

            propertiesDetailPage.URLSegment = _urlSegmentCreator.Create(propertiesDetailPage);
            propertiesDetailPage.VisibleInMenu = false;

            SaveAction propertySaveAction = SaveAction.Publish;

            if (propertiesDetailPage != null)
            {
                propertySaveAction = SaveAction.Publish | SaveAction.ForceCurrentVersion;
            }

            var productReference = _contentRepository.Save(propertiesDetailPage, propertySaveAction, AccessLevel.NoAccess);
            _logger.LogWarning($"{propertiesDTO.PropertyName} imported with id {propertiesDetailPage.ContentLink.ID}");

        }

        #region Fetching CSV File
        public MediaData GetCsvFileFromCMS(string fileName)
        {
            string fileType = "application/csv";
            var contentReferences = _contentRepository.GetDescendents(SystemDefinition.Current.GlobalAssetsRoot);

            foreach (var contentReference in contentReferences)
            {
                var content = _contentRepository.Get<IContent>(contentReference);
                if (content is CsvFile csvFile && csvFile.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase))
                {
                    return csvFile;
                }
            }

            return null; // When csv file not found
        }
        #endregion Fetching CSV File

        public string GetBaseUrl()
        {
            var siteDefinition = _siteDefinitionRepository.List();
            return siteDefinition.FirstOrDefault()?.SiteUrl.ToString();
        }

        public string NormalizeUrl(string url)
        {
            // Create a Uri object to normalize the URL
            Uri uri = new Uri(url, UriKind.RelativeOrAbsolute);

            // Convert the Uri back to a string to get the normalized URL
            string normalizedUrl = uri.ToString();

            // Remove any double slashes (except for the protocol part)
            normalizedUrl = Regex.Replace(normalizedUrl, "(?<!:)/{2,}", "/");

            return normalizedUrl;
        }

    }

}

