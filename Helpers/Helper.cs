using System.Text.RegularExpressions;

namespace MangaStore.Helpers
{
    public class Helper
    {
        //làm hàm MakeSlug để chuyển chuyển tiếng việt có dấu thành không dấu và chuyển thành slug
        //vd: Trường quê sạch và đẹp lắm do bố xây kĩ => truong-que-sach-va-dep-lam-do-bo-xay-ki
        //hoặc đăng ký tên miền => dang-ky-ten-mien
        public static string create_slug(string title)
        {
            string slug = title.ToLower();
            //Đổi ký tự có dấu thành không dấu
            slug = Regex.Replace(slug, "[áàảạãăắằẳẵặâấầẩẫậ]", "a");
            slug = Regex.Replace(slug, "[éèẻẽẹêếềểễệ]", "e");
            slug = Regex.Replace(slug, "[iíìỉĩị]", "i");
            slug = Regex.Replace(slug, "[óòỏõọôốồổỗộơớờởỡợ]", "o");
            slug = Regex.Replace(slug, "[úùủũụưứừửữự]", "u");
            slug = Regex.Replace(slug, "[ýỳỷỹỵ]", "y");
            slug = Regex.Replace(slug, "[đ]", "d");
            //Xóa các ký tự đặt biệt
            slug = Regex.Replace(slug, "[`~!@#$%^&*()+=,./<>?;':\"|{}]", "");
            //Đổi khoảng trắng thành ký tự gạch ngang
            slug = Regex.Replace(slug, "[ ]", "-");
            //Đổi nhiều ký tự gạch ngang liên tiếp thành 1 ký tự gạch ngang
            //Phòng trường hợp người nhập vào quá nhiều ký tự trắng
            slug = Regex.Replace(slug, "[-]{2,}", "-");
            //Xóa các ký tự gạch ngang ở đầu và cuối
            slug = Regex.Replace(slug, "^-+", "");
            slug = Regex.Replace(slug, "-+$", "");
            return slug;
        }

		//Làm hàm hash mật khẩu với salt random để lưu vào database
		public static string hash_password(string password)
		{
			string salt = BCrypt.Net.BCrypt.GenerateSalt();
			string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
			return hash;
		}

		//Làm hàm verify mật khẩu từ brcryp.net
		public static bool verify_password(string password, string hash)
		{
			return BCrypt.Net.BCrypt.Verify(password, hash);
		}
	}
}
