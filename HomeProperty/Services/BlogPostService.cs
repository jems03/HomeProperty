using EPiServer.Data.Dynamic;
using EPiServer.Security;
using HomeProperty.Business.DataStore;
using HomeProperty.Models.Blocks;
using System.Security.Principal;

namespace HomeProperty.Services
{
    public class BlogPostService
    {
        public void SaveBlogPost(BlogBlockItem blogBlockItem, IPrincipal currentUser)
        {
            var blogPostStore = DynamicDataStoreFactory.Instance.CreateStore(typeof(BlogPost));

            var blogPost = new BlogPost
            {
                BlogTitle = blogBlockItem.BlogTitle,
                BlogDescription = blogBlockItem.BlogDescription,
                BlogDate = blogBlockItem.BlogDate,
                BlogImage = blogBlockItem.BlogImage?.ToString(),
                Author = currentUser.Identity.Name, // Logged-in user
                CommentCount = 0 // Initialize comments count
            };

            blogPostStore.Save(blogPost);
        }

        public IEnumerable<BlogPost> GetBlogPosts()
        {
            var blogPostStore = DynamicDataStoreFactory.Instance.GetStore(typeof(BlogPost));
            return blogPostStore.LoadAll<BlogPost>();
        }
    }
}
