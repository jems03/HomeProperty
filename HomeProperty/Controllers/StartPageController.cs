using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using HomeProperty.Models.Pages;
using HomeProperty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeProperty.Controllers
{
    [TemplateDescriptor(Inherited = true, Tags = new[] { "OnPageEdit" })]
    public class StartPageController : PageController<StartPage>
    {
        public IActionResult Index(StartPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);

            return View(model);
        }
    }
}
