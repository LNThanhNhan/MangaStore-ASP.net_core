using MangaStore.Data;
using MangaStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaStore.Controllers;

public class SampleController:Controller
{
    public readonly Context _context;
    public SampleController(Context context)
    {
        _context = context;
    }
    
    public IActionResult Index(int id)
    {
        //Lấy ra product theo id
        var product = _context.Products.Include(s=>s.samples).FirstOrDefault(p=>p.id==id);
        //kiểm tra nếu không tồn tại sample thì tạo list mới
        if(product.samples==null)
        {
            product.samples = new List<Sample>();
        }
        ViewBag.product_id = product.id;
        return View(product.samples);
    }
    
    public IActionResult Add(int id, string image)
    {
        Sample sample = new Sample();
        sample.product_id = id;
        sample.image = image;
        _context.Sample.Add(sample);
        _context.SaveChanges();
        return RedirectToAction("Index", new {id = id});
    }
    
    public IActionResult DeleteLast(int id)
    {
        var product = _context.Products.Include(s=>s.samples).FirstOrDefault(p=>p.id==id);
        List<Sample> samples = product.samples.ToList();
        Sample sample = samples.Last();
        _context.Sample.Remove(sample);
        _context.SaveChanges();
        return RedirectToAction("Index", new {id = id});
    }
    
    public IActionResult DeleteAll(int id)
    {
        var product = _context.Products.Include(s=>s.samples).FirstOrDefault(p=>p.id==id);
        List<Sample> samples = product.samples.ToList();
        foreach (var sample in samples)
        {
            _context.Sample.Remove(sample);
        }
        _context.SaveChanges();
        return RedirectToAction("Index", new {id = id});
    }
}