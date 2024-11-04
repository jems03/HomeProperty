using EPiServer.Web.Routing;
using HomeProperty.Models.Pages;
using HomeProperty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeProperty.Business
{
    public class PageContextActionFilter: IResultFilter
    {
        private readonly PageViewContextFactory _contextFactory;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILanguageBranchRepository _languageBranchRepository;
        private readonly IUrlResolver _urlResolver;

        public PageContextActionFilter(PageViewContextFactory contextFactory, 
            IHttpContextAccessor contextAccessor,
            ILanguageBranchRepository languageBranchRepository,
            IUrlResolver urlResolver)
        {
            _contextFactory = contextFactory;
            _contextAccessor = contextAccessor;
            _languageBranchRepository = languageBranchRepository;
            _urlResolver = urlResolver;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var controller = context.Controller as Controller;
            var viewModel = controller?.ViewData.Model;

            if (viewModel is IPageViewModel<SitePageData> model)
            {
                var currentContentLink = context.HttpContext.GetContentLink();

                var currentContext = _contextAccessor.HttpContext;

                var layoutModel = model.Layout ?? _contextFactory.CreateLayoutModel(currentContentLink, context.HttpContext);
                layoutModel.Languages = GetLanguages(model);

                model.Layout = layoutModel;
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        private IDictionary<string, string> GetLanguages(IPageViewModel<SitePageData> model)
        {
            IDictionary<string, string> languages = new Dictionary<string, string>();

            foreach(var lang in _languageBranchRepository.ListEnabled())
            {
                string langCode = lang.Culture.TwoLetterISOLanguageName;
                string pageUrl = _urlResolver.GetUrl(model.CurrentPage.ContentLink, langCode);

                languages.Add(langCode, pageUrl);
            }
           
            return languages;
        }
    }
}
