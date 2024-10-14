using EPiServer.Web;
using HomeProperty.Models.Blocks;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Standard Page", 
        GUID = "a65063f9-d042-428e-8afe-b235a6d92ff4",
        Description = "")]
    [AvailableContentTypes(Exclude = new[] { typeof(StartPage),
        typeof(PropertiesBlockItem),
        typeof(OurAgentsBlockItem),
        typeof(PropertiesCarouselBlockItem),      
        typeof(ClientBrandBlockItem),
        typeof(ClientTestimonialBlockItem),
        typeof(FooterSectionBlockItem),
        typeof(HeaderMenuBlockItem),
        })]

    public class StandardPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Section Image Url",
            Description = "Select section image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? MainSectionImageUrl { get; set; }
    }
}
