using MangaStore.Data;
using MangaStore.Enums;
using MangaStore.Helpers;
using MangaStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MangaStore.Controllers;

public class AdminHomeController:Controller
{
    private readonly Context _context;
    public AdminHomeController(Context context)
    {
        _context = context;
    }
    public IActionResult Index(AdminHomeViewModel? vm)
    {
        if (vm is null)
        {
            vm = new AdminHomeViewModel();
        }
        //Lấy ra doanh thu hôm nay bằng cách lấy ra tổng tiền của các đơn hàng có delivery_date là ngày hôm nay
        var today = DateTime.Today.Date;
        //chỉ so sánh ngày tháng năm
        var revenueToday = _context.Orders.Where(x => (DateTime)x.delivery_date.Value.Date== today).Sum(x => x.total_price);
        //Láy ra số đơn hàng đã đặt trong ngày hôm nay
        var orderCreatedToday = _context.Orders.Where(x => x.order_date.Date == today).Count();
        //Lấy ra số sản phẩm có số lượng tồn kho nhỏ hơn 100
        var productOutOfStock = _context.Products.Where(x => x.quantity < 100).Count();
        //Lấy ra số đơn hàng đang chờ xác nhận
        var orderProcessing = _context.Orders.Where(x => x.status == OrderStatus.CHO_XAC_NHAN).Count();
        if (vm.category is null)
        {
            vm.category = 0;
        }
        //kiểm tra nếu toDate là hôm nay thì 
        //cộng thêm 1 ngày
        if (vm.toDate !=null &&vm.toDate.Value.Date == today)
        {
            vm.toDate = vm.toDate.Value.AddDays(1);
        }
        //Nếu fromDate và toDate không có giá trị thì khởi tạo
        //với fromDate là ngày đầu tiên trong năm
        //với toDate là ngày mai
        if (vm.fromDate is null && vm.toDate is null)
        {
            vm.fromDate = new DateTime(today.Year, 1, 1);
            vm.toDate = today.AddDays(1);
        }
        //Lấy 10 sản phẩm có doanh thu cao nhất
        //bằng cách lấy tổng total_price của bảng OrderDetails
        //mà có sản phẩm có product.category = category
        //nếu category = 0 thì lấy tất cả sản phẩm
        //sắp xếp giảm dần và có order_date nằm trong khoảng từ fromDate đến toDate
        var topProducts = _context.OrderDetails
            .Where(od => od.Order.order_date.Date >= vm.fromDate.Value.Date && od.Order.order_date.Date <= vm.toDate.Value.Date)
            .Where(vm.category == 0 ? od => true : od => od.product.category == vm.category)
            .GroupBy(od => od.product_id)
            .Select(od => new Statistic
            {
                //Lấy ra tất cả thông tin của sản phẩm và truyền vào Product
                Product = _context.Products.Where(p => p.id == od.Key).FirstOrDefault(),
                TotalPrice = od.Sum(od => od.total_price)
            })
            .OrderByDescending(od => od.TotalPrice)
            .Take(10)
            .ToList();
        ViewBag.arrCategory = ProductCategory.getArrayView();
        ViewBag.category = vm.category;
        ViewBag.fromDate = vm.fromDate;
        ViewBag.toDate = vm.toDate;
        ViewBag.revenueToday = revenueToday;
        ViewBag.orderCreatedToday = orderCreatedToday;
        ViewBag.productOutOfStock = productOutOfStock;
        ViewBag.orderProcessing = orderProcessing;
        ViewBag.topProducts = topProducts;
        return View(vm);
    }
}
