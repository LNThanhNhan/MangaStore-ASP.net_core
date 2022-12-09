using MangaStore.Data;
using MangaStore.Enums;
using MangaStore.Helpers;
using MangaStore.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MangaStore.ViewModels
{
    public class EditProductViewModel
    {
		public EditProductViewModel()
		{
		}
		public EditProductViewModel(Product pd)
		{
			id = pd.id;
			name = pd.name;
			image = pd.image;
			description = pd.description;
			author = pd.author;
			list_price = pd.list_price;
			discount_rate = pd.discount_rate;
			quantity = pd.quantity;
			publish_year = pd.publish_year;
			size = pd.size;
			collection = pd.collection;
			category = pd.category;
		}

		[Display(Name = "Mã sản phẩm")]
		public int id { get; set; }

		[Required(ErrorMessage = "Tên sản phẩm không được để trống")]
		[MaxLength(255, ErrorMessage = "Tên sản phẩm không dài quá 255 ký tự")]
		[Display(Name = "Tên sản phẩm")]
		public string name { get; set; }

		public string slug => Helper.create_slug(name);

		[Required]
		[Url(ErrorMessage = "Đường dẫn ảnh không hợp lệ")]
		[Display(Name = "Ảnh sản phẩm")]
		public string image { get; set; }

		[Display(Name = "Tác giả")]
		[Required(ErrorMessage = "Tên tác giả không được để trống")]
		[MaxLength(100, ErrorMessage = "Tên tác giả không dài quá 100 ký tự")]
		public string author { get; set; }

		//làm author_slug
		public string author_slug => Helper.create_slug(author);

		[Display(Name = "Mô tả")]
		[Required(ErrorMessage = "Mô tả sản phẩm không được để trống")]
		public string description { get; set; }

		[Display(Name = "Giá niêm yết")]
		[Required(ErrorMessage = "Giá niêm yết của sản phẩm không được để trống")]
		public long list_price { get; set; }
		public string list_priceVND
		{
			get
			{
				return list_price.ToString("N0") + " đ";
			}
		}

		[Display(Name = "Giá bán")]
		//Lấy giá niêm yết trừ đi phần trăm chiết khấu để ra giá bán
		//đồng thời làm tròn số lên sử dụng ceiling
		public long price => (long)Math.Ceiling((double)(list_price - (list_price * discount_rate / 100)));
		public string priceVND { get { return price.ToString("N0") + " đ"; } }

		[Display(Name = "Chiết khấu")]
		[Required(ErrorMessage = "Chiết khấu của sản phẩm không được để trống")]
		public int discount_rate { get; set; }

		[Display(Name = "Số lượng")]
		[Required(ErrorMessage = "Số lượng của sản phẩm không được để trống")]
		public int quantity { get; set; }

		[Display(Name = "Năm xuất bản")]
		[Required(ErrorMessage = "Năm xuất bản của sản phẩm không được để trống")]
		public int publish_year { get; set; }

		[Display(Name = "Kích thước")]
		[Required(ErrorMessage = "Kích thước của sản phẩm không được để trống")]
		[MaxLength(30, ErrorMessage = "Kích thước của sản phẩm không dài quá 30 ký tự")]
		public string size { get; set; }

		[Display(Name = "Bộ truyện")]
		[MaxLength(50, ErrorMessage = "Bộ truyện của sản phẩm không dài quá 50 ký tự")]
		public string? collection { get; set; }

		//làm slug từ collection
		public string? collection_slug => Helper.create_slug(collection);

		[Display(Name = "Thể loại")]
		[Required(ErrorMessage = "Thể loại của sản phẩm không được để trống")]
		public int category { get; set; }

		public string category_name => ProductCategory.getArrayView().FirstOrDefault(x => x.Value == category).Key;

		//Tạo custom check xem để kiểm xem name và slug có unique trong database hay không
		//nếu không thì báo lỗi bằng add error vào modelstate
		public void checkUniquename(Context db, ModelStateDictionary modelState)
		{
			var product = db.Products.FirstOrDefault(p => p.name == name && p.id != id);
			if (product != null)
			{
				modelState.AddModelError("name", "Tên sản phẩm đã tồn tại");
			}
		}

		public void checkCategory(ModelStateDictionary modelState)
		{
			//kiểm tra xem category có nằm trong mảng inArrary từ ProductCategory
			//Nếu không thì báo lỗi
			if (ProductCategory.valueArray().Contains(category))
			{
				modelState.AddModelError("category", "Thể loại không hợp lệ");
			}
		}

		public void CustomCheck(Context db, ModelStateDictionary modelState)
		{
			checkUniquename(db, modelState);
			checkCategory(modelState);
		}
	}
}
