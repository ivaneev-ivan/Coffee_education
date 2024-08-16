using Coffee.Data;
using Coffee.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Repositories
{
    public class NewsRepository
    {
        private ApplicationDbContext _context;

        public NewsRepository(ApplicationDbContext context)
        {

            _context = context;
        }

        public async Task<List<News>> GetNewNews()
        {
            return await _context.News.ToListAsync();
        }

		public async Task<List<News>> GetOnlyActiveNews()
		{
			return await _context.News.Where(x => x.IsActive).ToListAsync();
		}


		public async Task<News> CreateNewsAsync(News news)
		{
            _context.News.Add(news);
            news.Date = DateTime.SpecifyKind(news.Date, DateTimeKind.Utc);
            await _context.SaveChangesAsync();
            return news;
		}
	}
}
