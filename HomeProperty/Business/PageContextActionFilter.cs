﻿using EPiServer.Web.Routing;
using HomeProperty.Models.Pages;
using HomeProperty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeProperty.Business
{
    public class PageContextActionFilter: IResultFilter
    {
        private readonly PageViewContextFactory _contextFactory;

        public PageContextActionFilter(PageViewContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var controller = context.Controller as Controller;
            var viewModel = controller?.ViewData.Model;

            if (viewModel is IPageViewModel<SitePageData> model)
            {
                var currentContentLink = context.HttpContext.GetContentLink();

                var layoutModel = model.Layout ?? _contextFactory.CreateLayoutModel(currentContentLink, context.HttpContext);

                model.Layout = layoutModel;
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}