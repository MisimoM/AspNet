using Microsoft.AspNetCore.Mvc;

namespace AspNet_MVC.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult SignIn()
		{
			// Logic to display the sign-in page
			return View();
		}

		public IActionResult SignUp()
		{
			// Logic to display the sign-up page
			return View();
		}
	}
}
