using HomeProperty.Business.DataStore.Properties;
using HomeProperty.Models.Pages;

namespace HomeProperty.Services.PropertiesListing
{
    public class PropertiesListingService : IPropertiesListingService
    {
        private readonly IContentLoader _contentLoader;
        private readonly IPropertyPageVisitRepository _propertyPageVisitRepository;

        public PropertiesListingService(IContentLoader contentLoader, IPropertyPageVisitRepository propertyPageVisitRepository)
        {
            _contentLoader = contentLoader;
            _propertyPageVisitRepository = propertyPageVisitRepository;
        }

        public IList<PropertiesDetailPage> GetAllPropertiesList(ContentReference propertiesList)
        {
            var getAllProperties = _contentLoader.GetChildren<PageData>(propertiesList)
                 .OfType<PropertiesDetailPage>()
                 .OrderByDescending(properties => properties.StartPublish)
                 .ToList();

            return getAllProperties;
        }

        public IList<PropertiesDetailPage> GetLatestPropertiesList(ContentReference propertiesList)
        {
            var getLatestProperties = _contentLoader.GetChildren<PageData>(propertiesList)
                 .OfType<PropertiesDetailPage>()
                 .OrderByDescending(properties => properties.StartPublish)
                 .Take(6)
                 .ToList();

            return getLatestProperties;
        }

        public IList<PropertiesDetailPage> GetPopularProperties(ContentReference propertiesList)
        {
            // Fetch all the visit count on 
            var propertyVisitorCount = _propertyPageVisitRepository.GetPopularPropertiesVisit();

            // Select properties and order by visit count
            var getAllPopularProperties = _contentLoader.GetChildren<PageData>(propertiesList)
                .OfType<PropertiesDetailPage>()
                .OrderByDescending(property =>
                    propertyVisitorCount.FirstOrDefault(prop => prop.PageId == property.ContentLink.ID)?.VisitCount ?? 0)
                .Take(3)
                .ToList();

            return getAllPopularProperties;

        }
    }
}
