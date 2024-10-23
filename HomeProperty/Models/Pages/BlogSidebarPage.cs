using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Blog Sidebar Page", 
        GUID = "8a971507-30eb-4f56-a3ab-8f2bed580809")]
    public class BlogSidebarPage : PageData
    {
        [Display(
            Name = "Blog Archive Page",
            Description = "Select the blog archive page to fetch blog posts from",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [AllowedTypes(typeof(BlogArchivePage))]
        public virtual ContentReference BlogArchivePage { get; set; }
    }
}
