using MangaStore.Data;
using MangaStore.Enums;
using MangaStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaStore.Controllers;

public class AdminOrderController:Controller
{
    public readonly Context _context;
    public AdminOrderController(Context context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Index(string? q)
    {
        //tìm kiếm đơn hàn có mã đơn hàng hay số điện thoại bằng q
        //nếu so sánh với mã thì chuyển kiểu q sang int
        List<Order> orders=new List<Order>();
        if (!string.IsNullOrEmpty(q))
        {
            orders= _context.Orders
                .Where(x => x.id.ToString().Contains(q) || x.phone.Contains(q))
                .OrderByDescending(x => x.id)
                .ToList();
        }
        else
        {
             orders = _context.Orders
                .OrderByDescending(x => x.id)
                .ToList();
        }
        ViewBag.q = q;
        ViewBag.orders = orders;
        return View();
    }
    
    [HttpGet]
    public IActionResult Detail(int id)
    {
        var order = _context.Orders
            .Include(o=>o.order_details)
            .ThenInclude(od=>od.product)
            .FirstOrDefault(x => x.id == id);
        ViewBag.order_status = OrderStatus.getArrayView();
        return View(order);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(int id, int status)
    {
        var order = _context.Orders.FirstOrDefault(x => x.id == id);
        order.status = status;
        if (status == OrderStatus.DA_GIAO_HANG)
        {
            order.delivery_date = DateTime.Now;
        }
        _context.SaveChanges();
        TempData["success"] = "Cập nhật thành công";
        return RedirectToAction("Index");
    }
}