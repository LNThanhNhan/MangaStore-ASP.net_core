using Microsoft.AspNetCore.Mvc.Controllers;

namespace MangaStore.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next; 
        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //làm middleware kiểm tra bằng cách lấy đường dẫn url
            //ví dụ http://localhost:5000/Account/Login
            //sẽ lấy đc ra được tên controller là Account
            //rồi thực hiện kiểm tra xem tên controller này
            //có tên controller trong mảng sau { "Cart", "Order", "Product"}
            //và so sánh không cần xét đến chữ hoa thường
            //thì kiểm tra xem có tồn tại session "account_id" hay không
            //nếu không tồn tại thì chuyển hướng về trang đăng nhập
            //nếu tồn tại thì cho phép truy cập
            string controllerName= context.Request.Path.Value.Split("/")[1];
            string[] controllers = { "Cart", "Order", "Product" };
            if (controllers.Contains(controllerName, StringComparer.OrdinalIgnoreCase))
            {
                if (context.Session.GetString("account_id") == null)
                {
                    //Write Async 1
                    //await context.Response.WriteAsync("đã vào middleware");
                    context.Response.Redirect("/login");
                    return;
                }
            }
            //await context.Response.WriteAsync(controllerActionDescriptor.ToString());
            await _next.Invoke(context);
        }
    }
}

