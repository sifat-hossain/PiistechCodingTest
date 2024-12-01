using Microsoft.AspNetCore.Mvc;
using PiistechEcommerce.Web.Models;
using System.Text;
using System.Text.Json;

namespace PiistechEcommerce.Web.Controllers
{
    public class UserController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                var response = await client.GetAsync("https://localhost:7291/api/Users");
                if (response.IsSuccessStatusCode)
                {
                    var users = await JsonSerializer.DeserializeAsync<List<User>>(await response.Content.ReadAsStreamAsync());
                    return View(users);
                }
                else
                {
                    ModelState.AddModelError("", "Failed to load users");
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include: "Email,Password")] User user)
        {
            user.Id = Guid.NewGuid();
            user.Role = "user";
            user.IsDeleted = false;

            var client = _httpClientFactory.CreateClient();
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(user),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync("https://localhost:7291/api/Users", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                // Optionally handle success, e.g., redirect or show a success message
                return RedirectToAction("Index");
            }

            return View();


        }


    }
}
