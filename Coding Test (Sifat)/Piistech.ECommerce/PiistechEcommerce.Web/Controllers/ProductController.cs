using Microsoft.AspNetCore.Mvc;
using PiistechEcommerce.Web.Models;
using System.Text;
using System.Text.Json;

namespace PiistechEcommerce.Web.Controllers
{
    public class ProductController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                var response = await client.GetAsync("https://localhost:7291/api/Products");
                if (response.IsSuccessStatusCode)
                {
                    var products = await JsonSerializer.DeserializeAsync<List<Product>>(await response.Content.ReadAsStreamAsync());
                    return View(products);
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

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            product.Id = Guid.NewGuid();
            product.IsDeleted = false;
            try
            {
                var client = _httpClientFactory.CreateClient();
                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(product),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync("https://localhost:7291/api/Products", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    // Optionally handle success, e.g., redirect or show a success message
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
                return View();
            }
            return View();
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            // This method needs to update. the api call will be in a seperate service and one more api needs to be created.

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7291/api/Products");

            if (response.IsSuccessStatusCode)
            {
                var products = await JsonSerializer.DeserializeAsync<List<Product>>(await response.Content.ReadAsStreamAsync());

                var product = products.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    IsDeleted = false
                })
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

                return View(product);
            }
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(product),
                    Encoding.UTF8,
                    "application/json"
                );
                var response = await client.PostAsync("https://localhost:7291/api/Products", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    // Optionally handle success, e.g., redirect or show a success message
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7291/api/Products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // Handle error
            ViewBag.ErrorMessage = "Error deleting product.";
            return View("Error"); // o
        }
    }
}
