﻿using EPiServer.Web;
using HomeProperty.Models.CustomModels;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Blog Archive Page", 
        GUID = "cabee22b-de67-44a2-a3f6-1cd9a7adbd61")]
    public class BlogArchivePage : SitePageData
    {
       
        [CultureSpecific]
        [Display(
            Name = "Section Image Url",
            Description = "Select section image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? MainSectionImageUrl { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Blog Side Bar",
           GroupName = SystemTabNames.Content,
           Order = 2)]
        [AllowedTypes(typeof(BlogSidebarPage))]
        public virtual ContentArea? BlogSideBar { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Title",  // Updated Name for this page
           Description = "Originally a MetaTitle but accustomed for Blog Archive Page",
           GroupName = SystemTabNames.Content,
           Order = 3)]
        public override string? MetaTitle { get; set; }

        [Ignore]
        public virtual IList<BlogPageWithComments>? BlogPageWithComments { get; set; }

    }
}
