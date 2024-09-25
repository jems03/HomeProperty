using EPiServer.Web.Mvc;
using HomeProperty.Models.Pages;
using Microsoft.AspNetCore.Mvc;

namespace HomeProperty.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        public IActionResult Index(StartPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return View(currentPage);
        }
    }
}
