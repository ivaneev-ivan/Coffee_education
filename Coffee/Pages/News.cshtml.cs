using Coffee.Models.Entities;
using Coffee.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coffee.Pages
{
    public class NewsModel : PageModel
    {
        private readonly ILogger<NewsModel> _logger;

        private NewsRepository _newsRepository;


        public NewsModel(ILogger<NewsModel> logger, NewsRepository newsRepository)
        {
            _logger = logger;
            _newsRepository = newsRepository;
        }

        public List<News> News { get; set; }

        public async Task OnGetAsync()
        {
            News = await _newsRepository.GetOnlyActiveNews();
        }

        public void OnGet()
        {
        }
    }

}
