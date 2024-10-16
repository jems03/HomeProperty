﻿using EPiServer.Web;
using HomeProperty.Business.DataStore.BlogSinglePage;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Blog Single Page", 
        GUID = "e373312a-7bef-40db-9157-85b47a8d3a10"
        )]
    public class BlogSinglePage : SitePageData
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
           Name = "Right Side Bar",
           Description = "Add right side sections",
           GroupName = SystemTabNames.Content,
           Order = 2)]
        public virtual ContentArea? SideBarSections { get; set; }
        
        [CultureSpecific]
        [Display(
            Name = "Blog Heading Image",
            Description = "Select blog heading image",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        [UIHint(UIHint.Image)]
        public virtual Url? BlogSingleImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Blog Date",
            Description = "Provide Blog Date",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual DateTime BlogSingleDate { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Blog Title",        
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual string? BlogSingleTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Blog Author",           
            GroupName = SystemTabNames.Content,
            Order = 6)]
        public virtual string? BlogSingleAuthor { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Blog Description",
            GroupName = SystemTabNames.Content,
            Order = 7)]
        [UIHint(Globals.UIHintDescriptors.TinyMCE)]
        public virtual XhtmlString? BlogSingleDescription { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Blog Quote",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        [UIHint(Globals.UIHintDescriptors.TinyMCE)]
        public virtual XhtmlString? BlogSingleQuote { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Blog Additional Remarks",
            Description = "Blog Additional Remarks",
            GroupName = SystemTabNames.Content,
            Order = 9)]
        [UIHint(Globals.UIHintDescriptors.TinyMCE)]
        public virtual XhtmlString? BlogSingleAdditionalRemarks { get; set; }


        [Ignore]
        public virtual IList<BlogComments>? BlogComments { get; set; }  

    }
}
