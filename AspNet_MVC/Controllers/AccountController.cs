using Microsoft.AspNetCore.Mvc;

namespace AspNet_MVC.Controllers
{
	public class AccountController : Controller
	{
		[Route ("/account/details")]
		public IActionResult Account()
		{
			return View();
		}
	}
}
