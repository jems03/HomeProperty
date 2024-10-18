using HomeProperty.Business.DataStore.BlogSinglePage;
using HomeProperty.Models.CustomModels;
using HomeProperty.Models.Pages;

namespace HomeProperty.Services.BlogListing
{
    public class BlogListingService : IBlogListingService
    {
        private readonly IContentLoader _contentLoader;
        private readonly ICommentRepository _commentRepository;

        public BlogListingService(IContentLoader contentLoader, ICommentRepository commentRepository)
        {
            _contentLoader = contentLoader;
            _commentRepository = commentRepository;
        }

        public IList<BlogPageWithComments> GetAllBlogPages(ContentReference blogArchive)
        {
            var getAllBlogs = _contentLoader.GetChildren<PageData>(blogArchive)
                    .Where(blogPage => blogPage is BlogSinglePage)
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

            return getAllBlogs;
        }

        public IList<BlogPageWithComments> GetLatestBlogPages(ContentReference blogArchive)
        {
            var getLatestBlogs = _contentLoader.GetChildren<PageData>(blogArchive)
                     .Where(blogPage => blogPage is BlogSinglePage)
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
                     .Take(3)
                     .ToList();

            return getLatestBlogs;
        }
    }
}
