using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Our Agents Block Item", 
        GUID = "066ad26e-5b50-4329-ae20-23511cfd3926", 
        Description = "")]
    public class OurAgentsBlockItem : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Agent Image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? AgentImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Agent Name",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual string? AgentName { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Agent Position",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual string? AgentPosition { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Agent Facebook Page",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual Url? AgentFacebookLink { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Agent Twitter Page",
           GroupName = SystemTabNames.Content,
           Order = 5)]
        public virtual Url? AgentTwitterLink { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Agent LinkedIn Page",
           GroupName = SystemTabNames.Content,
           Order = 6)]
        public virtual Url? AgentLinkedInLink { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Agent Google + Page",
           GroupName = SystemTabNames.Content,
           Order = 7)]
        public virtual Url? AgentGooglePlusLink { get; set; }
    }
}