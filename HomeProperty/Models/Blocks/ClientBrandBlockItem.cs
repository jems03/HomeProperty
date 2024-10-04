using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Client Brand Block Item", 
        GUID = "530f5b7e-4291-4ec5-92d5-2422c13f0e51", 
        Description = "")]
    public class ClientBrandBlockItem : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Client Brand Image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? ClientImage { get; set; }

    }
}