using FluentValidation;
using MangaStore.Data;
using MangaStore.ViewModels;

namespace MangaStore.Validators
{
	public class RegisterValidator : AbstractValidator<RegisterViewModel>
	{
		private readonly Context _context;
		public RegisterValidator(Context context)
		{
			_context = context;
			RuleLevelCascadeMode = CascadeMode.Stop;
			
			RuleFor(x => x.email)
				.NotEmpty().WithMessage("Email không được để trống")
				.EmailAddress().WithMessage("Email không đúng định dạng")
				.Must(UniqueEmail).WithMessage("Email đã tồn tại")
				.MaximumLength(100).WithMessage("Họ tên không được quá 100 ký tự");
			
			RuleFor(x => x.username)
				.NotEmpty().WithMessage("Nickname không được để trống")
				.MaximumLength(255).WithMessage("Nickname không được quá 255 ký tự");
			
			RuleFor(x => x.name)
				.NotEmpty().WithMessage("Họ tên không được để trống")
				.MaximumLength(255).WithMessage("Họ tên không được quá 255 ký tự");
			
			RuleFor(x => x.password)
				.NotEmpty().WithMessage("Mật khẩu không được để trống")
				.MinimumLength(6).WithMessage("Mật khẩu phải có ít nhất 6 ký tự")
				.MaximumLength(100).WithMessage("Mật khẩu không được quá 100 ký tự");
			
			RuleFor(x=>x.gender)
				.NotEmpty().WithMessage("Giới tính không được để trống")
				.InclusiveBetween(0, 1).WithMessage("Giới tính không hợp lệ");
			
			RuleFor(x => x.confirm_password)
				.NotEmpty().WithMessage("Xác nhận mật khẩu không được để trống")
				.Equal(x => x.password).WithMessage("Xác nhận mật khẩu không khớp");
		}
		private bool UniqueEmail(string email)
		{
			return _context.Accounts.FirstOrDefault(x => x.email == email) == null;
		}
	}
	
}
