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
            ViewBag.PartialViewName = partialViewName;

            return View("Account");
        }
    }
}
