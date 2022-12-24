using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using MangaStore.Data;
using MangaStore.Enums;
using MangaStore.Helpers;
using MangaStore.Models;
using MangaStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
		[Route("login",Name = "login")]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("login")]
		public async Task<IActionResult> Login(LoginViewModel loginView)
		{
			if (ModelState.IsValid)
			{
				var account = _context.Accounts.FirstOrDefault
					(a => a.email.Equals(loginView.email));
				if (account is not null)
				{
					if (Helper.verify_password(loginView.password,account.password))
					{
						if (await is_recaptcha_valid(loginView.recaptcha))
						{
							//Khởi tạo session mới và gán giá trị id của account vào session
							HttpContext.Session.SetInt32("account_id", account.id);
							if (account.role == AccountRole.ADMIN)
							{
								HttpContext.Session.SetInt32("role", AccountRole.ADMIN);
							}
							else if (account.role == AccountRole.USER)
							{
								HttpContext.Session.SetInt32("role", AccountRole.USER);
								RedirectToAction("Index", "Home");
							}

							ViewBag.name = account.username;
							//ViewBag.id = HttpContext.Session.GetInt32("account_id");
							return RedirectToAction("Index", "User");
						}
						//thêm error vào model state và trả lại view
						ModelState.AddModelError("recaptcha", "Recaptcha không hợp lệ");
						return View(loginView);
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
				//Tạo user mới từ account
				var user = new User
				{
					name=registerView.name,
					gender = registerView.gender,
					account_id = account_db.id
				};
				_context.Users.Add(user);
				_context.SaveChanges();
				//Tạo cart mới từ user
				var cart = new Cart
				{
					user_id = user.id,
				};
				_context.Carts.Add(cart);
				_context.SaveChanges();
				//Khởi tạo session mới và gán giá trị id của account vào session
				HttpContext.Session.SetInt32("account_id", account_db.id);
				ViewBag.name = user.name;
				ViewBag.id = HttpContext.Session.GetInt32("account_id");
				return RedirectToAction("Index", "Home");
			}
			ModelState.Clear();
			result.AddToModelState(this.ModelState);
			return View(registerView);
		}
		
		[HttpPost]
		[Route("logout")]
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
		}
		
		//Làm hàm xử lý recaptcha google với tham số truyền vào là
		//google recaptcha token
		[NonAction]
		public async Task<bool> is_recaptcha_valid(string response)
		{
			try
			{
				var secret = "6Lf_X6IjAAAAALDrxlO4-z7BTx85SCXqC_HpWih6";
				using (var client = new HttpClient())
				{
					var values = new Dictionary<string, string>
					{
						{ "secret", secret },
						{ "response", response },
						//Lấy ra địa chỉ ip của người dùng
						{ "remoteip", HttpContext.Connection.RemoteIpAddress.ToString() }
					};
					var content=new FormUrlEncodedContent(values);
					var verifyResponse =await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
					var captchaResponse = await verifyResponse.Content.ReadAsStringAsync();
					var captchaResult = JsonConvert.DeserializeObject<RecaptchaResponse>(captchaResponse);
					return captchaResult.Success && captchaResult.Score > 0.5;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return  false;
			}
		}
	}
}
