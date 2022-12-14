using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using MangaStore.Data;
using MangaStore.Helpers;
using MangaStore.Models;
using MangaStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MangaStore.Controllers
{
	public class AuthController : Controller
	{
		private readonly Context _context;
		private readonly IValidator<RegisterViewModel> _registerView;
		public AuthController(Context context, IValidator<RegisterViewModel> registerView)
		{
			_context = context;
			_registerView = registerView;
		}
		
		[HttpGet]
		[Route("login")]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("login")]
		public IActionResult Login(LoginViewModel loginView)
		{
			if (ModelState.IsValid)
			{
				var account = _context.Accounts.FirstOrDefault
					(a => a.email.Equals(loginView.email));
				if (account is not null)
				{
					if (Helper.verify_password(loginView.password,account.password))
					{
						//Khởi tạo session mới và gán giá trị id của account vào session
						HttpContext.Session.SetInt32("id", account.id);
						ViewBag.name = account.user.name;
						ViewBag.id = HttpContext.Session.GetInt32("id");
						return View("Success");
					}
					//thêm error vào model state và trả lại view
					ModelState.AddModelError("email", "Email hoặc mật khẩu không hợp lệ");
					return View(loginView);
				}
				//thêm error vào model state và trả lại view
				ModelState.AddModelError("email", "Email hoặc mật khẩu không hợp lệ");
				return View(loginView);
			}
			return View(loginView);
		}

		[HttpGet]
		[Route("register")]
		public IActionResult Register()
		{
			return View("Register");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("register")]
		public IActionResult Register(RegisterViewModel registerView)
		{
			ValidationResult result = _registerView.Validate(registerView);
			if (result.IsValid)
			{
				//Tạo mới account
				var account_db = new Account
				{
					username = registerView.username,
					email = registerView.email,
					password = Helper.hash_password(registerView.password),
					role=0
				};
				_context.Accounts.Add(account_db);
				_context.SaveChanges();
				//lấy ra account từ db có email giống với account
				//var account_db = _context.Accounts.FirstOrDefault(a => a.email.Equals(account.email));
				var user = new User
				{
					name=registerView.name,
					gender = registerView.gender,
					account_id = account_db.id,
					account = account_db
				};
				_context.Users.Add(user);
				_context.SaveChanges();
				//Khởi tạo session mới và gán giá trị id của account vào session
				HttpContext.Session.SetInt32("id", account_db.id);
				ViewBag.name = user.name;
				ViewBag.id = HttpContext.Session.GetInt32("id");
				return View("Success");
			}
			ModelState.Clear();
			result.AddToModelState(this.ModelState);
			return View(registerView);
		}

		[HttpGet]
		[Route("test")]
		public IActionResult Test()
		{
			var user= _context.Users.FirstOrDefault(a=>a.gender==1);
			var account = user.account;
			ViewBag.name = account.username;
			ViewBag.id = account.id;
			return View("Success");
		}
	}
}
