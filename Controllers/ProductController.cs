using Microsoft.AspNetCore.Mvc;
using MangaStore.Data;
using MangaStore.Models;
using MangaStore.Enums;
using MangaStore.ViewModels;

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
            var list = new List<ProductViewModel>();
            _context.Products.ToList().ForEach
            (
                pd => list.Add(new ProductViewModel(pd))
            );
            return View(list);
        }

		[HttpGet]
		public IActionResult Create()
		{
			ViewData["TheLoai"] = ProductCategory.getArrayView();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(ProductViewModel product)
		{
			product.CustomCheck(_context,ModelState);
            if (ModelState.IsValid)
            {
                Product newProduct = new Product(product);
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
			return View(product);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var product = _context.Products.Find(id);
			if (product == null)
			{
				return NotFound();
			}
			ViewData["TheLoai"] = ProductCategory.getArrayView();
			return View(new EditProductViewModel(product));
		}

		[HttpPut]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(EditProductViewModel product)
		{
			product.CustomCheck(_context, ModelState);
			if (ModelState.IsValid)
			{
				Product newProduct = new Product(product);
				_context.Products.Update(newProduct);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(product);
		}

		//delete
		[HttpDelete]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			var product = _context.Products.Find(id);
			if (product == null)
			{
				return NotFound();
			}
			_context.Products.Remove(product);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
