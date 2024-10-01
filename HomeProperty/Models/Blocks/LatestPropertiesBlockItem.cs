﻿using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Latest Properties Block Item", 
        GUID = "63352182-260a-4d18-b60f-51584dbd38c7", 
        Description = "Provide the latest properties' details")]
    public class LatestPropertiesBlockItem : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Property Image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? LatestPropertyImage { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Property Status",
           GroupName = SystemTabNames.Content,
           Order = 2)]
        [SelectOne(SelectionFactoryType = typeof(PropertyStatusSelectionFactory))]
        public virtual string? LatestPropertyStatus { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Number of rooms",          
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual int LatestPropertyRoom { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Number of beds",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual int LatestPropertyBed { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Number of bathrooms",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual int LatestPropertyBath { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Property Size",
            GroupName = SystemTabNames.Content,
            Order = 6)]
        public virtual int LatestPropertySize { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Property Name",
            GroupName = SystemTabNames.Content,
            Order = 7)]
        public virtual string? LatestPropertyName { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Property Description",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        public virtual XhtmlString? LatestPropertyDescription { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Property Price",
            GroupName = SystemTabNames.Content,
            Order = 9)]
        public virtual string? LatestPropertyPrice { get; set; }

    }

    public class PropertyStatusSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new List<ISelectItem>
            {
                new SelectItem { Text = "For Sale", Value = "for-sale" },
                new SelectItem { Text = "For Rent", Value = "for-rent" },
                new SelectItem { Text = "Sold Out", Value = "sold-out" }
            };
        }
    }
}