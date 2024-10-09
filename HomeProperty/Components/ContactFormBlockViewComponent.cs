using EPiServer.Web.Mvc;
using HomeProperty.Models.Blocks;
using HomeProperty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeProperty.Components
{
    public class ContactFormBlockViewComponent : BlockComponent<ContactFormBlock>
    {
        protected override IViewComponentResult InvokeComponent(ContactFormBlock currentContent)
        {
            var model = new ContactFormViewModel(currentContent);

            return View(model);
        }
    }
}
