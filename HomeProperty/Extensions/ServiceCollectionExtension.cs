using HomeProperty.Business.Rendering;
using HomeProperty.Business;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
