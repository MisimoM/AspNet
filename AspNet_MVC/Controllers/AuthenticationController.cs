using AspNet_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_MVC.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        [Route("/signin")]
        public IActionResult SignIn()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        [Route("/signin")]
        public IActionResult SignIn(SignInViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                viewmodel.ErrorMessage = "\u26A0 Incorrect email or password";
                return View(viewmodel);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
		[Route("/signup")]
		public IActionResult SignUp() => View(new SignUpViewModel());

		[HttpPost]
        [Route("/signup")]
        public IActionResult SignUp(SignUpViewModel viewmodel)
		{
			if (!ModelState.IsValid)
			{ 
				return View(viewmodel);
			}

			return RedirectToAction("Index", "Home");
		}
	}
}
