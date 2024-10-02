using EPiServer.SpecializedProperties;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Header Menu Block Item", 
        GUID = "d413f26f-4122-4975-92a1-035bd2c7aaff",
        Description = "Header Menu Items")]
    public class HeaderMenuBlockItem : BlockData
    {
        [Display(
            Name = "Main Menu Item",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual LinkItem? NavigationItem { get; set; }

        [Display(
            Name = "Submenu Item",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual LinkItemCollection? SubMenuItems { get; set; }
    }
}