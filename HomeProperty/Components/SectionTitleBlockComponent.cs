using EPiServer.Web.Mvc;
using HomeProperty.Models.Blocks;
using Microsoft.AspNetCore.Mvc;


namespace HomeProperty.Components
{
    public class SectionTitleBlockComponent : BlockComponent<SectionTitleBlock>
    {
        public SectionTitleBlockComponent()
        {
        }

        protected override IViewComponentResult InvokeComponent(SectionTitleBlock currentContent)
        {
            return View(currentContent);
        }
    }
}
