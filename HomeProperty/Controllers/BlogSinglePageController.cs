using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using HomeProperty.Business.DataStore.BlogSinglePage;
using HomeProperty.Models.Pages;
using HomeProperty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HomeProperty.Controllers
{
    public class BlogSinglePageController : PageController<BlogSinglePage>
    {
        private readonly ICommentRepository _commentRepository;

        public BlogSinglePageController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IActionResult Index(BlogSinglePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            if (currentPage != null)
            {
                var blogId = currentPage.ContentLink.ID;
                TempData["BlogId"] = blogId;
                

                // Populate the comments from Dynamic Data Store
                var allComments = _commentRepository.GetAllComments();

                var blogComments = allComments.Where(m => m.BlogId == blogId).ToList();

                currentPage.BlogComments = blogComments;
            }
            return View(model);
        }
    }
}
