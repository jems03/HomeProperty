using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Client Testimonial Block Item", 
        GUID = "64bf9fef-0edf-4363-a49e-ff25d7edb421", 
        Description = "")]
    public class ClientTestimonialBlockItem : BlockData
    {
        [CultureSpecific]
        [Display(
             Name = "Client Image",
             GroupName = SystemTabNames.Content,
             Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? ClientImage { get; set; }

        [CultureSpecific]
        [Display(
          Name = "Client Name",
          GroupName = SystemTabNames.Content,
          Order = 2)]
        public virtual string? ClientName { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Client Description",
           GroupName = SystemTabNames.Content,
           Order = 3)]
        [UIHint(Globals.UIHintDescriptors.TinyMCE)]
        public virtual XhtmlString? ClientDescription { get; set; }

       
        [CultureSpecific]
        [Display(
         Name = "Client Job Position",
         GroupName = SystemTabNames.Content,
         Order = 4)]
        public virtual string? ClientJobPosition { get; set; }
    }
}