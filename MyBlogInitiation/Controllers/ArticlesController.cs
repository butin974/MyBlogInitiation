using Microsoft.AspNetCore.Mvc;
using MyBlogInitiation.Mocks;
using MyBlogInitiation.Models;
using MyBlogInitiation.ViewModels;

namespace MyBlogInitiation.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            // creer une liste d'articles en dur
            var vm = new ArticlesViewModel
            {
                Articles = ArticlesMock.listArticles
            };
            return View(vm);
        }

        public IActionResult Stock()
        {
            return View();
        }
    }
}
