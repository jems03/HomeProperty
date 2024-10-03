using EPiServer.Cms.TinyMce.PropertySettings.Internal;
using EPiServer.Labs.ContentManager;
using EPiServer.Web;
using HomeProperty.Business;
using HomeProperty.Business.Channels;
using HomeProperty.Business.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using EPiServer.Cms.TinyMce;
using EPiServer.Cms.TinyMce.Core;


namespace HomeProperty.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddHomeProperty(this IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options => options.ViewLocationExpanders.Add(new SiteViewEngineLocationExpander()));
            services.Configure<MvcOptions>(options => options.Filters.Add<PageContextActionFilter>());

            // Adding Configuration on Display Options
            services.Configure<DisplayOptions>(displayOption =>
            {
                displayOption.Add("full", "/displayoptions/full", Globals.ContentAreaTags.FullWidth, string.Empty, "epi-icon__layout--full");
                displayOption.Add("wide", "/displayoptions/wide", Globals.ContentAreaTags.WideWidth, string.Empty, "epi-icon__layout--wide");
                displayOption.Add("half", "/displayoptions/half", Globals.ContentAreaTags.HalfWidth, string.Empty, "epi-icon__layout--half");
                displayOption.Add("narrow", "/displayoptions/narrow", Globals.ContentAreaTags.NarrowWidth, string.Empty, "epi-icon__layout--narrow");
            });

            services.AddDisplayResolutions();
            services.AddDetection();
            services.AddContentManager();

            // Tiny MCE Configuration
            services.Configure<TinyMceConfiguration>(config =>
            {
                config.Default()
                .AddEpiserverSupport()
                .AddSetting("force_p_newlines", false)
                .AddSetting("forced_root_block", "");
            });

            return services;
        }

        private static void AddDisplayResolutions(this IServiceCollection services)
        {
            services.AddSingleton<StandardResolution>();
            services.AddSingleton<IpadHorizontalResolution>();
            services.AddSingleton<IphoneVerticalResolution>();
            services.AddSingleton<AndroidVerticalResolution>();
        }
    }
}
