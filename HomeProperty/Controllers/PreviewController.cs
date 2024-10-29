using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Framework.Web.Mvc;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using HomeProperty.Models.Pages;
using HomeProperty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeProperty.Controllers
{
    [TemplateDescriptor(
        Inherited = true,
        TemplateTypeCategory = TemplateTypeCategories.MvcController,
        Tags = [RenderingTags.Preview, RenderingTags.Edit],
        AvailableWithoutTag = false)]
    [VisitorGroupImpersonation]
    [RequireClientResources]
    public class PreviewController : ActionControllerBase, IRenderTemplate<BlockData>
    {
        private readonly IContentLoader _contentLoader;
        private readonly TemplateResolver _templateResolver;
        private readonly DisplayOptions _displayOptions;

        public PreviewController(IContentLoader contentLoader, TemplateResolver templateResolver, DisplayOptions displayOptions)
        {
            _contentLoader = contentLoader;
            _templateResolver = templateResolver;
            _displayOptions = displayOptions;
        }

        public IActionResult Index(IContent currentContent)
        {
            var startPage = _contentLoader.Get<StartPage>(SiteDefinition.Current.StartPage);

            var model = new PreviewModel(startPage, currentContent);

            var supportedDisplayOptions = _displayOptions
                .Select(display => new {display.Name, Supported = SupportsTag(currentContent, display.Tag) })
                .ToList();

            if (supportedDisplayOptions.Any(display => display.Supported))
            {
                var contentArea = new ContentArea();

                contentArea.Items.Add(new ContentAreaItem
                {
                    ContentLink = currentContent.ContentLink
                });

                var areaModel = new PreviewModel.PreviewArea
                {
                    Supported = true,
                    ContentArea = contentArea
                };
                model.Areas.Add(areaModel);
            }

            return View(model);
        }

        private bool SupportsTag(IContent content, string tag)
        {
            var templateModel = _templateResolver.Resolve(
                HttpContext,
                content.GetOriginalType(),
                content,
                TemplateTypeCategories.MvcPartial,
                tag);
            return templateModel != null;
        }
    }
}
