using HomeProperty.Models.CustomModels;
using HomeProperty.Models.Pages;

namespace HomeProperty.Services.PropertiesList
{
    public interface IPropertiesListingService
    {
        IList<PropertiesDetailPage> GetAllPropertiesList(ContentReference propertiesList);

        IList<PropertiesDetailPage> GetLatestPropertiesList(ContentReference propertiesList);
    }
}
