using EPiServer.Shell.ObjectEditing;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Our Service Block Item", 
        GUID = "bbd4a91e-2d5e-44b7-b529-f1734bb69e9c", 
        Description = "")]
    public class OurServiceBlockItem : BlockData
    {
        [CultureSpecific]
        [Display(
           Name = "Icon",
           GroupName = SystemTabNames.Content,
           Order = 1)]
        [SelectOne(SelectionFactoryType = typeof(OurServiceSelectionFactory))]
        public virtual string? OurServiceIcon { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Title",
           GroupName = SystemTabNames.Content,
           Order = 2)]
        public virtual string? OurServiceTitle { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Description",
           GroupName = SystemTabNames.Content,
           Order = 3)]
        public virtual string? OurServiceDescription { get; set; }
    }

    public class OurServiceSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new List<ISelectItem>
            {
                new SelectItem { Text = "Home", Value = "fa-home" },
                new SelectItem { Text = "Check", Value = "fa-check" },
                new SelectItem { Text = "Crosshair", Value = "fa-crosshairs" },
                new SelectItem { Text = "Chart", Value = "fa-bar-chart-o" }
            };
        }
    }
}