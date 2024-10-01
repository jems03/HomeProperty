using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Promo Banner Block", 
        GUID = "66b7c7f3-7067-4b73-b2ee-40f8aebc842a", 
        Description = "")]
    public class PromoBannerBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Promo Banner Image",
            Description = "Select promo banner image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? PromoBannerImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Promo Banner Title",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual string? PromoBannerTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Promo Banner Description",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual XhtmlString? PromoBannerDescription { get; set; }
    }
}