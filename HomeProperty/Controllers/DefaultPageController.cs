using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using HomeProperty.Models.Pages;
using HomeProperty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeProperty.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class DefaultPageController : PageController<SitePageData>
    {
        public ViewResult Index(SitePageData currentPage)
        {
            var model = CreateModel(currentPage);
            return View($"~/Views/{currentPage.GetOriginalType().Name}/Index.cshtml", model);
        }

        private static IPageViewModel<SitePageData> CreateModel(SitePageData page)
        {
            var type = typeof(PageViewModel<>).MakeGenericType(page.GetOriginalType());
            return Activator.CreateInstance(type, page) as IPageViewModel<SitePageData>;
        }
    }
}
