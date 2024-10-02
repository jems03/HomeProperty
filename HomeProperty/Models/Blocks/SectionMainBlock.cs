using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Section Main Block", 
        GUID = "ac601b52-56f5-4b9f-81a5-dc30443c4414", 
        Description = "Section Title, Description and Section Content Placeholder")]
    public class SectionMainBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Section Title",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string? SectionTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Section Descripton",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual XhtmlString? SectionDescription { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Section Content Area",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual ContentArea? SectionContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Image Background",
            Description = "Select image background",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        [UIHint(UIHint.Image)]
        public virtual Url? MainSectionImageUrl { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Gray Background",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual bool GrayBackground { get; set; }

    }
}