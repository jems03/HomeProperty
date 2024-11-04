using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Gallery Block", 
        GUID = "face3e61-71ae-4483-8320-c8b771ed4957")]
    public class GalleryBlock : BlockData
    {
        [CultureSpecific]
        [Display(
             Name = "Section Title",
             GroupName = SystemTabNames.Content,
             Order = 1)]
        public virtual string? SectionTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Section Descripton",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        [UIHint(Globals.UIHintDescriptors.TinyMCE)]
        public virtual XhtmlString? SectionDescription { get; set; }
    }
}