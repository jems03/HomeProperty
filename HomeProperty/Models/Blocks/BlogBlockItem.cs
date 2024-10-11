using EPiServer.Data.Dynamic;
using EPiServer.Web;
using HomeProperty.Business.DataStore;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Latest News Block Item", 
        GUID = "6a44baba-3e6d-4677-9a3f-7281b707ae26", 
        Description = "")]
    public class BlogBlockItem : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Blog Image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? BlogImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Blog Date",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual DateTime? BlogDate { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Blog Title",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual string? BlogTitle { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Blog Description",
           GroupName = SystemTabNames.Content,
           Order = 4)]
        public virtual string? BlogDescription { get; set; }

        
    }   
}