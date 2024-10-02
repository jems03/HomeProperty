using EPiServer.SpecializedProperties;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Footer Section Block", 
        GUID = "64898a7f-26c7-465e-991e-5cc1ff2ddfae", 
        Description = "Provide the footer details")]
    public class FooterSectionBlockItem : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Footer Title",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string? FooterTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Footer Link",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual Url? FooterLink { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Agent Facebook Page",
           GroupName = SystemTabNames.Content,
           Order = 3)]
        public virtual Url? FacebookLink { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Agent Twitter Page",
           GroupName = SystemTabNames.Content,
           Order = 4)]
        public virtual Url? TwitterLink { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Agent LinkedIn Page",
           GroupName = SystemTabNames.Content,
           Order = 5)]
        public virtual Url? GooglePlusLink { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Agent Google + Page",
           GroupName = SystemTabNames.Content,
           Order = 6)]
        public virtual Url? YoutubeLink { get; set; }      
    }
}