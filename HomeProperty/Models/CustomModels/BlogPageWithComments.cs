using HomeProperty.Models.Pages;

namespace HomeProperty.Models.CustomModels
{
    public class BlogPageWithComments
    {
        public BlogSinglePage BlogPage { get; set; }
        public int CommentCount { get; set; }
    }
}
