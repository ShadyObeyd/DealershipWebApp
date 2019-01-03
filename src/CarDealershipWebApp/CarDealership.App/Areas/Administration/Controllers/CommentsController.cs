using CarDealership.App.Controllers;
using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarDealership.App.Areas.Administration.Controllers
{
    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdminRole)]
    public class CommentsController : BaseController
    {
        private readonly CommentsService commentsService;
        private readonly NewsService newsService;

        public CommentsController(CommentsService commentsService, NewsService newsService)
        {
            this.commentsService = commentsService;
            this.newsService = newsService;
        }

        public IActionResult Delete(string commentId, string newsId)
        {
            if (string.IsNullOrEmpty(commentId))
            {
                var model = this.commentsService.GetErrorModel(Constants.CommentErrorMessage);

                return this.View(Constants.ErrorView, model);
            }

            if (string.IsNullOrEmpty(newsId))
            {
                var model = this.newsService.GetErrorViewModel(Constants.NewsNotFoundMessage);

                return this.View(Constants.ErrorView, model);
            }

            try
            {
                this.commentsService.DeleteComment(commentId);
            }
            catch (ArgumentException)
            {
                var model = this.commentsService.GetErrorModel(Constants.CommentErrorMessage);

                return this.View(Constants.ErrorView, model);
            }

            return this.RedirectToAction(Constants.ReadNewsView, Constants.NewsController, new { area = string.Empty, newsId });
        }
    }
}