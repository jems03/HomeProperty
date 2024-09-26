using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Error Content Block", 
        GUID = "30bc4f35-971a-44b0-bb38-ffc825c5915f", 
        Description = "")]
    public class ErrorContentBlock : BlockData
    {
        [Display(
           Name = "Error Title",
           GroupName = SystemTabNames.Content,
           Order = 10)]
        public virtual string? ErrorTitle { get; set; }

        [Display(
            Name = "Error Description",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString? ErrorDescrption { get; set; }
    }
}