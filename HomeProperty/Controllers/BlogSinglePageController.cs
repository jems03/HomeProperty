using EPiServer.Globalization;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using HomeProperty.Business.DataStore.BlogSinglePage;
using HomeProperty.Models.Pages;
using HomeProperty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeProperty.Controllers
{
    public class BlogSinglePageController : PageController<BlogSinglePage>
    {
        private readonly ICommentRepository _commentRepository;

        public BlogSinglePageController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IActionResult Index(BlogSinglePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            if (currentPage != null)
            {
                var blogId = currentPage.ContentLink.ID;
                TempData["BlogId"] = blogId;
                

                // Populate the comments from Dynamic Data Store
                var allComments = _commentRepository.GetAllComments();

                var blogComments = allComments.Where(m => m.BlogId == blogId).ToList();

                currentPage.BlogComments = blogComments;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveComment(BlogSinglePage currentPage, IFormCollection formCollection)
        {
            var pageUrl = UrlResolver.Current.GetUrl(currentPage.ContentLink, ContentLanguage.PreferredCulture.Name,
                new VirtualPathArguments { ContextMode = EPiServer.Web.ContextMode.Default });

            string name = formCollection["author"];
            string email = formCollection["email"];
            string url = formCollection["url"];
            string comment = formCollection["Comment"];

            var leaveComment = new BlogComments()
            {
                BlogId = (int)TempData["BlogId"],
                Name = name,
                EmailAddress = email,
                Url = url,
                Comments = comment,
                CommentDate = DateTime.Now,
            };

            _commentRepository.SaveComment(leaveComment);

            return Redirect(pageUrl);
        }
    }
}
