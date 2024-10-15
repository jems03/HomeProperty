using HomeProperty.Models.Pages;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Blog Listing Block", 
        GUID = "59b30811-e23c-4d2a-b0b3-379257b43647", 
        Description = "")]
    public class BlogListingBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Blog Pages",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [AllowedTypes(typeof(BlogSinglePage))]
        public virtual ContentReference BlogSinglePages { get; set; }

    }
}