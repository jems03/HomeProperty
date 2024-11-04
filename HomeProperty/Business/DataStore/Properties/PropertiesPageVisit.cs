using EPiServer.Data.Dynamic;

namespace HomeProperty.Business.DataStore.Properties
{
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true)]
    public class PropertiesPageVisit
    {
        public Guid Id { get; set; }
        public int PageId { get; set; }
        public DateTime DateVisit { get; set; }
    }

    public class VisitorCount
    {
        public int PageId { get; set; }
        public int VisitCount { get; set; }
    }
}
