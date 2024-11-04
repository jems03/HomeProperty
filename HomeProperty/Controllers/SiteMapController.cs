using HomeProperty.Services.SiteMap;
using Microsoft.AspNetCore.Mvc;

namespace HomeProperty.Controllers
{
    public class SiteMapController : Controller
    {
        private readonly SiteMapService _siteMapService;

        public SiteMapController(SiteMapService siteMapService)
        {
            _siteMapService = siteMapService;
        }

        [HttpGet]
        [Route("sitemap.xml")]
        public IActionResult Sitemap()
        {
            //var sitemapService = new SitemapService(_contentLoader);
            var sitemapXml = _siteMapService.GenerateSiteMapXml(ContentReference.StartPage);
            return Content(sitemapXml, "application/xml");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
