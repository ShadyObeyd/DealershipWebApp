using CarDealership.Data;
using CarDealership.Models.ViewModels.News;
using System.Collections.Generic;
using System.Linq;

namespace CarDealership.Services
{
    public class NewsService
    {
        private readonly DealershipDbContext db;

        public NewsService(DealershipDbContext db)
        {
            this.db = db;
        }

        public List<NewsIndexViewModel> GetIndexModel()
        {
            return this.db.News.OrderByDescending(n => n.PublishedOn).Select(n => new NewsIndexViewModel
            {
                Id = n.Id,
                Content = n.Content,
                Title = n.Title
            }).ToList();
        }
    }
}
