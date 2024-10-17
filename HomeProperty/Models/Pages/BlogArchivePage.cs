using EPiServer.Web;
using HomeProperty.Models.CustomModels;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Blog Archive Page", 
        GUID = "cabee22b-de67-44a2-a3f6-1cd9a7adbd61")]
    public class BlogArchivePage : SitePageData
    {
       
        [CultureSpecific]
        [Display(
            Name = "Section Image Url",
            Description = "Select section image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? MainSectionImageUrl { get; set; }

        //[Display(
        //    Name = "Blog Pages",
        //    GroupName = SystemTabNames.Content,
        //    Order = 2)]
        //[AllowedTypes(typeof(BlogSinglePage))]
        //public virtual IList<ContentReference>? BlogSinglePages { get; set; }

        [Ignore]
        public virtual IList<BlogPageWithComments>? BlogPageWithComments { get; set; }

    }
}
