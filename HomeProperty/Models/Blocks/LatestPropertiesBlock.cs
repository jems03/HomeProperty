using HomeProperty.Models.Pages;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Latest Properties Block", 
        GUID = "327fdb60-c28d-4442-af46-fabbbfde45c2")]
    public class LatestPropertiesBlock : BlockData
    {
        [Display(
            Name = "Properties Page",
            Description = "Select the properties page to fetch properties from",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [AllowedTypes(typeof(PropertiesPage))]
        public virtual ContentReference PropertiesPage { get; set; }
    }
}