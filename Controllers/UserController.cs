using MangaStore.Data;
using MangaStore.Enums;
using MangaStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaStore.Controllers;

public class UserController:Controller
{
    private readonly Context _context;
    public UserController(Context context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        int id = HttpContext.Session.GetInt32("account_id") ?? 0;
        User user= _context.Users.Include(u=>u.account).FirstOrDefault(u=>u.account_id==id);
        ViewData["provinces"] = Province.getArrayView();
        return View(user);
    }
}