using Microsoft.AspNetCore.Mvc;
using MangaStore.Data;
using MangaStore.ViewModels;
using AutoMapper;
using MangaStore.Enums;
using X.PagedList;

namespace MangaStore.Controllers
{
	public class HomeController : Controller
	{
		private readonly Context _context;
		private readonly IMapper _mapper;
		public HomeController(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		
		public IActionResult Index()
		{
			//Lấy ra 10 sản phẩm mới nhất mà có số lượng lớn hơn 0
			//rồi chuyển sang list ProductViewModel để hiển thị
			var list = new List<ProductViewModel>();
			var products = _context.Products
				.Where(p => p.quantity > 0)
				.OrderByDescending(p => p.id)
				.Take(10)
				.ToList();
			products.ForEach
			(
				pd => list.Add(_mapper.Map<ProductViewModel>(pd))
			);
			ViewData["list"] = list;
			return View();
		}

        [HttpGet]
        public IActionResult Search(string?q, int? page, SearchFilterViewModel? filterViewModel)
        {
            var list = new List<ProductViewModel>();

            var products = _context.Products.ToList();
			if (!string.IsNullOrEmpty(q))
			{
				products.Where(p => p.name.Contains(q, StringComparison.OrdinalIgnoreCase)).ToList();
			}
            if (products.Count == 0)
            {
                return NotFound();
            }
            products.ForEach(pd => list.Add(_mapper.Map<ProductViewModel>(pd)));
            //Tạo filter nếu chưa có và thực hiện filter
            if (filterViewModel is null)
            {
	            filterViewModel = new SearchFilterViewModel();
            }
            filterViewModel.Categories=ProductCategory.getArrayView().Select(
	            item => new CheckBoxItem
	            {
		            Value = item.Value,
		            Display = item.Key,
		            IsChecked = false
	            }
            ).ToList();
            filterViewModel.min_price = 0;
            filterViewModel.max_price = 0;
            //Code phân trang
            var pageNumber = page ?? 1;
            ViewData["list"] = list.ToPagedList(pageNumber, 16);
            ViewData["q"] = q;
			ViewBag.Action = "Search";
			return View(filterViewModel);
        }

		[HttpGet]
        [Route("/Home/Author/{slug}")]
        public IActionResult Author(string slug,string?q, int? page, SearchFilterViewModel? filterViewModel)
        {
			//Lấy ra danh sách sản phẩm có author_slug chứa chuỗi slug
			var list = new List<ProductViewModel>();
			var products = _context.Products.ToList()
				.Where(p => p.author_slug == slug)
				.ToList();
            if (products.Count == 0)
            {
                return NotFound();
            }
            products.ForEach(pd => list.Add(_mapper.Map<ProductViewModel>(pd)));
            //Tạo filter nếu chưa có và thực hiện filter
            if (filterViewModel is null)
            {
	            filterViewModel = new SearchFilterViewModel();
            }
            filterViewModel.Categories=ProductCategory.getArrayView().Select(
                item => new CheckBoxItem
                {
                    Value = item.Value,
                    Display = item.Key,
                    IsChecked = false
                }
            ).ToList();
            filterViewModel.min_price = 0;
            filterViewModel.max_price = 0;
            //Code phân trang
            var pageNumber = page ?? 1;
            ViewData["list"] = list.ToPagedList(pageNumber, 16);
            ViewData["q"] = q;
			ViewBag.Action = "Author";
			ViewBag.Slug = slug;
			return View("Search",filterViewModel);
        }

        [HttpGet]
        public IActionResult HotDeal(string?q, int? page, SearchFilterViewModel? filterViewModel)
        {
			//Truy vấn sản phẩm theo giảm dần discount_rate
			var list = new List<ProductViewModel>();
	        var products = _context.Products.ToList()
		        .Where(p => p.quantity >0)
				.OrderByDescending(p => p.discount_rate)
				.ToList();
	        products.ForEach(pd => list.Add(_mapper.Map<ProductViewModel>(pd)));
			//Tạo filter nếu chưa có và thực hiện filter
			if (filterViewModel is null)
			{
				filterViewModel = new SearchFilterViewModel();
			}
			filterViewModel.Categories = new List<CheckBoxItem>();
	        filterViewModel.Categories=ProductCategory.getArrayView().Select(
		        item => new CheckBoxItem
		        {
			        Value = item.Value,
			        Display = item.Key,
			        IsChecked = false
		        }
	        ).ToList();
	        filterViewModel.min_price = 0;
	        filterViewModel.max_price = 0;
	        //Code phân trang
	        var pageNumber = page ?? 1;
	        ViewData["list"] = list.ToPagedList(pageNumber, 16);
	        ViewData["q"] = q;
			ViewBag.Action = "HotDeal";
			return View("Search",filterViewModel);
        }

        [HttpGet]
        [Route("/Home/Collection/{slug?}")]
        public IActionResult Collection(string? slug,string?q, int? page, SearchFilterViewModel? filterViewModel)
        {
	        //Lấy ra danh sách sản phẩm có author_slug chứa chuỗi slug
	        var list = new List<ProductViewModel>();
	        var products= _context.Products.ToList();
            if (!string.IsNullOrEmpty(slug))
	        {
		        products = products
			        .Where(p => p.collection_slug == slug)
			        .ToList();
	        }
	        else
	        {
		        products = products
			        .Where(p => p.collection_slug is not null)
			        .ToList();
	        }
	        if (products.Count == 0)
	        {
		        return NotFound();
	        }
	        products.ForEach(pd => list.Add(_mapper.Map<ProductViewModel>(pd)));
	        //Tạo filter nếu chưa có và thực hiện filter
	        if (filterViewModel is null)
	        {
		        filterViewModel = new SearchFilterViewModel();
	        }
	        filterViewModel.Categories=ProductCategory.getArrayView().Select(
		        item => new CheckBoxItem
		        {
			        Value = item.Value,
			        Display = item.Key,
			        IsChecked = false
		        }
	        ).ToList();
	        filterViewModel.min_price = 0;
	        filterViewModel.max_price = 0;
	        //Code phân trang
	        var pageNumber = page ?? 1;
	        ViewData["list"] = list.ToPagedList(pageNumber, 16);
	        ViewData["q"] = q;
			ViewBag.Action = "Collection";
			if (slug is not null)
			{
				ViewBag.Slug = slug;
			}
			else
			{
				ViewBag.Slug = "";
			}
			return View("Search",filterViewModel);
        }

		[HttpGet]
		public IActionResult Filter(string?q, int? page, SearchFilterViewModel filterViewModel)
		{
			var list = new List<ProductViewModel>();
			var products = _context.Products.ToList()
				.Where(p => p.quantity >0)
				.ToList();
			products.ForEach(pd => list.Add(_mapper.Map<ProductViewModel>(pd)));
			//Tạo filter nếu chưa có và thực hiện filter
			for (int i = 0; i < filterViewModel.Categories.Count; i++)
			{
				if (filterViewModel.Categories[i].IsChecked)
				{
					list = list.Where(p => p.category == filterViewModel.Categories[i].Value
			                       && p.price <= filterViewModel.max_price
			                       && p.price >= filterViewModel.min_price).ToList();
				}
			}
			//Code phân trang
			var pageNumber = page ?? 1;
			ViewData["list"] = list.ToPagedList(pageNumber, 16);
			ViewData["q"] = q;
			ViewBag.Action = "Filter";
			return View("Search",filterViewModel);
		}
	}
}