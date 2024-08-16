using Coffee.Models.Entities;
using Coffee.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Coffee.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private NewsRepository _newsRepository;

        public AdminController(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public async Task<ActionResult> News()
        {
            var listNews = await _newsRepository.GetNewNews();
            return View(listNews);
        }

        [Route("/admin/news/create")]
        public async Task<ActionResult> CreateNews()
        {
            return View();
        }

		[Route("/admin/news/create")]
        [HttpPost]
		public async Task<ActionResult> CreateNewsPost(News news)
		{
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId)) {
                news.AuthorId = userId;
				var result = await _newsRepository.CreateNewsAsync(news);
			}

			return Redirect("/admin/news/");
		}

		[Route("/admin/news/edit/{id}")]
		public async Task<ActionResult> EditNews(int id)
		{
            var news = await _newsRepository.GetNewsById(id);
			return View(news);
		}

		[Route("/admin/news/edit/{id}")]
		[HttpPost]
		public async Task<ActionResult> EditNewsPost(News news)
		{
            await _newsRepository.EditNewsAsync(news);

			return Redirect("/admin/news/");
		}

		[Route("/admin/news/delete/{id}")]
		public async Task<ActionResult> DeleteNews(int id)
		{
			await _newsRepository.DeleteNews(id);
			return Redirect("/admin/news/");
		}
	}
}