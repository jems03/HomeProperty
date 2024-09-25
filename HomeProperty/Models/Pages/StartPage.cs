using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Start Page", 
        GUID = "bdebc7bd-3aac-4e0b-b06c-4b02b37dc191", 
        Description = "")]
    public class StartPage : SitePageData
    {
        [CultureSpecific]
        [Display(
           Name = "Logo Url",
           Description = "Select website logo",
           GroupName = Globals.GroupNames.Layout,
           Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual Url LogoUrl { get; set; }
    }
}
