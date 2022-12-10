using System.ComponentModel.DataAnnotations;
using MangaStore.Helpers;
using MangaStore.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MangaStore.Enums;
using MangaStore.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MangaStore.ViewModels
{
    [ValidateNever]
    public class ProductViewModel
    {
        [Display(Name = "Mã sản phẩm")]
        public int id { get; set; }

        [Display(Name = "Tên sản phẩm")]
		
        public string name { get; set; }

        public string slug
        {
	        get
	        {
				if(this.name !=null)
					return Helper.create_slug(name);
				return null;
	        }
        }

        [Display(Name = "Ảnh sản phẩm")]
        public string image { get; set; }

        [Display(Name = "Tác giả")]
        public string author { get; set; }

        //làm author_slug
        public string author_slug => Helper.create_slug(author);

        [Display(Name = "Mô tả")]
        public string description { get; set; }

        [Display(Name = "Giá niêm yết")]
        public long list_price { get; set; }
        public string list_priceVND
        {
            get
            {
                return list_price.ToString("N0") + " đ";
            }
        }

        [Display(Name = "Giá bán")]
		public long price =>(long) Math.Ceiling((double)(list_price - (list_price * discount_rate / 100)));
		public string priceVND { get { return price.ToString("N0") + " đ"; } }

        [Display(Name = "Chiết khấu")]
        public int discount_rate { get; set; }

        [Display(Name = "Số lượng")]
        public int quantity { get; set; }

        [Display(Name = "Năm xuất bản")]
        public int publish_year { get; set; }

        [Display(Name = "Kích thước")]
        public string size { get; set; }

        [Display(Name = "Bộ truyện")]
        public string? collection { get; set; }

        //làm slug từ collection
        public string? collection_slug => Helper.create_slug(collection);

        [Display(Name = "Thể loại")]
        public int category { get; set; }

        public string category_name => ProductCategory.getArrayView().FirstOrDefault(x => x.Value == category).Key;
    }
}
