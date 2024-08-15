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
    }
}
