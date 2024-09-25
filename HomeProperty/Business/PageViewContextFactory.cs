using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Routing;
using HomeProperty.Models.Pages;
using HomeProperty.Models.ViewModels;

namespace HomeProperty.Business
{
    [ServiceConfiguration]
    public class PageViewContextFactory
    {
        private readonly IContentLoader _contentLoader;

        public PageViewContextFactory(
            IContentLoader contentLoader,
            UrlResolver urlResolver)
        {
            _contentLoader = contentLoader;
        }

        public virtual LayoutModel CreateLayoutModel(ContentReference currentContentLink, HttpContext httpContext)
        {
            var startPageContentLink = SiteDefinition.Current.StartPage;

            // Use the content link with version information when editing the startpage,
            // otherwise the published version will be used when rendering the props below.
            if (currentContentLink.CompareToIgnoreWorkID(startPageContentLink))
            {
                startPageContentLink = currentContentLink;
            }

            var startPage = _contentLoader.Get<StartPage>(startPageContentLink);
            var childPages = _contentLoader.GetChildren<SitePageData>(startPage.ContentLink);

            return new LayoutModel
            {
                LogoUrl = startPage.LogoUrl,
                MenuItems = childPages.ToList(),
            };
        }
    }
}
