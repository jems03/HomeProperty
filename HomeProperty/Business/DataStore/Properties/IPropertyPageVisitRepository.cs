namespace HomeProperty.Business.DataStore.Properties
{
    public interface IPropertyPageVisitRepository
    {
        public IList<VisitorCount> GetPopularProperties(int count);
        public void LogPropertyPageVisit(ContentReference propertiesPage);
    }
}
