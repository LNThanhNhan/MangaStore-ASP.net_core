namespace MangaStore.Enums;

public class ShippingFee
{
    public const long HN_HCM = 20000;
    public const long OTHER = 35000;
    
    public static Dictionary<string,long> getArray()
    {
        return new Dictionary<string,long>
        {
            {"hn_hcm",HN_HCM},
            {"tinh_thanh",OTHER}
        };
    }
}