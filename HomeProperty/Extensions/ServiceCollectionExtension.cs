using HomeProperty.Business;
using HomeProperty.Business.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

namespace HomeProperty.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddHomeProperty(this IServiceCollection services) {
            services.Configure<RazorViewEngineOptions>(options => options.ViewLocationExpanders.Add(new SiteViewEngineLocationExpander()));
            services.Configure<MvcOptions>(options => options.Filters.Add<PageContextActionFilter>());

            return services;
        }
    }
}
