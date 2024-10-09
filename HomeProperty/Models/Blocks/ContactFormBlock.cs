using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Implementation.Elements;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Contact Form Block", 
        GUID = "5086c6f1-ad03-4136-bfd6-d6eb787c0368", 
        Description = "")]
    public class ContactFormBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Contact Form Reference",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [AllowedTypes(typeof(FormContainerBlock))]
        public virtual ContentReference ContactFormReference { get; set; }

    }
}