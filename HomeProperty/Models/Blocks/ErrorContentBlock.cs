using EPiServer.SpecializedProperties;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Error Content Block", 
        GUID = "30bc4f35-971a-44b0-bb38-ffc825c5915f", 
        Description = "")]
    public class ErrorContentBlock : BlockData
    {
        [Display(
           Name = "Error Title",
           GroupName = SystemTabNames.Content,
           Order = 1)]
        public virtual string? ErrorTitle { get; set; }

        [Display(
            Name = "Error Description",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual XhtmlString? ErrorDescrption { get; set; }

        [Display(
            Name = "Redirection Page",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual LinkItem? RedirectionPage { get; set; }
    }
}