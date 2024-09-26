using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Contact Map And Details Block", 
        GUID = "9c5b7899-321b-4e92-94ec-f5aaed68fd58", 
        Description = "")]
    public class ContactMapAndDetailsBlock : BlockData
    {
        [Display(
            Name = "Contact Description",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual XhtmlString? ContactDescription { get; set; }

        [Display(
            Name = "Contact Number",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string? ContactNumber { get; set; }

        [Display(
            Name = "Contact Email",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual string? ContactEmail { get; set; }

        [Display(
            Name = "Contact Address",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string? ContactAddress { get; set; }
    }
}