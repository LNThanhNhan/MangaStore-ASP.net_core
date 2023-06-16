using ConfigurationManager = System.Configuration.ConfigurationManager;
namespace MangaStore.Services.VnPay.Interface
{
    public class VnPayService: IVnPayService
    {
        public string CreateRequestUrl(VnPayPaymentRequest request,IConfiguration configuration, IHttpContextAccessor httpContextAccessor, string returnURL)
        {
            //Cài đặt các thông tin chung cho phương thức thanh toán VnPay
            string version = configuration["VnPay:Version"];
            string command = configuration["VnPay:Command"];
            string vnp_TmnCode = Token.vnp_TmnCode;
            string vnp_Amount = (request.vnp_Amount*100).ToString();
            string vnp_CreateDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            string vnp_CurrCode = configuration["VnPay:CurrencyCode"];
            //lấy địa chỉ ip của khách hàng
            string vnp_IpAddr = httpContextAccessor!.HttpContext!.Request.Headers["X-Forwarded-For"];
            //string vnp_IpAddr = VnPayLibrary.GetIpAddress(httpContextAccessor);
            string vnp_Locale = configuration["VnPay:Locale"];
            string vnp_OrderInfo = request.vnp_OrderInfo;
            string vnp_ReturnUrl = returnURL;
            string vnp_ExpireDate = DateTime.Now.AddMinutes(15).ToString("yyyyMMddHHmmss");
            string vnp_TxnRef = request.vnp_TransactionNo;
            string secureHash = Token.vnp_HashSecr;

            //Sử dụng vnPayLibrary để tạo link thanh toán
            VnPayLibrary vnPayLibrary = new VnPayLibrary();
            vnPayLibrary.AddRequestData("vnp_Version", version);
            vnPayLibrary.AddRequestData("vnp_Command", command);
            vnPayLibrary.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnPayLibrary.AddRequestData("vnp_Amount", vnp_Amount);
            vnPayLibrary.AddRequestData("vnp_CreateDate", vnp_CreateDate);
            vnPayLibrary.AddRequestData("vnp_CurrCode", vnp_CurrCode);
            vnPayLibrary.AddRequestData("vnp_IpAddr", vnp_IpAddr);
            vnPayLibrary.AddRequestData("vnp_Locale", vnp_Locale);
            vnPayLibrary.AddRequestData("vnp_OrderInfo", vnp_OrderInfo);
            vnPayLibrary.AddRequestData("vnp_ReturnUrl", vnp_ReturnUrl);
            vnPayLibrary.AddRequestData("vnp_TxnRef", vnp_TxnRef);
            vnPayLibrary.AddRequestData("vnp_ExpireDate", vnp_ExpireDate);
            string paymentUrl = vnPayLibrary.CreateRequestUrl(configuration["VnPay:BaseUrl"], secureHash);
            return paymentUrl;
        }

        public string GetResponseData(string key)
        {
            throw new NotImplementedException();
        }
    }
}
