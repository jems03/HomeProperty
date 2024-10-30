using EPiServer.Web.Routing;

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
                var errorPageReference = new ContentReference(74);
                var notFoundPage = _urlResolver.GetUrl(errorPageReference);

                // Redirect to 404 Page
                if (!string.IsNullOrEmpty(notFoundPage)) { 
                    context.Response.Redirect(notFoundPage);
                }

            }
        }
    }
}
