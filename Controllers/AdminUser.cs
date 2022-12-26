using MangaStore.Data;
using MangaStore.Enums;
using MangaStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaStore.Controllers
{
    public class AdminUser:Controller
    {
        public readonly Context _context;
        public AdminUser(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<User> users = _context.Users.Include(u=>u.account).ToList();
            return View(users);
        }
        
        public IActionResult Detail(int id)
        {
            User user = _context.Users.Include(u=>u.account).FirstOrDefault(u=>u.id==id);
            return View(user);
        }
        
        public IActionResult Delete(int id)
        {
            User user = _context.Users
                .Include(u=>u.account)
                .Include(u=>u.orders)
                .FirstOrDefault(u=>u.id==id);
            //Kiểm tra nếu người dùng đang có đơn hàng 
            //ở trạng thái cho xác nhận thì không cho xóa
            if(user.orders.Any(o=>o.status==OrderStatus.CHO_XAC_NHAN || o.status==OrderStatus.DANG_GIAO_HANG))
            {
                TempData["error"] = "Không thể xóa người dùng này vì đang có đơn hàng đang chờ xác nhận hoặc đang giao hàng";
                return RedirectToAction("Index");
            }
            _context.Users.Remove(user);
            _context.Accounts.Remove(user.account);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}