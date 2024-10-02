using EPiServer.SpecializedProperties;
using HomeProperty.Models.Blocks;

namespace HomeProperty.Models.ViewModels
{
    public class LayoutModel
    {
        public Url? LogoUrl { get; set; }
        public LinkItem? LogoLink { get; set; }
        public string? ContactNumber { get; set; }
        public string? ContactEmail { get; set; }

        //public IList<SitePageData> MenuItems { get; set; }
        public LinkItemCollection? MenuItems { get; set; }

        public FooterSectionBlockItem? FooterSection {  get; set; }

        public LinkItemCollection? FooterNavigation { get; set; }
    }
}
