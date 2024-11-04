using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Routing;
using HomeProperty.Business.DataStore.Properties;
using HomeProperty.Models.Pages;
using HomeProperty.Models.ViewModels;

namespace HomeProperty.Business
{
    [ServiceConfiguration]
    public class PageViewContextFactory
    {
        private readonly IContentLoader _contentLoader;
        private readonly IPropertyPageVisitRepository _propertyPageVisitRepository;

        public PageViewContextFactory(IContentLoader contentLoader, IPropertyPageVisitRepository propertyPageVisitRepository)
        {
            _contentLoader = contentLoader;
            _propertyPageVisitRepository = propertyPageVisitRepository;
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
            //var childPages = _contentLoader.GetChildren<SitePageData>(startPage.ContentLink);

            // Save to Dynamic Data Store when Property Detail page has been visited
            var currentPage = _contentLoader.Get<IContent>(currentContentLink);
            if (currentPage is PropertiesDetailPage) {
                _propertyPageVisitRepository.LogPropertyPageVisit(currentPage.ContentLink);
            }


            return new LayoutModel
            {
                LogoUrl = startPage.LogoUrl,
                LogoLink = startPage.LogoLink,
                ContactEmail = startPage.ContactEmail,
                ContactNumber = startPage.ContactNumber,
                //MenuItems = startPage.HeaderNavigation,
                Navigation = startPage.Navigation,
                FooterSection = startPage.FooterSection,
                FooterNavigation = startPage.FooterNavigation,
            };
        }
    }
}
