using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	public class AccountController : Controller
	{
        [Route("/Account/Details")]
        public IActionResult Account()
        {
            return View("Account");
        }

        [Route("/Account/{partialViewName}")]
        public IActionResult ChangePartialView(string partialViewName)
        {
            // You can perform any necessary logic here
            // For simplicity, we'll pass the partial view name to the view

            ViewBag.PartialViewName = partialViewName;

            return View("Account");
        }
    }
}
