using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Pages
{
    [ContentType(DisplayName = "Properties Page", 
        GUID = "4909fa2b-c914-4bc8-922b-8afba9d74a5c")]
    [AvailableContentTypes(Include = new[] { typeof(PropertiesDetailPage), typeof(PropertiesSideBarPage) })]

    public class PropertiesPage : SitePageData
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
           Name = "Properties Side Bar",
           GroupName = SystemTabNames.Content,
           Order = 2)]
        [AllowedTypes(typeof(PropertiesSideBarPage))]
        public virtual ContentArea? PropertiesSideBar { get; set; }

        [Ignore]
        public IList<PropertiesDetailPage> PropertiesDetailPages { get; set; }
    }
}
