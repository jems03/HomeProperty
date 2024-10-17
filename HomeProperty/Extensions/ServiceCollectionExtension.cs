using EPiServer.Cms.TinyMce.PropertySettings.Internal;
using EPiServer.Labs.ContentManager;
using EPiServer.Web;
using HomeProperty.Business;
using HomeProperty.Business.Channels;
using HomeProperty.Business.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using EPiServer.Cms.TinyMce.Core;
using EPiServer.Security;
using HomeProperty.Services;
using HomeProperty.Business.DataStore.BlogSinglePage;
using HomeProperty.Services.BlogListing;


namespace HomeProperty.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddHomeProperty(this IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options => options.ViewLocationExpanders.Add(new SiteViewEngineLocationExpander()));
            services.Configure<MvcOptions>(options => options.Filters.Add<PageContextActionFilter>());
            services.AddHttpContextAccessor();

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

            //Tiny MCE Configuration
            //services.Configure<TinyMceConfiguration>(config =>
            //{
            //    config.Default()
            //    .AddEpiserverSupport()
            //    .AddSettingsTransform("role-based-settings", (settings, content, propertyName) =>
            //    {
            //        settings.AddPlugin("link");
            //        settings.AppendToolbar("| link");

            //        if (PrincipalInfo.CurrentPrincipal.IsInRole(Globals.WebRoles.WebAdmins))
            //        {
            //            settings.AddPlugin("code");
            //            settings.AppendToolbar("| code");
            //        }
            //    })

            //    .AddSetting("force_p_newlines", false);
            //    //.AddSetting("forced_root_block", "");
            //});

            services.AddTransient<BlogPostService>();

            services.AddTransient<IBlogListingService, BlogListingService>();
            services.AddScoped<ICommentRepository, CommentRepository>();


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
