using HomeProperty.Models.CustomModels;

namespace HomeProperty.Services.BlogListing
{
    public interface IBlogListingService
    {
        IList<BlogPageWithComments> GetAllBlogPages(ContentReference blogArchive);

        IList<BlogPageWithComments> GetLatestBlogPages(ContentReference blogArchive);
    }
}
