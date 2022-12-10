using FluentValidation.AspNetCore;
using MangaStore.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

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
/*builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        // Validate child properties and root collection elements
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;

        // Automatic registration of validators in assembly
        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });*/
builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    //để giá trị là false để manual validate
    conf.AutomaticValidationEnabled = false;
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

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
