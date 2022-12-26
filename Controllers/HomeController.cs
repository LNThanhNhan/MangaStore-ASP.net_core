using Microsoft.AspNetCore.Mvc;
using MangaStore.Data;
using MangaStore.ViewModels;
using AutoMapper;
using MangaStore.Enums;
using MangaStore.Models;
using Microsoft.EntityFrameworkCore;
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
		
		//Làm hàm trà về ProductViewModel để hiển thị chi tiết sản phẩm
		public IActionResult Detail(string slug)
		{
			var product = _context.Products
				.Include(s=>s.samples)
				.Where(p => p.slug == slug)
				.FirstOrDefault();
			if (product == null)
			{
				return NotFound();
			}
			var productViewModel = _mapper.Map<ProductViewModel>(product);
			//Lấy ra 3 sản phẩm có cùng tác giả nhưng không cùng id
			var sameAuthor = new List<ProductViewModel>();
			var sameAuthorData = _context.Products
				.Where(p => p.author == product.author && p.id != product.id)
				.OrderByDescending(p => p.id)
				.Take(3)
				.ToList();
			sameAuthorData.ForEach(
				pd => sameAuthor.Add(_mapper.Map<ProductViewModel>(pd))
			); 
			//Lấy ra 5 sản phẩm có cùng thể loại nhưng không cùng id
			var sameCategory = new List<ProductViewModel>();
			var sameCategoryData = _context.Products
				.Where(p => p.category == product.category && p.id != product.id)
				.OrderByDescending(p => p.id)
				.Take(5)
				.ToList();
			sameCategoryData.ForEach(
				pd => sameCategory.Add(_mapper.Map<ProductViewModel>(pd))
			);
			//Kiểm tra xem sản phẩm có xem thử hay không
			if(product.samples.Count != 0)
			{
				ViewBag.Sample = "Có";
			}
			else
			{
				ViewBag.Sample = "Không";
			}
			ViewData["sameAuthor"] = sameAuthor;
			ViewData["sameCategory"] = sameCategory;
			return View(productViewModel);
		}

        [HttpGet]
        public IActionResult Search(string?q, int? page, SearchFilterViewModel? filterViewModel)
        {
            var list = new List<ProductViewModel>();

            var products = _context.Products.ToList();
			if (!string.IsNullOrEmpty(q))
			{
				products=products.Where(p => p.name.Contains(q, StringComparison.OrdinalIgnoreCase)).ToList();
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
            ViewData["list"] = list.ToPagedList(pageNumber, 12);
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
            ViewData["list"] = list.ToPagedList(pageNumber, 12);
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
	        ViewData["list"] = list.ToPagedList(pageNumber, 12);
	        ViewData["q"] = q;
			ViewBag.Action = "HotDeal";
			return View("Search",filterViewModel);
        }
        
        [HttpGet]
        public IActionResult Category(int category,string?q, int? page, SearchFilterViewModel? filterViewModel)
        {
	        //Truy vấn sản phẩm theo category
	        var list = new List<ProductViewModel>();
	        var products = _context.Products.ToList()
		        .Where(p => p.quantity >0 && p.category == category)
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
	        ViewData["list"] = list.ToPagedList(pageNumber, 12);
	        ViewData["q"] = q;
	        ViewBag.Action = "Category";
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
	        ViewData["list"] = list.ToPagedList(pageNumber, 12);
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
			//Nếu không chọn category nào thì lọc theo giá
			if (filterViewModel.Categories.All(c => c.IsChecked == false))
			{
				products.ForEach(pd => list.Add(_mapper.Map<ProductViewModel>(pd)));
				list = list.Where(p => p.price <= filterViewModel.max_price
				                       && p.price >= filterViewModel.min_price).ToList();
			}
			else
			{
				//Check điều kiện của giá
				if (filterViewModel.min_price<0 )
				{
					filterViewModel.min_price = 0;
				}
				if(filterViewModel.max_price==0 ||filterViewModel.max_price<0)
				{
					filterViewModel.max_price = 1000000;
				}
				if(filterViewModel.min_price>filterViewModel.max_price)
				{
					int temp = filterViewModel.min_price;
					filterViewModel.min_price = filterViewModel.max_price;
					filterViewModel.max_price = temp;
				}
				//Tạo filter nếu chưa có và thực hiện filter
				for (int i = 0; i < filterViewModel.Categories.Count; i++)
				{
					if (filterViewModel.Categories[i].IsChecked)
					{
						products.ForEach(pd =>
						{
							if (pd.category == filterViewModel.Categories[i].Value
							    && pd.price <= filterViewModel.max_price
							    && pd.price >= filterViewModel.min_price)
							{
								list.Add(_mapper.Map<ProductViewModel>(pd));
							}
						});
					}
				}
			}
			//Code phân trang
			var pageNumber = page ?? 1;
			ViewData["list"] = list.ToPagedList(pageNumber, 12);
			ViewData["q"] = q;
			ViewBag.Action = "Filter";
			return View("Search",filterViewModel);
		}
		
		[HttpGet]
		public IActionResult Sample(int id)
		{
			//lấy ra product có id tương ứng
			var product = _context.Products.Include(p=>p.samples).FirstOrDefault(p => p.id == id);
			//kiểm tra nếu không tồn tại sample thì tạo list mới
			if(product.samples==null)
			{
				product.samples = new List<Sample>();
			}
			ViewBag.slug = product.slug;
			return View(product.samples);
		}
	}
}