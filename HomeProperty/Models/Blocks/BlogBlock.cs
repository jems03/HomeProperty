using EPiServer.Data.Dynamic;
using HomeProperty.Business.DataStore;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.Models.Blocks
{
    [ContentType(DisplayName = "Latest News Block", 
        GUID = "ac6993a0-ce50-4cf2-9359-e2467b76ec9c", 
        Description = "")]
    public class BlogBlock : BlockData
    {
        [CultureSpecific]
        [Display(
             Name = "Blog Block",
             Description = "Provide the Latest News",
             GroupName = SystemTabNames.Content,
             Order = 1)]

        public virtual IList<BlogBlockItem>? BlogItems { get; set; }

        public List<BlogPost> FetchBlogPosts()
        {
            var blogPostStore = DynamicDataStoreFactory.Instance.CreateStore(typeof(BlogPost));
            var blogPosts = blogPostStore.LoadAll<BlogPost>().ToList(); // Fetch all blog posts
            return blogPosts;
        }
    }
}