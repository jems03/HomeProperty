using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using HomeProperty.SelectionFactories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Properties Detail Page", 
        GUID = "57241ce0-87a7-4761-8e06-b986ba763c58")]
    public class PropertiesDetailPage : SitePageData
    {      
        [CultureSpecific]
        [Display(
             Name = "Property Type",
             GroupName = SystemTabNames.Content,
             Order = 1)]
        [SelectOne(SelectionFactoryType = typeof(PropertyTypeSelection))]
        public virtual string PropertyType { get; set; }

        [CultureSpecific]
        [Display(
             Name = "Property Status",
             GroupName = SystemTabNames.Content,
             Order = 2)]
        [SelectOne(SelectionFactoryType = typeof(PropertyStatusSelection))]
        public virtual string PropertyStatus { get; set; }

        [CultureSpecific]
        [Display(
             Name = "Property Image",
             GroupName = SystemTabNames.Content,
             Order = 3)]
        [UIHint(UIHint.Image)]
        public virtual IList<Url> PropertyImages { get; set; }

        [CultureSpecific]
        [Display(
        Name = "Property Name",  // Updated Name for this page
        Description = "Originally a MetaTitle but accustomed for Properties Detail",
        GroupName = SystemTabNames.Content,
        Order = 4)]
        public override string? MetaTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Property Price",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public virtual string PropertyPrice { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Property Description",
            GroupName = SystemTabNames.Content,
            Order = 6)]
        public virtual XhtmlString PropertyDescription { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Number of Rooms",
            GroupName = SystemTabNames.Content,
            Order = 7)]
        public virtual int PropertyNumberOfRooms { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Number of Beds",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        public virtual int PropertyNumberOfBeds { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Number of Baths",
            GroupName = SystemTabNames.Content,
            Order = 9)]
        public virtual int PropertyNumberOfBaths { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Property Features List",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [SelectMany(SelectionFactoryType = typeof(PropertyFeaturesSelection))]
        [UIHint("StringsCollection")]
        public virtual string PropertyFeaturesList { get; set; }

        [Display(
            Name = "Property Video",
            GroupName = SystemTabNames.Content,
            Order = 11)]
        [UIHint(UIHint.Textarea)]
        public virtual string PropertyVideo { get; set; }

        [Display(
            Name = "Property Map Coordinates",
            GroupName = SystemTabNames.Content,
            Order = 12)]
        [UIHint(UIHint.Textarea)]
        public virtual string PropertyMapCoordinates { get; set; }


    }
}
