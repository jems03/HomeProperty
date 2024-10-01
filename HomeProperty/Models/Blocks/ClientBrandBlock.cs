using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Client Brand Block", 
        GUID = "f824e570-daae-43ef-9522-55a893755648", 
        Description = "")]
    public class ClientBrandBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Client Brand Block",
            Description = "Provide client brand logos",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual IList<ClientBrandBlockItem>? ClientBrandsList { get; set; }
    }
}