using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Properties SideBar Page", 
        GUID = "3588cca2-b41f-4059-b02c-8513e7999a46")]
    public class PropertiesSideBarPage : SitePageData
    {
        [Display(
             Name = "Properties Page",
             Description = "Select the properties page to fetch properties list",
             GroupName = SystemTabNames.Content,
             Order = 1)]
        [AllowedTypes(typeof(PropertiesPage))]
        public virtual ContentReference PropertiesPage { get; set; }
    }
}
