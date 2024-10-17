using EPiServer.Web.Mvc;
using HomeProperty.Business.DataStore.BlogSinglePage;
using HomeProperty.Models.CustomModels;
using HomeProperty.Models.Pages;
using HomeProperty.Models.ViewModels;
using HomeProperty.Services.BlogListing;
using Microsoft.AspNetCore.Mvc;

namespace HomeProperty.Controllers
{
    public class BlogArchivePageController : PageController<BlogArchivePage>
    {
        private readonly IContentLoader _contentLoader;
        private readonly ICommentRepository _commentRepository;
        private readonly IBlogListingService _blogListingService;

        public BlogArchivePageController(IContentLoader contentLoader, ICommentRepository commentRepository, IBlogListingService blogListingService)
        {
            _contentLoader = contentLoader;
            _commentRepository = commentRepository;
            _blogListingService = blogListingService;
        }

        public IActionResult Index(BlogArchivePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);

            var blogArchive = new ContentReference(currentPage.ContentLink.ID);


            currentPage.BlogPageWithComments = _blogListingService.GetAllBlogPages(blogArchive);


            return View(model);
        }
    }
}
