using EPiServer.Data;
using EPiServer.Data.Dynamic;

namespace HomeProperty.Business.DataStore
{
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true)]
    public class BlogPost
    {
        public Identity Id { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public DateTime? BlogDate { get; set; }
        public string BlogImage { get; set; }
        public string Author { get; set; }
        public int CommentCount { get; set; }      
    }
}
