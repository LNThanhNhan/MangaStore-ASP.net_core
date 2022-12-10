using FluentValidation;
using MangaStore.Data;
using MangaStore.Enums;
using MangaStore.ViewModels;

namespace MangaStore.Validators
{
    public class EditProductViewValidator : AbstractValidator<EditProductViewModel>
    {
        private readonly Context _context;
        public EditProductViewValidator(Context context)
        {
            _context = context;
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Tên sách không được để trống")
                .MaximumLength(255).WithMessage("Tên sách không được quá 255 ký tự");

            RuleFor(x => x.image)
                .NotEmpty().WithMessage("Ảnh sách không được để trống")
                .Must(x => Uri.IsWellFormedUriString(x, UriKind.Absolute)).WithMessage("Ảnh sách không đúng định dạng");


            RuleFor(x => x.author)
                .NotEmpty().WithMessage("Tên tác giả không được để trống")
                .MaximumLength(100).WithMessage("Tên tác giả không được quá 100 ký tự");

            RuleFor(x => x.description)
                .NotEmpty().WithMessage("Mô tả sách không được để trống");

            RuleFor(x => x.list_price)
                .NotEmpty().WithMessage("Giá niêm yết không được để trống")
                .Must(x => x > 0).WithMessage("Giá niêm yết phải lớn hơn 0");

            RuleFor(x => x.discount_rate)
                .NotEmpty().WithMessage("Chiết khấu không được để trống")
                .InclusiveBetween(0, 100).WithMessage("Chiết khấu phải nằm trong khoảng 0-100");

            RuleFor(x => x.quantity)
                .NotEmpty().WithMessage("Số lượng không được để trống")
                .Must(x => x > 0).WithMessage("Số lượng phải lớn hơn 0");

            RuleFor(x => x.publish_year)
                .NotEmpty().WithMessage("Năm xuất bản không được để trống")
                .InclusiveBetween(1900, 2023).WithMessage("Năm xuất bản phải nằm trong khoảng 1900-2023");

            RuleFor(x => x.size)
                .NotEmpty().WithMessage("Kích thước truyện không được để trống")
                .MaximumLength(30).WithMessage("Kích thước truyện không được quá 30 ký tự");

            RuleFor(x => x.collection)
                .MaximumLength(100).WithMessage("Tên bộ truyện không được quá 255 ký tự");

            RuleFor(x => x.category)
                .NotEmpty().WithMessage("Thể loại không được để trống");

            //Kiểm tra unique
            RuleFor(x => x)
                .Must(x => !context.Products.Any(y => y.name.ToLower() == x.name.ToLower() && y.id != x.id))
                .WithMessage("Tên sách đã tồn tại");

            //Kiểm tra thể loại phải nằm trong dictionary từ hàm valueArray từ ProductCategory
            RuleFor(x => x.category)
                .Must(x => ProductCategory.valueArray().Contains(x)).WithMessage("Thể loại không hợp lệ");
        }
    }
}
