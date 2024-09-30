using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Latest Properties Block", 
        GUID = "6a90c84f-4019-46e7-a73c-94ad7b18ae82", 
        Description = "")]
    public class LatestPropertiesBlock : BlockData
    {
        [CultureSpecific]
        [Display(
             Name = "Prperties Carousel Block",
             Description = "Provide properties that will be displayed",
             GroupName = SystemTabNames.Content,
             Order = 1)]
        [AllowedTypes(typeof(LatestPropertiesBlockItem))]
        public virtual ContentArea? LatestPropertiesItems { get; set; }
    }
}