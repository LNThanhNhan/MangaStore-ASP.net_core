using Microsoft.AspNetCore.Mvc;
using MangaStore.Data;
using MangaStore.Models;
using MangaStore.Enums;

namespace MangaStore.Controllers
{
    public class ProductController : Controller
    {
		private readonly Context _context;
		public ProductController(Context context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
			var products = _context.Products.ToList();
			return View(products);
        }

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
