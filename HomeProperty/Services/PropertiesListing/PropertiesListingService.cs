using HomeProperty.Services.PropertiesList;
using HomeProperty.Models.CustomModels;
using HomeProperty.Models.Pages;

namespace HomeProperty.Services.PropertiesListing
{
    public class PropertiesListingService : IPropertiesListingService
    {
        private readonly IContentLoader _contentLoader;

        public PropertiesListingService(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
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

    }
}
