using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Contact Map And Details Block", 
        GUID = "9c5b7899-321b-4e92-94ec-f5aaed68fd58", 
        Description = "")]
    public class ContactMapAndDetailsBlock : BlockData
    {
        [Display(
            Name = "Google Map Embed Link",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Textarea)]
        public virtual string? MapCoordinates { get; set; }

        [Display(
            Name = "Contact Description",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        [UIHint(Globals.UIHintDescriptors.TinyMCE)]
        public virtual XhtmlString? ContactDescription { get; set; }

        [Display(
            Name = "Contact Number",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual string? ContactNumber { get; set; }

        [Display(
            Name = "Contact Email",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual string? ContactEmail { get; set; }

        [Display(
            Name = "Contact Address",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual string? ContactAddress { get; set; }
    }
}