namespace HomeProperty.Business.DataStore.Properties
{
    public interface IPropertyPageVisitRepository
    {
        public IList<VisitorCount> GetPopularPropertiesVisit();
        public void LogPropertyPageVisit(ContentReference propertiesPage);
    }
}
