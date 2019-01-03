using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
               
            }

            if (string.IsNullOrEmpty(content))
            {

            }

            var authorId = this.userService.GetUserByUsername(this.User.Identity.Name).Id;

            var comment = this.commentsService.Create(authorId, newsId, content);

            return this.RedirectToAction(Constants.ReadNewsView, Constants.NewsController, new { newsId });
        }
    }
}