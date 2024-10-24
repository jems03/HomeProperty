
using EPiServer.Data;
using EPiServer.Data.Dynamic;

namespace HomeProperty.Business.DataStore.Properties
{
    public class PropertiesPageVisitRepository : IPropertyPageVisitRepository
    {
        private readonly DynamicDataStore _dynamicDataStore;

        public PropertiesPageVisitRepository()
        {
            _dynamicDataStore = DynamicDataStoreFactory.Instance.GetStore(typeof(PropertiesPageVisit)) ?? 
                DynamicDataStoreFactory.Instance.CreateStore(typeof(PropertiesPageVisit));
        }

        private IEnumerable<PropertiesPageVisit> GetAllPropertiesPageVisit()
        {
            return _dynamicDataStore.LoadAll<PropertiesPageVisit>();
        }

        private PropertiesPageVisit GetPropertiesPageVisit(Identity id) {
            return _dynamicDataStore.Load<PropertiesPageVisit>(id);
        }

        private Identity SavePropertyPageVisit(PropertiesPageVisit propertyPageVisit) { 
            return _dynamicDataStore.Save(propertyPageVisit);
        }

        public IList<VisitorCount> GetPopularProperties(int count)
        {           
            var propertiesPageVisitCount = GetAllPropertiesPageVisit().GroupBy(pageVisit => pageVisit.PageId)
                .Select(page => new VisitorCount
                {
                    PageId = page.Key,
                    VisitCount = page.Count()
                })
                .OrderByDescending(pageVisit => pageVisit.VisitCount)
                .Take(count)
                .ToList();

            return propertiesPageVisitCount;
        }

        public void LogPropertyPageVisit(ContentReference propertiesPage)
        {
            var propertiesPageVisit = new PropertiesPageVisit
            {
                Id = Guid.NewGuid(),
                PageId = propertiesPage.ID,
                DateVisit = DateTime.Now,
            };

            SavePropertyPageVisit(propertiesPageVisit);
        }
    }
}
