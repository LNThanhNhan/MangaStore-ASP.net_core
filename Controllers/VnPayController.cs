using MangaStore.Data;
using MangaStore.Enums;
using MangaStore.Services.VnPay;
using MangaStore.Services.VnPay.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace MangaStore.Controllers
{
    public class VnPayController : Controller
    {
        private readonly IVnPayService _vnPayService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly Context _context;
        public VnPayController(IVnPayService vnPayService, IHttpContextAccessor httpContextAccessor,Context context, IConfiguration configuration)
        {
            _vnPayService = vnPayService;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Payment(int orderId, long totalPrice)
        {
            string returnURL =_configuration["Domain"]+ Url.Action("ReturnCallback","VnPay");
            VnPayPaymentRequest paymentRequest = new VnPayPaymentRequest()
            {
                vnp_TransactionNo = orderId.ToString(),
                vnp_OrderInfo = "Thanh toán đơn hàng #" + orderId.ToString(),
                vnp_Amount = totalPrice,
            };
            string url = _vnPayService.CreateRequestUrl(paymentRequest,_configuration,_httpContextAccessor,returnURL);
            //Console.WriteLine(url);
            //string temp = url;
            return Redirect(url);
        }
        public IActionResult ReturnCallback([FromQuery] string vnp_ResponseCode, [FromQuery] int vnp_TxnRef)
        {
            var payOrder = _context.Orders
                        .Include(o => o.user)
                        .ThenInclude(u => u.cart)
                        .ThenInclude(c => c.cart_details)
                        .FirstOrDefault(o => o.id == vnp_TxnRef);
            if (vnp_ResponseCode=="00")
            {
                payOrder!.status = OrderStatus.DANG_GIAO_HANG;
                _context.SaveChanges();
                return RedirectToAction("ProcessAfterSuscessPurchase", "Order",new { order_id=payOrder.id });
            } 
            _context.Orders.Remove(payOrder);
            _context.SaveChanges();
            TempData["error"] = "Đã có lỗi xảy ra trong quá trình thanh toán VNPAY";
            return RedirectToAction("Index", "User");
        }
    }
}
