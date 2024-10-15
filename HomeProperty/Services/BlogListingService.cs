using EPiServer.ServiceLocation;
using HomeProperty.Models.Blocks;
using HomeProperty.Models.Pages;

namespace HomeProperty.Services
{
    //public interface IBlogService
    //{
    //    void FetchBlogDetails(BlogListingBlock blogListingBlock);
    //}

    //[ServiceConfiguration(typeof(IBlogService))]
    //public class BlogListingService : IBlogService
    //{
    //    private readonly IContentLoader _contentLoader;

    //    public BlogListingService(IContentLoader contentLoader)
    //    {
    //        _contentLoader = contentLoader;
    //    }

    //    public void FetchBlogDetails(BlogListingBlock blogListingBlock)
    //    {
    //        var blogSinglePageReference = blogListingBlock.BlogSinglePages;

    //        if (blogSinglePageReference != null && blogSinglePageReference.Any())
    //        {
    //            foreach (var blogPage in blogSinglePageReference)
    //            {
    //                if (blogSinglePageReference != null)
    //                {
    //                    // Fetch each blog page using the content loader
    //                    var blogSinglePage = _contentLoader.Get<BlogSinglePage>(blogPage);

    //                    // Process the blog page details (like Title, Publish Date, etc.)
    //                    Console.WriteLine(blogSinglePage);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine("No blog pages found.");
    //        }

    //    }
    //}
}
