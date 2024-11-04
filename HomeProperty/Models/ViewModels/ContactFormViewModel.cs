using EPiServer.Forms.Implementation.Elements;
using EPiServer.ServiceLocation;
using HomeProperty.Models.Blocks;

namespace HomeProperty.Models.ViewModels
{
    public class ContactFormViewModel
    {
        private readonly Injected<IContentLoader> _contentLoader;

        public ContactFormViewModel(ContactFormBlock _contactForm)
        {
            ContactFormBlock = _contactForm;
            FormContainerBlock = _contentLoader.Service.Get<FormContainerBlock>(_contactForm.ContactFormReference);
        }

        public ContactFormBlock ContactFormBlock { get; set; }
        public FormContainerBlock FormContainerBlock { get; set; }
    }
}
