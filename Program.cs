using FluentValidation.AspNetCore;
using MangaStore.Data;
using MangaStore.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add dbcontext
builder.Services.AddDbContext<Context>
(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Add razor runtime compilation
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
// Add auto mapper 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add fluent API
builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    //để giá trị là false để manual validate
    conf.AutomaticValidationEnabled = false;
});
//Add session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

//Thêm middlware để kiểm tra với route có area = user 
//thì sẽ kiểm tra session có tồn tại hay không
//Nếu chưa thì sẽ điều hướng sang route login
app.UseMiddleware<AuthMiddleware>();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
