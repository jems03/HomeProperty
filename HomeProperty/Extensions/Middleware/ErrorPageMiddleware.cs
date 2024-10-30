using EPiServer.Web.Routing;
using HomeProperty.Models.Pages;

namespace HomeProperty.Extensions.Middleware
{
    public class ErrorPageMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUrlResolver _urlResolver;
        private readonly IContentLoader _contentLoader;

        public ErrorPageMiddleware(RequestDelegate next, IUrlResolver urlResolver, IContentLoader contentLoader)
        {
            _next = next;
            _urlResolver = urlResolver;
            _contentLoader = contentLoader;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            // Error Page
            if(context.Response.StatusCode == 404)
            {
                var startPage = _contentLoader.Get<StartPage>(ContentReference.StartPage);
                var notFoundPage = _contentLoader.Get<StandardPage>(startPage.ErrorPage);              

                // Redirect to 404 Page
                if (notFoundPage != null) { 
                    context.Response.Redirect(_urlResolver.GetUrl(notFoundPage.ContentLink));
                }

            }
        }
    }
}
