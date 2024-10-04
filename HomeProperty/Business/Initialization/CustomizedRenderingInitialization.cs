using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using HomeProperty.Business.Rendering;

namespace HomeProperty.Business.Initialization
{
    [ModuleDependency(typeof(InitializationModule))]
    public class CustomizedRenderingInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            
        }

        public void Initialize(InitializationEngine context)
        {
            context.Locate.Advanced.GetInstance<ITemplateResolverEvents>().TemplateResolved += TemplateCoordinator.OnTemplateResolved;
        }

        public void Uninitialize(InitializationEngine context)
        {
            context.Locate.Advanced.GetInstance<ITemplateResolverEvents>().TemplateResolved -= TemplateCoordinator.OnTemplateResolved;
        }
    }
}
