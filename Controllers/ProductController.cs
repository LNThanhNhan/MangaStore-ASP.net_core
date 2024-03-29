﻿using Microsoft.AspNetCore.Mvc;
using MangaStore.Data;
using MangaStore.Models;
using MangaStore.Enums;
using MangaStore.ViewModels;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using X.PagedList;
using MangaStore.Services.Firebase.StorageService;
using MangaStore.Helpers;
using Newtonsoft.Json.Linq;

namespace MangaStore.Controllers
{
    public class ProductController : Controller
    {
		private readonly Context _context;
        private readonly IMapper _mapper;
		private readonly IValidator<ProductViewModel> _viewValidator;
        private readonly IValidator<EditProductViewModel> _editViewlValidator;
        public ProductController(Context context, IMapper mapper, IValidator<ProductViewModel> viewValidator, IValidator<EditProductViewModel> editViewlValidator)
        {
            _context = context;
            _mapper = mapper;
            _viewValidator = viewValidator;
            _editViewlValidator = editViewlValidator;
        }
		
        [HttpGet]
		public IActionResult Index(int? page, string? q)
		{
			//Code thường
			var list = new List<ProductViewModel>();
			_context.Products.OrderByDescending(p=>p.id).ToList().ForEach
			(
				pd => list.Add(_mapper.Map<ProductViewModel>(pd))
			);
			//Code query
			if (!string.IsNullOrEmpty(q))
			{
				list = list.Where(p => p.name.Contains(q,StringComparison.OrdinalIgnoreCase)).ToList();
			}
			//Code phân trang
			var pageNumber = page ?? 1;
			ViewBag.Products = list.ToPagedList(pageNumber, 10);
			ViewBag.q = q;
			return View();
		}	
       
		[HttpGet]
		public IActionResult Create()
		{
			ViewData["TheLoai"] = ProductCategory.getArrayView();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductViewModel product)
		{
			ValidationResult result = _viewValidator.Validate(product);
			if (result.IsValid)
            {
                Product newProduct = _mapper.Map<Product>(product);
                JObject imageUploadResponse = await StorageService.UploadImage(product.image_file);
                newProduct.image_uuid = imageUploadResponse.SelectToken("data.Id")!.ToString();
				newProduct.image = imageUploadResponse.SelectToken("data.Url")!.ToString();
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                TempData["success"] = "Thêm thành công";
                return RedirectToAction("Index");
            }
            ModelState.Clear();
            result.AddToModelState(this.ModelState);
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
            EditProductViewModel editViewModel = _mapper.Map<EditProductViewModel>(product);
            ViewData["TheLoai"] = ProductCategory.getArrayView();
			return View(editViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditProductViewModel product)
		{
			ValidationResult result = _editViewlValidator.Validate(product);
			if (ModelState.IsValid)
			{
                Product editProduct = _mapper.Map<Product>(product);
                JObject imageUploadResponse = await StorageService.UpdateImage(product.image_file, product.image_uuid);
                editProduct.image_uuid = imageUploadResponse.SelectToken("data.Id")!.ToString();
                editProduct.image = imageUploadResponse.SelectToken("data.Url")!.ToString();
                _context.Products.Update(editProduct);
				_context.SaveChanges();
				TempData["success"] = "Sửa thành công";
				return RedirectToAction("Index");
			}
			//ModelState.Clear();
			result.AddToModelState(this.ModelState);
			return View(product);
		}

		//delete
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id)
		{
			var product = _context.Products.Find(id);
			if (product == null)
			{
				return NotFound();
			}
            await StorageService.DeleteImage(product.image_uuid);
			_context.Products.Remove(product);
			_context.SaveChanges();
			TempData["success"] = "Xóa thành công";
			return RedirectToAction("Index");
		}
	}
}
