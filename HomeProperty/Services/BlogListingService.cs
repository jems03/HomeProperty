namespace HomeProperty.Services
{
    public class BlogListingService
    {
        private readonly IContentLoader _contentLoader;

        public BlogListingService(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IEnumerable<PageData> GetPageTree(ContentReference contentReference)
        {
            var pages = new List<PageData>();

            GetPagesRecursively(contentReference, pages);

            return pages;
        }

        private void GetPagesRecursively(ContentReference contentReference, List<PageData> pages)
        {
            var children = _contentLoader.GetChildren<PageData>(contentReference);

            foreach (var child in children)
            {
                pages.Add(child);

                GetPagesRecursively(child.ContentLink, pages);
            }

        }

    }
}
