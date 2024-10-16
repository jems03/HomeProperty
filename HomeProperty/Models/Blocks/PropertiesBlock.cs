using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Latest Properties Block", 
        GUID = "6a90c84f-4019-46e7-a73c-94ad7b18ae82", 
        Description = "")]
    public class PropertiesBlock : BlockData
    {
        [CultureSpecific]
        [Display(
             Name = "Latest Properties Block",
             Description = "Provided properties that will be displayed",
             GroupName = SystemTabNames.Content,
             Order = 1)]
        public virtual IList<PropertiesBlockItem>? LatestPropertiesItems { get; set; }
    }
}