using MangaStore.Data;
using MangaStore.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MangaStore.Controllers;

public class AdminHomeController:Controller
{
    private readonly Context _context;
    public AdminHomeController(Context context)
    {
        _context = context;
    }
    public IActionResult Index(DateTime? fromDate, DateTime? toDate,int? category)
    {
        ViewData["category"] = ProductCategory.getArrayView();
        if (category is null)
        {
            category = 0;
        }
        //kiểm tra nếu toDate là hôm nay thì 
        //cộng thêm 1 ngày
        if (toDate == DateTime.Today)
        {
            toDate = toDate.Value.AddDays(1);
        }
        //Lấy 10 sản phẩm có doanh thu cao nhất
        //bằng cách lấy tổng total_price của bảng OrderDetails
        //mà có sản phẩm có product.category = category
        //sắp xếp giảm dần và có order_date nằm trong khoảng từ fromDate đến toDate
        //và tham khảo từ đoạn code bên dưới lấy từ ngôn ngữ PHP trên framework Laravel
        /*if($category===0 && $toDate!==null && $fromDate!==null){
            $topProducts = DB::table('order_product')
                            ->join('products', 'products.id', '=', 'order_product.product_id')
                        ->join('orders', 'orders.id', '=', 'order_product.order_id')
                    ->select('products.*', DB::raw('SUM(order_product.total_price) as total_price'))
                ->whereBetween('orders.order_date', [$fromDate, $toDate])
                ->groupBy('products.name')
                        ->orderBy('total_price', 'desc')
                    ->limit(10)
                ->get();
        }*/
        var topProducts = _context.OrderDetails
            .Where(od => od.Order.order_date >= fromDate && od.Order.order_date <= toDate)
            .GroupBy(od => od.product_id)
            .Select(od => new
            {
                //Lấy ra tất cả thông tin của sản phẩm và truyền vào Product
                Product = _context.Products.Where(p => p.id == od.Key).FirstOrDefault(),
                TotalPrice = od.Sum(od => od.total_price)
            })
            .OrderByDescending(od => od.TotalPrice)
            .Take(10)
            .ToList();
        var product=topProducts[0].Product;
        return View();
    }
}
