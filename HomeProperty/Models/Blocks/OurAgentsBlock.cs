using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Our Agents Block", 
        GUID = "b3af4711-1731-4a6b-bc64-3215b7442352", 
        Description = "")]
    public class OurAgentsBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Our Agents Carousel Block",
            Description = "Provide our agent's information that will be displayed",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [AllowedTypes(typeof(OurAgentsBlockItem))]
        public virtual ContentArea? OurAgentsPeople { get; set; }
    }
}