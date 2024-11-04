using EPiServer.Web;
using HomeProperty.Models.Pages;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Properties Carousel Block Item", 
        GUID = "24d20542-f8f6-425e-9237-56dbfab89c90", 
        Description = "Provide the properties' description and image")]
    public class PropertiesCarouselBlockItem : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Property Image",          
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url PropertyImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Category",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual string PropertyCategory { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Property Size",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual int PropertySize { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Property Address",
           GroupName = SystemTabNames.Content,
           Order = 4)]
        public virtual string PropertyAddress { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Property Discount",
           GroupName = SystemTabNames.Content,
           Order = 5)]
        public virtual int PropertyDiscount { get; set; }      

        [CultureSpecific]
        [Display(
           Name = "Property Price",
           GroupName = SystemTabNames.Content,
           Order = 6)]
        public virtual int PropertyPrice { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Property Details Page",
           GroupName = SystemTabNames.Content,
           Order = 7)]
        [AllowedTypes(typeof(PropertiesDetailPage))]
        public virtual ContentReference PropertiesDetailPage { get; set; }

    }
}