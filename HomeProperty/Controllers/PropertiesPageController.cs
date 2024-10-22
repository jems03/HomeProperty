using EPiServer.Web.Mvc;
using HomeProperty.Models.Pages;
using HomeProperty.Models.ViewModels;
using HomeProperty.Services.PropertiesList;
using Microsoft.AspNetCore.Mvc;

namespace HomeProperty.Controllers
{
    public class PropertiesPageController : PageController<PropertiesPage>
    {
        private readonly IContentLoader _contentLoader;
        private readonly IPropertiesListingService _propertiesListingService;

        public PropertiesPageController(IContentLoader contentLoader, IPropertiesListingService propertiesListingService)
        {
            _contentLoader = contentLoader;
            _propertiesListingService = propertiesListingService;
        }

        public IActionResult Index(PropertiesPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);

            var propertiesList = new ContentReference(currentPage.ContentLink.ID);

            currentPage.PropertiesDetailPages = _propertiesListingService.GetAllPropertiesList(propertiesList);

            return View(model);
        }
    }
}
