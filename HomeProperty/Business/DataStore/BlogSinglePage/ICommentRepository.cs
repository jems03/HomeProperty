using EPiServer.Data;

namespace HomeProperty.Business.DataStore.BlogSinglePage
{
    public interface ICommentRepository
    {
        public Identity SaveComment(BlogComments leaveComments);

        public BlogComments GetComment(Identity id);

        public IEnumerable<BlogComments> GetAllComments();
    }
}
