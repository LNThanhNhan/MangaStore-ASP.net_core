namespace MangaStore.Services.VnPay.Interface
{
    public interface IVnPayService
    {
        string CreateRequestUrl(VnPayPaymentRequest request,IConfiguration configuration,IHttpContextAccessor httpContextAccessor,string returnURL);
        string GetResponseData(string key);
    }
}
