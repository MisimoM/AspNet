using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			ViewData["Title"] = "Home";
			return View();
		}

		public IActionResult Contact()
		{
			return View();
		}

        public IActionResult Courses()
        {
            return View();
        }
    }
}
