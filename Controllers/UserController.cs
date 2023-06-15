using MangaStore.Data;
using MangaStore.Enums;
using MangaStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaStore.Controllers;

public class UserController:Controller
{
    private readonly Context _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserController(Context context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public IActionResult Index()
    {
        int id = _httpContextAccessor!.HttpContext!.Session.GetInt32("account_id") ?? 0;
        User user= _context.Users.Include(u=>u.account).FirstOrDefault(u=>u.account_id==id);
        ViewData["provinces"] = Province.getArrayView();
        return View(user);
    }
}