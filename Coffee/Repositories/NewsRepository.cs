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

		public async Task<News> EditNewsAsync(News news)
		{
			News item = await GetNewsById(news.Id);
			
			item.Title = news.Title;
			item.Description = news.Description;
			item.Date = DateTime.SpecifyKind(news.Date, DateTimeKind.Utc);
			item.IsActive = news.IsActive;

			await _context.SaveChangesAsync();
			return news;
		}

		public async Task<News> GetNewsById(int id)
		{
			return await _context.News.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task DeleteNews(int id)
		{
			News item = await GetNewsById(id);
			_context.News.Remove(item);
			await _context.SaveChangesAsync();
		}
	}
}
