using EPiServer.SpecializedProperties;
using HomeProperty.Models.Pages;

namespace HomeProperty.Models.ViewModels
{
    public class LayoutModel
    {
        public Url? LogoUrl { get; set; }

        //public IList<SitePageData> MenuItems { get; set; }
        public LinkItemCollection MenuItems { get; set; }
    }
}
