using FluentValidation;
using MangaStore.Data;
using MangaStore.Enums;
using MangaStore.ViewModels;

namespace MangaStore.Validators
{
    public class OrderViewValidator:AbstractValidator<OrderViewModel>
    {
        private readonly Context _context;

        public OrderViewValidator(Context context)
        {
            _context = context;
            RuleLevelCascadeMode = CascadeMode.Stop;
            
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Tên người nhận không được để trống")
                .MaximumLength(100).WithMessage("Tên người nhận không được quá 100 ký tự");
            
            RuleFor(x => x.email)
                .NotEmpty().WithMessage("Email không được để trống")
                .EmailAddress().WithMessage("Email không đúng định dạng")
                .MaximumLength(100).WithMessage("Email không được quá 100 ký tự");
            
            RuleFor(x => x.phone)
                .NotEmpty().WithMessage("Số điện thoại không được để trống")
                .MaximumLength(10).WithMessage("Số điện thoại không được quá 10 ký tự");

            RuleFor(x => x.address)
                .NotEmpty().WithMessage("Địa chỉ không được để trống");
            
            //Kiểm tra giá trị province phải nằm trong hàm trả về
            //mảng getValue của Province
            RuleFor(x => x.province)
                .NotEmpty().WithMessage("Tỉnh/Thành phố không được để trống")
                .Must(x=>Province.getValue().Contains(x)).WithMessage("Tỉnh/Thành phố không hợp lệ");
            
            //Kiểm tra giá trị payment_method phải nằm trong hàm trả về
            //mảng getValue của OrderPaymentMethod
            RuleFor(x => x.payment_method)
                .NotEmpty().WithMessage("Phương thức thanh toán không được để trống")
                .Must(x => OrderPaymentMethod.getValue().Contains(x)).WithMessage("Phương thức thanh toán không hợp lệ");
        }    
    }
}
