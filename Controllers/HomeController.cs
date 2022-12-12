using MangaStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
        [Route("{type}/{q}")]
        public IActionResult Search(string type,string q, int? page, SearchFilterViewModel? filterViewModel)
        {
            var list = new List<ProductViewModel>();
            //Search theo từng loại search
            if (type == "search")
            {
                //Lấy ra danh sách sản phẩm có tên chứa chuỗi q
                var products = _context.Products
                    .Where(p => p.name.Contains(q, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                if (products.Count == 0)
                {
                    return NotFound();
                }
                products.ForEach(pd => list.Add(_mapper.Map<ProductViewModel>(pd)));
            }
            else if(type=="author")
            {
                //Lấy ra danh sách sản phẩm có author_slug chứa chuỗi q
                var products = _context.Products
                    .Where(p => p.author_slug.Contains(q, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                if (products.Count == 0)
                {
                    return NotFound();
                }
                products.ForEach(pd => list.Add(_mapper.Map<ProductViewModel>(pd)));
            }
            else if(type=="collection" && !string.IsNullOrEmpty(q))
            {
                //Lấy ra danh sách sản phẩm có collection_slug chứa chuỗi q
                var products = _context.Products
                    .Where(p => p.collection_slug.Contains(q, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                if (products.Count == 0)
                {
                    return NotFound();
                }
                products.ForEach(pd => list.Add(_mapper.Map<ProductViewModel>(pd)));
            }
            else if(type=="collection" && string.IsNullOrEmpty(q))
            {
                //Lấy ra danh sách sản phẩm có collection
                var products = _context.Products
                    .Where(p => !string.IsNullOrEmpty(p.collection))
                    .ToList();
                if (products.Count == 0)
                {
                    return NotFound();
                }
                products.ForEach(pd => list.Add(_mapper.Map<ProductViewModel>(pd)));
            }
            else if(type=="hot-deal")
            {
                //Lấy ra danh sách sản phẩm có discount_rate giảm dần
                var products = _context.Products
                    .Where(p => !string.IsNullOrEmpty(p.collection))
                    .ToList();
                if (products.Count == 0)
                {
                    return NotFound();
                }
                products.ForEach(pd => list.Add(_mapper.Map<ProductViewModel>(pd)));
            }
            //Tạo filter nếu chưa có và thực hiện filter
            if (filterViewModel == null)
            {
                SearchFilterViewModel filter = new SearchFilterViewModel();
                filter.Categories = new List<CheckBoxItem>();
                filter.Categories=ProductCategory.getArrayView().Select(
                    item => new CheckBoxItem
                    {
                        Value = item.Value,
                        Display = item.Key,
                        IsChecked = false
                    }
                ).ToList();
                filter.min_price = 0;
                filter.max_price = 0;
            }
            else
            {
                for (int i = 0; i < filterViewModel.Categories.Count; i++)
                {
                    if (filterViewModel.Categories[i].IsChecked)
                    {
                        list = list.Where(p => p.category == filterViewModel.Categories[i].Value 
                                       &&p.price<=filterViewModel.max_price
                                       &&p.price>=filterViewModel.min_price).ToList();
                    }
                }
                if (list.Count == 0)
                {
                    return NotFound();
                }
            }
            //Code phân trang
            var pageNumber = page ?? 1;
            ViewData["list"] = list.ToPagedList(pageNumber, 16);
            ViewData["q"] = q;
            ViewData["type"] = type;
            return View(filterViewModel);
        }
    }
}