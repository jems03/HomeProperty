using EPiServer.Data;
using EPiServer.Data.Dynamic;

namespace HomeProperty.Business.DataStore.BlogSinglePage
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DynamicDataStore _dynamicDataStore;

        public CommentRepository()
        {
            _dynamicDataStore = DynamicDataStoreFactory.Instance.GetStore(typeof(BlogComments)) ?? DynamicDataStoreFactory.Instance.CreateStore(typeof(BlogComments));
        }

        public IEnumerable<BlogComments> GetAllComments()
        {
            return _dynamicDataStore.LoadAll<BlogComments>();
        }

        public BlogComments GetComment(Identity id)
        {
            return _dynamicDataStore.Load<BlogComments>(id);
        }

        public Identity SaveComment(BlogComments leaveComments)
        {
            return _dynamicDataStore.Save(leaveComments);
        }
    }
}
