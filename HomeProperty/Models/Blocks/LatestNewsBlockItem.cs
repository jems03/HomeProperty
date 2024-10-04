using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Latest News Block Item", 
        GUID = "6a44baba-3e6d-4677-9a3f-7281b707ae26", 
        Description = "")]
    public class LatestNewsBlockItem : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Latest News Image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? LatestNewsImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Latest News Date",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual DateTime? LatestNewsDate { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Latest News Title",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual string? LatestNewsTitle { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Latest News Description",
           GroupName = SystemTabNames.Content,
           Order = 4)]
        public virtual string? LatestNewsDescription { get; set; }
    }
}