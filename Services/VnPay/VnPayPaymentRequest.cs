using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace MangaStore.Services.VnPay;
[Serializable]
public class VnPayPaymentRequest
{
    public string vnp_OrderInfo { get; set; }
    public string vnp_TransactionNo { get; set; }
    public long vnp_Amount { get; set; }
}
