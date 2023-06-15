using MangaStore.Data;
using MangaStore.Models;
using MangaStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MangaStore.Controllers
{
    public class CartController : Controller
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartController(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public IActionResult AddToCart(IFormCollection form)
        {
            int accountID = (int)_httpContextAccessor!.HttpContext!.Session.GetInt32("account_id");  
            int productId = int.Parse(form["productId"]);
            int quantity = int.Parse(form["quantity"]);
            var product = _context.Products.FirstOrDefault(p=>p.id==productId);
            Response response = new Response();
            if(product==null)
            {
                response.success = false;
                response.message = "Sản phẩm không tồn tại";
                return Json(response);
            }
            if(product.quantity<quantity)
            {
                response.success = false;
                response.message = "Số lượng không đủ";
                return Json(response);
            }
            User user = _context!.Users
                .Include(user=>user.cart)
                .ThenInclude(cart=>cart.cart_details.Where(cart_detail=>cart_detail.product_id==productId))
                .FirstOrDefault(u=>u.account_id==accountID);
            //nếu sản phẩm đã có trong giỏ hàng thì cộng thêm với số lượng sản phẩm trong giỏ hàng
            //nếu không thì thêm sản phẩm vào giỏ hàng,
            Cart cart = user.cart;
            CartDetail cart_details = cart.cart_details.FirstOrDefault(cart=>cart.product_id==productId);
            if(cart_details is not null)
            {
                cart_details.quantity += quantity;
                _context.SaveChanges();
            }
            else
            {
                CartDetail cart_detail = new CartDetail();
                cart_detail.product_id = productId;
                cart_detail.quantity = quantity;
                cart_detail.cart_id = cart.id;
                
                _context.CartDetails.Add(cart_detail);
                _context.SaveChanges();
            }
            response.success = true;
            response.message = "Thêm vào giỏ hàng thành công";
            //làm mảng int chứa số lượng sản phẩm khác nhau trong giỏ hàng
            //từ có cart_id trong bảng cart_details bằng cart.id trong bảng cart
            int[] cart_detail_quantity = _context.CartDetails
                .Where(cart_detail=>cart_detail.cart_id==cart.id)
                .Select(cart_detail=>cart_detail.quantity)
                .ToArray();
            //int[] cart_detail_quantity = new int[cart.cart_details.Count];
            response.data =JsonConvert.SerializeObject(cart_detail_quantity);
            return Json(response);
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            int accountID = (int)_httpContextAccessor!.HttpContext!.Session.GetInt32("account_id");
            User user = _context.Users
                .Include(user=>user.cart)
                .ThenInclude(cart=>cart.cart_details)
                .ThenInclude(cart_detail=>cart_detail.product)
                .FirstOrDefault(u=>u.account_id==accountID);
            long total = user.cart.cart_details.Sum(cart_detail=>cart_detail.product.price*cart_detail.quantity);
            Cart cart = user.cart;
            List<CartDetail> cartList = cart.cart_details.ToList();
            ViewBag.cart_total=total;
            return View(cartList);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Cập nhật số lượng của từng sản phẩm trong giỏ hàng
        public IActionResult UpdateCart(int[]arr)
        {
            int accountID = (int)_httpContextAccessor!.HttpContext!.Session.GetInt32("account_id");
            User user = _context!.Users
                .Include(user=>user.cart)
                .ThenInclude(cart=>cart.cart_details)
                .ThenInclude(cart_detail=>cart_detail.product)
                .FirstOrDefault(u=>u.account_id==accountID);
            Cart cart = user.cart;
            CartDetail[] cart_details = cart.cart_details.ToArray();
            for(int i=0;i<cart_details.Length;i++)
            {
                cart_details[i].quantity = arr[i];
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        //hàm DeleteCartItem dùng để xóa 1 sản phẩm trong giỏ hàng
        public IActionResult DeleteCartItem(int id)
        {
            int accountID = (int)_httpContextAccessor!.HttpContext!.Session.GetInt32("account_id");
            User user = _context.Users
                .Include(user=>user.cart)
                .ThenInclude(cart=>cart.cart_details)
                .ThenInclude(cart_detail=>cart_detail.product)
                .FirstOrDefault(u=>u.account_id==accountID);
            Cart cart = user.cart;
            CartDetail cart_detail = _context.CartDetails.FirstOrDefault(cart_detail=>cart_detail.product_id==id);
            _context.CartDetails.Remove(cart_detail);
            _context.SaveChanges();
            return RedirectToAction("Index","Cart");
        }
    }
}