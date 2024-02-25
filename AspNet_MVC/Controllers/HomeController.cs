using Microsoft.AspNetCore.Mvc;

namespace AspNet_MVC.Controllers
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
	}
}
