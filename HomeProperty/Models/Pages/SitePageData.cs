using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Site Page Data", 
        GUID = "9e1e1e5c-848c-498d-86d5-59d000c96445")]
    public abstract class SitePageData : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "SEO",
            Description = "This will be used for SEO Optimization",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string? MetaTitle { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Exclude from Sitemap",
           Description = "Exclude the Specific Page on Site Map",
           GroupName = Globals.GroupNames.Properties,
           Order = 2)]
        public virtual bool ExcludeFromSiteMap { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Sections",
           Description = "Add website sections",
           GroupName = SystemTabNames.Content,
           Order = 999)]       
        public virtual ContentArea? Sections { get; set; }
    }
}
