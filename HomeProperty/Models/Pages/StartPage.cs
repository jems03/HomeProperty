using EPiServer.SpecializedProperties;
using EPiServer.Web;
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
           GroupName = Globals.GroupNames.Layout,
           Order = 2)]
        [Required]
        public virtual LinkItemCollection? Navigation { get; set; }
    }
}
