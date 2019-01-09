using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarDealership.App.Controllers
{
    [Authorize]
    public class CommentsController : BaseController
    {
        private readonly NewsService newsService;
        private readonly CommentsService commentsService;
        private readonly UserService userService;

        public CommentsController(NewsService newsService, CommentsService commentsService, UserService userService)
        {
            this.newsService = newsService;
            this.commentsService = commentsService;
            this.userService = userService;
        }

        public IActionResult Create(string newsId, string content)
        {
            if (string.IsNullOrEmpty(newsId))
            {
                var model = this.newsService.GetErrorViewModel(Constants.NewsNotFoundMessage);

                return this.View(Constants.ErrorView, model);
            }

            if (string.IsNullOrEmpty(content))
            {
                var model = this.commentsService.GetErrorModel(Constants.CommentContentErrorMessage);

                return this.View(Constants.ErrorView, model);
            }

            var authorId = this.userService.GetUserByUsername(this.User.Identity.Name).Id;

            try
            {
                var comment = this.commentsService.Create(authorId, newsId, content);

                return this.RedirectToAction(Constants.ReadNewsView, Constants.NewsController, new { newsId });
            }
            catch (ArgumentException)
            {
                var model = this.newsService.GetErrorViewModel(Constants.NewsNotFoundMessage);

                return this.View(Constants.ErrorView, model);
            }
        }

        [HttpGet]
        public IActionResult Edit(string newsId)
        {
            if (string.IsNullOrEmpty(newsId))
            {
                var errorModel = this.commentsService.GetErrorModel(Constants.NewsNotFoundMessage);

                return this.View(Constants.ErrorView, errorModel);
            }

            try
            {
                var editCommentModel = this.newsService.GetReadModel(newsId);

                return this.View(editCommentModel);
            }
            catch (ArgumentException)
            {
                var errorModel = this.commentsService.GetErrorModel(Constants.EditCommentErrorMessage);

                return this.View(Constants.ErrorView, errorModel);
            }
        }

        [HttpPost]
        public IActionResult Edit(string commentId, string content, string newsId)
        {
            if (string.IsNullOrEmpty(commentId) || string.IsNullOrEmpty(content))
            {
                var errorModel = this.commentsService.GetErrorModel(Constants.CommentContentErrorMessage);

                return this.View(Constants.ErrorView, errorModel);
            }

            if (string.IsNullOrEmpty(newsId))
            {
                var errorModel = this.commentsService.GetErrorModel(Constants.NewsNotFoundMessage);

                return this.View(Constants.ErrorView, errorModel);
            }

            try
            {
                this.commentsService.EditComment(commentId, content);

                return this.RedirectToAction(Constants.ReadNewsView, Constants.NewsController, new { newsId });
            }
            catch (ArgumentException)
            {
                var errorModel = this.commentsService.GetErrorModel(Constants.CommentErrorMessage);

                return this.View(Constants.ErrorView, errorModel);
            }
        }
    }
}