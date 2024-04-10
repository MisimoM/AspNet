using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.ViewModels;
using System.Text;

namespace Presentation.Controllers
{
	public class HomeController(HttpClient httpClient) : Controller
	{
		private readonly HttpClient _httpClient = httpClient;
		public IActionResult Index()
		{
			ViewData["Title"] = "Home";
			return View();
		}

		public IActionResult Contact()
		{
			return View();
		}

		[Route("/error")]
		public ActionResult Error404(int statusCode) => View();

		[HttpPost]
		public async Task<IActionResult> Index(SubscriberViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
                    var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync("https://localhost:7002/api/Subscriber", content);

                    if (response.IsSuccessStatusCode)
                    {
                        ViewData["Status"] = "Success";
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        ViewData["Status"] = "AlreadyExists";
                    }
                }
				catch
				{
                    ViewData["Status"] = "ConnectionFailed";
                }
			}
			else
			{
				ViewData["Status"] = "Invalid";
			}

			return View(viewModel);
		}
    }
}
