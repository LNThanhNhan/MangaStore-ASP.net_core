using Microsoft.AspNetCore.Mvc;
using MangaStore.Data;
using MangaStore.Models;
using MangaStore.Enums;
using MangaStore.ViewModels;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.AspNetCore;

namespace MangaStore.Controllers
{
    public class ProductController : Controller
    {
		private readonly Context _context;
        private readonly IMapper _mapper;
		private readonly IValidator<ProductViewModel> _viewValidator;
		public ProductController(Context context, IMapper mapper, IValidator<ProductViewModel> viewValidator)
        {
            _context = context;
            _mapper = mapper;
			_viewValidator = viewValidator;
		}

		public IActionResult Index()
        {
            var list = new List<ProductViewModel>();
            _context.Products.ToList().ForEach
            (
                pd => list.Add(_mapper.Map<ProductViewModel>(pd))
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
			//product.CustomCheck(_context,ModelState);
			ValidationResult result = _viewValidator.Validate(product);
			if (result.IsValid)
            {
                Product newProduct = _mapper.Map<Product>(product);
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.Clear();
            result.AddToModelState(this.ModelState);
			return View(product);
		}

		/*[HttpGet]
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
		}*/
	}
}
