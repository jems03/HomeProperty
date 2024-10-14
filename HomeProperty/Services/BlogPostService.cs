using EPiServer.Data;
using EPiServer.Data.Dynamic;
using EPiServer.Security;
using HomeProperty.Business.DataStore;
using HomeProperty.Models.Blocks;
using System.Diagnostics;
using System.Security.Principal;

namespace HomeProperty.Services
{
    public class BlogPostService
    {
        //public void SaveBlogPost(BlogBlockItem blogBlockItem, IPrincipal currentUser)
        //{
        //    var blogPostStore = DynamicDataStoreFactory.Instance.CreateStore(typeof(BlogPost));

        //    var blogPosts = blogPostStore.LoadAll<BlogPost>().ToList();

        //    // Determine if there are changes on the Blog Block Item
        //    foreach (var blog in blogPosts)
        //    {
        //        var matchingBlockItem = blogPosts.FirstOrDefault(b => b.Id == blog.Id);

        //        if (matchingBlockItem != null)
        //        {
        //            // Check for changes
        //            bool hasChanges = blog.BlogDescription != matchingBlockItem.BlogDescription ||
        //                  blog.BlogDate != matchingBlockItem.BlogDate ||
        //                  blog.BlogImage != matchingBlockItem.BlogImage?.ToString();

        //            if (hasChanges)
        //            {
        //                // Update existing blog post properties
        //                blog.BlogTitle = blogBlockItem.BlogTitle;
        //                blog.BlogDescription = blogBlockItem.BlogDescription;
        //                blog.BlogDate = blogBlockItem.BlogDate;
        //                blog.BlogImage = blogBlockItem.BlogImage?.ToString();
        //                blog.Author = currentUser.Identity.Name; // Logged-in user

        //                blogPostStore.Save(blog);
        //            }
        //            else
        //            {
        //                // Add the item
        //                // Create a new blog post if no existing ID is provided
        //                var blogPost = new BlogPost
        //                {
        //                    Id = Identity.NewIdentity(), // Generate new identity for a new post
        //                    BlogTitle = blogBlockItem.BlogTitle,
        //                    BlogDescription = blogBlockItem.BlogDescription,
        //                    BlogDate = blogBlockItem.BlogDate,
        //                    BlogImage = blogBlockItem.BlogImage?.ToString(),
        //                    Author = currentUser.Identity.Name, // Logged-in user
        //                    CommentCount = 0 // Initialize comments count for new post
        //                };

        //                blogPostStore.Save(blogPost);
        //            }               

        //        }
        //    }
        //}
    }
}
