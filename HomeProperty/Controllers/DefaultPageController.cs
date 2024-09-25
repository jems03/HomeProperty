using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using HomeProperty.Models.Pages;
using Microsoft.AspNetCore.Mvc;

namespace HomeProperty.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class DefaultPageController : PageController<SitePageData>
    {
        public ViewResult Index(SitePageData currentPage)
        {
            var model = currentPage;// CreateModel(currentPage);
            return View($"~/Views/{currentPage.GetOriginalType().Name}/Index.cshtml", model);
        }
    }
}
