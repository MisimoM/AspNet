using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    [Authorize]
    public class CoursesController(HttpClient httpClient) : Controller
    {

        private readonly HttpClient _httpClient = httpClient;

        [Route("/Courses")]
        public async Task<IActionResult> Courses()
        {
            var viewModel = new CourseIndexViewModel();

            var response = await _httpClient.GetAsync("https://localhost:7002/api/Courses");

            if (response.IsSuccessStatusCode)
            {
                viewModel.Courses = JsonConvert.DeserializeObject<IEnumerable<CourseViewModel>>(await response.Content.ReadAsStringAsync())!;
            }

            return View(viewModel);
        }
    }
}
