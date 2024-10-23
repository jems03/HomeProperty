using HomeProperty.Models.Pages;

namespace HomeProperty.Services.PropertiesListing
{
    public interface IPropertiesListingService
    {
        IList<PropertiesDetailPage> GetAllPropertiesList(ContentReference propertiesList);

        IList<PropertiesDetailPage> GetLatestPropertiesList(ContentReference propertiesList);
    }
}
