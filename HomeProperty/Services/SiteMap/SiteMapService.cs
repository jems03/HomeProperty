using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using EPiServer.Web;
using HomeProperty.Models.Pages;
using System.Xml.Linq;

namespace HomeProperty.Services.SiteMap
{
    public class SiteMapService
    {
        private readonly IContentLoader _contentLoader;

        public SiteMapService(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IEnumerable<SitePageData> GetAllPages(ContentReference startPage)
        {
            var _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

            var myStartPage = _contentRepository.Get<SitePageData>(startPage);

            var pages = _contentRepository.GetDescendents(myStartPage.ContentLink)
                .Select(reference => _contentRepository.Get<IContent>(reference))
                .OfType<SitePageData>()
                .Where(page => page.VisibleInMenu);

            return pages;
        }

        public string GenerateSiteMapXml(ContentReference startPage)
        {
            var pages = GetAllPages(startPage);

            var urlResolverArgument = new UrlResolverArguments { ContextMode = ContextMode.Default };
            XNamespace xn = "http://www.sitemaps.org/schemas/sitemap/0.9";
            var sitemap = new XDocument(
                new XElement("urlset",
                    new XElement(xn + "xmlns"),
                        pages.Select(page =>
                            new XElement("url",
                            new XElement("loc", GetUrlAbsoluteFromInsideEPiServer(page.ContentLink, page.Language.Name)),
                            new XElement("lastmod", page.Changed.ToString("yyyy-MM-dd")),
                            new XElement("changefreq", "weekly"),
                            new XElement("priority", "0.5")
                            )
                        )
                    )
                );
            return sitemap.ToString();
        }

        private static string GetUrlAbsoluteFromInsideEPiServer(ContentReference contentLink, string language, UrlResolver urlResolver = null)
        {
            if (urlResolver == null)
            {
                urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            }

            var url = urlResolver.GetUrl(contentLink: contentLink, language: language, virtualPathArguments: new VirtualPathArguments()
            {
                ContextMode = ContextMode.Default,
                ForceAbsolute = true
            });

            return url.ToString();
        }
    }
}
