using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Blog Page", 
        GUID = "e373312a-7bef-40db-9157-85b47a8d3a10"
        )]
    public class BlogPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Section Image Url",
            Description = "Select section image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? MainSectionImageUrl { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Right Side",
           Description = "Add right side sections",
           GroupName = SystemTabNames.Content,
           Order = 3)]
        public virtual ContentArea? SideBarSections { get; set; }
    }
}
