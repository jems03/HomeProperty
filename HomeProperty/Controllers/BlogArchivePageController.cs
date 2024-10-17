using EPiServer.Web.Mvc;
using HomeProperty.Business.DataStore.BlogSinglePage;
using HomeProperty.Models.CustomModels;
using HomeProperty.Models.Pages;
using HomeProperty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeProperty.Controllers
{
    public class BlogArchivePageController : PageController<BlogArchivePage>
    {
        private readonly IContentLoader _contentLoader;
        private readonly ICommentRepository _commentRepository;

        public BlogArchivePageController(IContentLoader contentLoader, ICommentRepository commentRepository)
        {
            _contentLoader = contentLoader;
            _commentRepository = commentRepository;
        }

        public IActionResult Index(BlogArchivePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);

            var blogArchive = new ContentReference(currentPage.ContentLink.ID);

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            currentPage.BlogPageWithComments = _contentLoader.GetChildren<PageData>(blogArchive)
                    .Select(blogPage =>
                    {
                        // Fetch the BlogSinglePage using the ContentLink
                        var page = _contentLoader.Get<BlogSinglePage>(blogPage.ContentLink);

                        if (page != null)
                        {
                            // Populate the comments from Dynamic Data Store
                            var allComments = _commentRepository.GetAllComments();

                            // Get comments for the current blog page
                            var blogComments = allComments.Where(m => m.BlogId == page.ContentLink.ID).ToList();

                            // Return a new instance of BlogPageWithComments with the blog page and comment count
                            return new BlogPageWithComments
                            {
                                BlogPage = page,
                                CommentCount = blogComments.Count
                            };
                        }

                        return null; // Return null if the page is not found
                    })
                    .Where(item => item != null) // Filter out null items
                    .OrderByDescending(item => item.BlogPage.StartPublish) // Sort by StartPublish (or use BlogSingleDate if needed)
                    .ToList();
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.

            return View(model);
        }
    }
}
