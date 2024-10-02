using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Client Testimonial Block", 
        GUID = "d4835283-49a0-48b8-9b5f-8a32a6ab2252", 
        Description = "")]
    public class ClientTestimonialBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Background Image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual Url? ClientTestimonialImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Title",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual string? ClientTestimonialTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Description",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual XhtmlString? ClientTestimonialDescription { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Client Testimonials Block",
            Description = "Provided client testimonials that will be displayed",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual IList<ClientTestimonialBlockItem>? ClientTestimonialItems { get; set; }
    }
}