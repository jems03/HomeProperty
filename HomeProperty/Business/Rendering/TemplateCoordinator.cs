using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using HomeProperty.Controllers;
using HomeProperty.Models.Pages;

namespace HomeProperty.Business.Rendering
{
    [ServiceConfiguration(typeof(IViewTemplateModelRegistrator))]
    public class TemplateCoordinator : IViewTemplateModelRegistrator
    {
        public const string BlockFolder = "~/Views/Shared/Blocks/";
        public const string PagePartialsFolder = "~/Views/Shared/PagePartials/";

        public static void OnTemplateResolved(object sender, TemplateResolverEventArgs args)
        {
            // Disable DefaultPageController for page types that shouldn't have any renderer as pages
            if (args.ItemToRender is IContainerPage &&
                args.SelectedTemplate != null &&
                args.SelectedTemplate.TemplateType == typeof(DefaultPageController))
            {
                args.SelectedTemplate = null;
            }
        }

        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(SitePageData), new TemplateModel
            {
                Name = "Page",
                Inherit = true,
                AvailableWithoutTag = true,
                Path = PagePartialPath("Page.cshtml")
            });
        }

        private static string BlockPath(string fileName) => $"{BlockFolder}{fileName}";
        private static string PagePartialPath(string fileName) => $"{PagePartialsFolder}{fileName}";
    }
}
