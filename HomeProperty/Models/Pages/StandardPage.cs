using EPiServer.Web;
using HomeProperty.Models.Blocks;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Standard Page", 
        GUID = "a65063f9-d042-428e-8afe-b235a6d92ff4",
        Description = "")]
    [AvailableContentTypes(Exclude = new[] { typeof(StartPage), 
        typeof(LatestPropertiesBlockItem),
        typeof(OurAgentsBlockItem),
        typeof(PropertiesCarouselBlockItem)})]
    public class StandardPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Section Image Url",
            Description = "Select section image",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [UIHint(UIHint.Image)]
       

        public virtual Url? MainSectionImageUrl { get; set; }
    }
}
