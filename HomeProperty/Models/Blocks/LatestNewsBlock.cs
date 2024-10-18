using HomeProperty.Models.Pages;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Latest News Block", 
        GUID = "c857dbe6-f597-4009-9803-f256deed8662"
        )]
    public class LatestNewsBlock : BlockData
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