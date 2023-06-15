namespace MangaStore.RequestModels;
[Serializable]
public class VNPAYPaymentRequest
{
    string vnp_TmnCode { get; set; } = Token.vnp_TmnCode;
    string vnp_Version { get; set; } = "2.1.0";
    string vnp_Command { get; set; } = "pay";
    string vnp_CurrCode { get; set; } = "VND";
    string vnp_Locale { get; set; } = "vn";
    string vnp_OrderInfo { get; set; }
    string vnp_ReturnUrl { get; set; }
    string vnp_TxnRef { get; set; }
    string vnp_IpAddr { get; set; }
    public string vnp_TransactionNo { get; set; }
    long vnp_Amount{ get; set; }
    long vnp_CreateDate { get; set; }
    string vnp_SecureHash { get; set; }

    VNPAYPaymentRequest(string vnp_OrderInfo, string vnp_ReturnUrl, string vnp_TxnRef, string vnp_TmnCode, string vnp_TransactionNo, long vnp_Amount, long vnp_CreateDate, string vnp_SecureHash, dynamic HttpContext)
    {
        //Order info
        this.vnp_TxnRef = vnp_TxnRef;
        this.vnp_OrderInfo = vnp_OrderInfo;
        this.vnp_TmnCode = vnp_TmnCode;
        this.vnp_TransactionNo = vnp_TransactionNo;
        this.vnp_Amount = vnp_Amount*100;
        this.vnp_CreateDate = vnp_CreateDate;
        //Hash
        this.vnp_SecureHash = vnp_SecureHash;
        //Return url
        this.vnp_ReturnUrl = vnp_ReturnUrl;
        //IP
        this.vnp_IpAddr = GetIpAddress(HttpContext);
    }

    public static string GetIpAddress(dynamic HttpContext)
    {
        string ipAddress;
        try
        {
            ipAddress = HttpContext.Connection!.RemoteIpAddress!.ToString();

            if (string.IsNullOrEmpty(ipAddress) || (ipAddress.ToLower() == "unknown") || ipAddress.Length > 45)
                ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        catch (Exception ex)
        {
            ipAddress = "Invalid IP:" + ex.Message;
        }

        return ipAddress;
    }
}
