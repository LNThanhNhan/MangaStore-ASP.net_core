namespace MangaStore.Enums;

public class ShippingFee
{
    public const int HN_HCM = 20000;
    public const int OTHER = 35000;
    
    public static Dictionary<string,int> getArray()
    {
        return new Dictionary<string,int>
        {
            {"hn_hcm",HN_HCM},
            {"tinh_thanh",OTHER}
        };
    }
}