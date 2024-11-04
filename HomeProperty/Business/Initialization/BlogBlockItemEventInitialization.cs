using EPiServer.Framework;

namespace HomeProperty.Business.Initialization
{
    //[InitializableModule]
    //[ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class BlogBlockItemEventInitialization /*: IInitializableModule*/
    {
        //private IContentEvents _contentEvents;
        //private BlogPostService _blogPostService;
        //private IPrincipalAccessor _principalAccessor;

        //public void Initialize(InitializationEngine context)
        //{
        //    _contentEvents = context.Locate.Advanced.GetInstance<IContentEvents>();
        //    _blogPostService = context.Locate.Advanced.GetInstance<BlogPostService>();
        //    _principalAccessor = context.Locate.Advanced.GetInstance<IPrincipalAccessor>();

        //    _contentEvents.PublishedContent += OnPublishedContent;
        //}

        //private void OnPublishedContent(object sender, ContentEventArgs e)
        //{
        //    if(e.Content is IContentData contentData)
        //    {
        //        foreach (var property in contentData.Property)
        //        {
        //            // Check if the property is a ReadOnlyCollection of BlogBlockItems
        //            if (property.Value is ReadOnlyCollection<BlogBlockItem> blogItems)
        //            {
        //                foreach (var blockItem in blogItems)
        //                {
        //                    if (blockItem != null)
        //                    {
        //                        Debug.WriteLine("Found and processing BlogBlockItem.");
        //                        _blogPostService.SaveBlogPost(blockItem, _principalAccessor.Principal);

        //                    }
        //                }
        //            }
        //            else
        //            {
        //                Debug.WriteLine($"Property type: {property.Value.GetType().FullName}");
        //            }
        //        }
        //    }
            
        //}

        //public void Uninitialize(InitializationEngine context)
        //{
        //    _contentEvents.PublishedContent -= OnPublishedContent;
        //}
    }
}
