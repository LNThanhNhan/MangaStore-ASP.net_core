using System.Globalization;
using System.Text.RegularExpressions;
using MangaStore.Enums;

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
		
		//Làm hàm format tiền tệ sang dạng VNĐ
		public static string format_VND(long price)
		{
			return price.ToString("N0") + " đ";
		}
		
		//Làm hàm format tiền tệ nhưng không có đơn vị tiền tệ
		public static string format(long price)
		{
			return price.ToString("N0");
		}
		
		//Làm hàm lấy ra tên thể loại từ id
		public static string category_name(int category)
		{
			return ProductCategory.getArrayView().FirstOrDefault(x => x.Value == category).Key;
		}
		
		//Làm hàm lấy ra tên tỉnh thành phố từ int province 
		//truyền vào, và nguồn là lấy từ class Province 
		//và lấy từ hàm getArrayView() trong class đó
		public static string province_name(int? province)
		{
			return Province.getArrayView().FirstOrDefault(x => x.Value == province).Key;
		}
		
		//Hàm lấy ra index của tỉnh thành phố từ tên string key 
		//truyền vào, và nguồn là lấy từ class Province
		//và lấy từ hàm getArrayView() trong class đó
		public static int province_id(string key)
		{
			return Province.getArrayView().FirstOrDefault(x => x.Key == key).Value;
		}
		

		//Làm hàm lấy ra tên phương thức thanh toán từ int method 
		//truyền vào, và nguồn là lấy từ class OrderPaymentMethod 
		//và lấy từ hàm getArrayView() trong class đó
		public static string payment_method_name(int method)
		{
			return OrderPaymentMethod.getArrayView().FirstOrDefault(x => x.Value == method).Key;
		}
		
		//Làm hàm lấy ra tên phương thức thanh toán từ int method 
		//truyền vào, và nguồn là lấy từ class OrderPaymentMethod 
		//và lấy từ hàm getShortArrayView() trong class đó
		public static string payment_method_short_name(int method)
		{
			return OrderPaymentMethod.getShortArrayView().FirstOrDefault(x => x.Value == method).Key;
		}
		
		//Làm hàm lấy ra tên trạng thái đơn hàng từ int status
		//truyền vào, và nguồn là lấy từ class OrderStatus
		//và lấy từ hàm getArrayView() trong class đó
		public static string order_status_name(int status)
		{
			return OrderStatus.getArrayView().FirstOrDefault(x => x.Value == status).Key;
		}
		
		//Làm hàm truyền vào biến có kiểu Datetime
		//có định dạng yyyy-MM-dd-HH-mm-ss
		//và trả về ngày có định dạng dd/MM/yyyy 
		public static string format_date(DateTime date)
		{
			return date.ToString("dd/MM/yyyy");
		}
		
		//Làm hàm truyền vào biến có kiểu Datetime
		//có định dạng yyyy-MM-dd-HH-mm-ss
		//và trả về ngày có định dạng dd/MM/yyyy HH:mm:ss 
		public static string format_dateDMY(DateTime date)
		{
			return date.ToString("dd/MM/yyyy HH:mm:ss");
		}
		
		//Làm hàm lấy ra tên giới tính nếu là 1 thì là Nam
		//còn là 0 thì là Nữ
		public static string gender_name(int gender)
		{
			return gender == 1 ? "Nam" : "Nữ";
		}
    }
}
