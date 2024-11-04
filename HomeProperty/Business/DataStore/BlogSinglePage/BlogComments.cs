using EPiServer.Data.Dynamic;

namespace HomeProperty.Business.DataStore.BlogSinglePage
{
    [EPiServerDataStore(AutomaticallyRemapStore = true)]
    public class BlogComments
    {
        public int BlogId { get; set; }      
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Url { get; set; }
        public string Comments { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
