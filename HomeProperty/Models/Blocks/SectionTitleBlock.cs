using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Section Title Block", 
        GUID = "cec799ef-01e8-462f-9b29-9aa9ad183346", 
        Description = "")]
    public class SectionTitleBlock : BlockData
    {
        [Display(
            Name = "Section Title",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string? SectionTitle { get; set; }

        [Display(
            Name = "Section Description",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString? SectionDescription { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual bool GrayBackground  { get; set; }
    }
}