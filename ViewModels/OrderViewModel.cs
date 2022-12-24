using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MangaStore.ViewModels;

public class OrderViewModel
{
    public int id { get; set; }
    [Display(Name = "Họ và tên")]
    public string name { get; set; }
    [Display(Name = "Email")]
    public string email { get; set; }
    [Display(Name = "Số điện thoại")]
    public string phone { get; set; }
    [Display(Name = "Địa chỉ")]
    public string address { get; set; }
    [Display(Name = "Tỉnh/Thành phố")]
    public int province { get; set; }
    [Display(Name = "Phương thức thanh toán")]
    public int payment_method { get; set; }
}