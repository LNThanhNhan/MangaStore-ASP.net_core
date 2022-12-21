namespace MangaStore.Enums;

public class OrderPaymentMethod
{
    public const int COD = 1;
    public const int NGAN_HANG = 2;
    public const int ZALO_PAY = 3;
    
    public static Dictionary<string, int> getArrayView()
    {
        return new Dictionary<string, int>
        {
            { "Thanh toán khi nhận hàng", COD },
            { "Thanh toán qua ngân hàng", NGAN_HANG },
            { "Thanh toán qua Zalo Pay", ZALO_PAY },
        };
    }
    
    public static Dictionary<string, int> getShortArrayView()
    {
        return new Dictionary<string, int>()
        {
            {"COD", COD},
            {"Ngân hàng", NGAN_HANG},
            {"Zalo Pay", ZALO_PAY},
        };
    }
    
    //make an int array that take all int variable in this class
    // and return it, name this function getValue
    public static int[] getValue()
    {
        return new int[] { COD, NGAN_HANG, ZALO_PAY };
    }
}