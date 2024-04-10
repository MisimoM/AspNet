using Microsoft.AspNetCore.Mvc;

namespace Presentation.Shared.Components.AccountComponents
{
    public class AccountViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string partialViewName)
        {

            if (string.IsNullOrEmpty(partialViewName))
            {
                return View("Details");
            }

            return View(partialViewName);
        }
    }
}
