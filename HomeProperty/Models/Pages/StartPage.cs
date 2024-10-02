using EPiServer.SpecializedProperties;
using EPiServer.Web;
using HomeProperty.Models.Blocks;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(
        DisplayName = "Start Page",
        GUID = "bdebc7bd-3aac-4e0b-b06c-4b02b37dc191",
        Description = "")]

    [AvailableContentTypes(
        Exclude = [typeof(StartPage)])]
    public class StartPage : SitePageData
    {
        [CultureSpecific]
        [Display(
           Name = "Logo Url",
           Description = "Select website logo",
           GroupName = Globals.GroupNames.Layout,
           Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? LogoUrl { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Logo Link",
           GroupName = Globals.GroupNames.Layout,
           Order = 2)]
        public virtual LinkItem? LogoLink { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Contact Number",
           GroupName = Globals.GroupNames.Layout,
           Order = 3)]
        public virtual string? ContactNumber { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Contact Email",
           GroupName = Globals.GroupNames.Layout,
           Order = 4)]
        public virtual string? ContactEmail { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Header Navigation",
           GroupName = Globals.GroupNames.Layout,
           Order = 5)]
        public virtual LinkItemCollection? HeaderNavigation { get; set; }

       
        [Display(
          Name = "Footer Section",
          GroupName = Globals.GroupNames.Layout,
          Order = 6)]
        public virtual FooterSectionBlockItem? FooterSection { get; set; }

        [Display(
          Name = "Footer Navigation",
          GroupName = Globals.GroupNames.Layout,
          Order = 7)]
        public virtual LinkItemCollection? FooterNavigation { get; set; }
    }
}
