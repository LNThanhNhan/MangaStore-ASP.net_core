using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using MangaStore.Data;
using MangaStore.Enums;
using MangaStore.Models;
using MangaStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MangaStore.Controllers;

public class OrderController:Controller
{
    private readonly  Context _context;
    private readonly IValidator<OrderViewModel> _validator;
    public OrderController(Context context,IValidator<OrderViewModel> validator)
    {
        _context = context;
        _validator = validator;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var orders = _context.Orders
            .Include(x => x.order_details)
            .ThenInclude(x => x.product)
            .OrderByDescending(x => x.order_date)
            .ToList();
        return View(orders);
    }
    
    [HttpGet]
    public IActionResult Checkout()
    {
        int id=HttpContext.Session.GetInt32("account_id")??0;
        var user=_context.Users
            .Include(u=>u.account)
            .Include(u=>u.cart)
            .ThenInclude(c=>c.cart_details)
            .ThenInclude(cd=>cd.product)
            .FirstOrDefault(u=>u.account_id==id);
        //Lấy ra tổng giá trị của giỏ hàng
        long total_price = user.cart.cart_details.Sum(cd => cd.product.price * cd.quantity);
        long cart_shipping_fee;
        if(user.province == Province.HANOI || user.province == Province.HOCHIMINH)
        {
            cart_shipping_fee = ShippingFee.HN_HCM;
        }
        else if (user.province is null || user.province == 0)
        {
            cart_shipping_fee = 0;
        }
        else
        {
            cart_shipping_fee = ShippingFee.OTHER;
        }
        ViewData["provinces"] =Province.getArrayView();
        ViewData["payments"] =OrderPaymentMethod.getArrayView();
        ViewData["shipping_fee"] =ShippingFee.getArray();
        ViewData["cart_details"] =user.cart.cart_details.ToList();
        ViewData["user"] =user;
        ViewData["total_price"] =total_price;
        ViewData["cart_shipping_fee"] =cart_shipping_fee;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Checkout(OrderViewModel orderViewModel)
    {
        ValidationResult result = _validator.Validate(orderViewModel);
        if (!result.IsValid)
        {
            ModelState.Clear();
            result.AddToModelState(this.ModelState);
            TempData["error"] = "Vui lòng điền đầy đủ thông tin";
            return RedirectToAction("Checkout");
        }
        int id=HttpContext.Session.GetInt32("account_id")??0;
        var user=_context.Users
            .Include(u=>u.account)
            .Include(u=>u.cart)
            .ThenInclude(c=>c.cart_details)
            .ThenInclude(cd=>cd.product)
            .FirstOrDefault(u=>u.account_id==id);
        //Thực hiện kiểm tra sản phẩm trong giỏ hàng có đủ số lượng để đặt hàng không
        //Nếu không đủ thì quay lại và thông báo lỗi bằng TempData
        foreach (var cart_detail in user.cart.cart_details)
        {
            var product = _context.Products.FirstOrDefault(p => p.id == cart_detail.product_id);
            if (product == null)
            {
                TempData["error"] = "Sản phẩm không tồn tại";
                return RedirectToAction("Checkout");
            }
            if (product.quantity < cart_detail.quantity)
            {
                TempData["error"] = "Số lượng tồn sản phẩm trong giỏ hàng không đủ";
                return RedirectToAction("Checkout");
            }
        }
        long total_order = user.cart.cart_details.Sum(cd => cd.product.price * cd.quantity);
        Order order = new Order();
        order.name = orderViewModel.name;
        order.email = orderViewModel.email;
        order.user_id = user.id;
        order.phone = orderViewModel.phone;
        order.address = orderViewModel.address;
        order.province = orderViewModel.province;
        order.status = OrderStatus.CHO_XAC_NHAN;
        order.payment_method = orderViewModel.payment_method;
        order.total_order = total_order;
        if(orderViewModel.province == Province.HANOI || orderViewModel.province == Province.HOCHIMINH)
        {
            order.delivery_fee = ShippingFee.HN_HCM;
        }
        else
        {
            order.delivery_fee = ShippingFee.OTHER;
        }
        order.total_price = total_order + order.delivery_fee;
        order.order_date = DateTime.Now;
        _context.Orders.Add(order);
        _context.SaveChanges();
        foreach (var item in user.cart.cart_details)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.order_id = order.id;
            orderDetail.product_id = item.product_id;
            orderDetail.quantity = item.quantity;
            orderDetail.price = item.product.price;
            orderDetail.total_price = item.product.price * item.quantity;
            _context.OrderDetails.Add(orderDetail);
            //lấy ra product và giảm số lượng
            var product = _context.Products.FirstOrDefault(p => p.id == item.product_id);
            product.quantity -= item.quantity;
            _context.SaveChanges();
        }
        //Sau đó xóa hết sản phẩm trong giỏ hàng
        _context.CartDetails.RemoveRange(user.cart.cart_details);
        _context.SaveChanges();
        TempData["success"] = "Đặt hàng thành công";
        return RedirectToAction("Index", "User");
    }
    
    [HttpPost]
    public IActionResult CancelOrder(int id)
    {
        var order = _context.Orders.FirstOrDefault(o => o.id == id);
        if (order == null)
        {
            TempData["error"] = "Đơn hàng không tồn tại";
            return RedirectToAction("Index", "User");
        }
        order.status = OrderStatus.DA_HUY;
        _context.SaveChanges();
        TempData["success"] = "Hủy đơn hàng thành công";
        return RedirectToAction("Index", "User");
    }
}