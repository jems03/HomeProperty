using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "SectionTitleBlock", GUID = "cec799ef-01e8-462f-9b29-9aa9ad183346", Description = "")]
    public class SectionTitleBlock : BlockData
    {
        [Display(
            Name = "Section Title",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string? SectionTitle { get; set; }

        [Display(
            Name = "Section Description",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual XhtmlString? SectionDescription { get; set; }
    }
}