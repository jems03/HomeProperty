using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "About Us Block", 
        GUID = "1d6bd89d-57c4-45eb-b5b0-9b39d59b1030",
        Description = "")]
    public class AboutUsBlock : BlockData
    {
        [Display(
            Name = "About Title",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string? AboutUsTitle { get; set; }

        [Display(
            Name = "About Description",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        [UIHint("TinyMCEDescriptor")]
        public virtual XhtmlString? AboutUsDescription { get; set; }

        [Display(
           Name = "Additional Remarks",
           GroupName = SystemTabNames.Content,
           Order = 3)]
        //[UIHint("TinyMCEDescriptor")]
        public virtual XhtmlString? AboutUsAdditionalRemarks { get; set; }

        [CultureSpecific]
        [Display(
            Name = "About Image",
            Description = "Select about image",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        [UIHint(UIHint.Image)]

        public virtual Url? AboutImage { get; set; }
    }
}