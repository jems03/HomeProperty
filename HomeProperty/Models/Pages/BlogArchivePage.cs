using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using HomeProperty.Models.Blocks;
using HomeProperty.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Blog Archive Page", 
        GUID = "cabee22b-de67-44a2-a3f6-1cd9a7adbd61", 
        Description = "")]
    public class BlogArchivePage : SitePageData
    {
        // Inject the blog service using the injected pattern
        //private readonly Injected<IBlogService> _blogService;

        [CultureSpecific]
        [Display(
            Name = "Section Image Url",
            Description = "Select section image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? MainSectionImageUrl { get; set; }

        //public void FetchBlogDetails()
        //{
        //    if (BlogListingPages != null)
        //    {
        //        // Call the service to fetch blog details
        //        _blogService.Service.FetchBlogDetails(BlogListingPages);
        //    }
        //}

    }
}
