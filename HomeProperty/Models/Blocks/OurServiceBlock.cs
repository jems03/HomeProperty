using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Our Service Block", 
        GUID = "2dcb72d7-d24e-44ce-9f24-87b1df9b3489", 
        Description = "")]
    public class OurServiceBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Our Service Block",
            Description = "Provided properties that will be displayed",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual IList<OurServiceBlockItem>? OurServiceItems { get; set; }
    }
}