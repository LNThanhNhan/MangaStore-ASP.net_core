using System.ComponentModel.DataAnnotations;

namespace MangaStore.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Email không được để trống")]
		[EmailAddress(ErrorMessage = "Email không đúng định dạng")]
		[Display(Name = "email")]
		public string email { get; set; }

		[Required(ErrorMessage = "Mật khẩu không được để trống")]
		[Display(Name = "Mật khẩu")]
		public string password { get; set; }

		public string recaptcha { get; set; }
	}
}
