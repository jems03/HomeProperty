using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Properties Carousel Block", 
        GUID = "9ff7bbba-8082-4b0b-bffa-636f3151fb63", 
        Description = "")]
    public class PropertiesCarouselBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Proerties Carousel Block",
            Description = "Provide properties that will be displayed",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual IList<PropertiesCarouselBlockItem> PropertyItems { get; set; }

    }
}