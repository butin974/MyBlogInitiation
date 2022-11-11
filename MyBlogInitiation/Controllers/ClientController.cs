using Microsoft.AspNetCore.Mvc;

namespace MyBlogInitiation.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
