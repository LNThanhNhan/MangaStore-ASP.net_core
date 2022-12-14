using System.ComponentModel;

namespace MangaStore.ViewModels
{
	public class RegisterViewModel
	{
		[DisplayName("Email")]
		public string email { get; set; }
		[DisplayName("Name")]
		public string name { get; set; }
		[DisplayName("Giới tính")]
		public int gender { get; set; }
		[DisplayName("Nickname")]
		public string username {get; set;}
		[DisplayName("Mật khẩu")]
		public string password { get; set; }
		[DisplayName("Xác nhận mật khẩu")]
		public string confirm_password { get; set; }
	}
}
