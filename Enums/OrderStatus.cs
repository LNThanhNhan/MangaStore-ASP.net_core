namespace MangaStore.Enums;

public class OrderStatus
{
    public const int CHO_XAC_NHAN = 0;
    public const int DANG_GIAO_HANG = 1;
    public const int DA_GIAO_HANG = 2;
    public const int GIAO_HANG_THAT_BAI = 3;
    public const int DA_HUY = 4;
    
    //make a function that name is getArrayView and return
    //dictionary that has key as string and value as int
    //this is used to get the value of the constant
    //like a dictionary below
    public static Dictionary<string, int> getArrayView()
    {
        return new Dictionary<string, int>
        {
            {"Chờ xác nhận", CHO_XAC_NHAN},
            {"Đang giao hàng", DANG_GIAO_HANG},
            {"Đã giao hàng", DA_GIAO_HANG},
            {"Giao hàng thất bại", GIAO_HANG_THAT_BAI},
            {"Đã hủy", DA_HUY}
        };
    }
    
    //make an int array that take all int variable in this class
    // and return it, name this function getValue
    public static int[] getValue()
    {
        return new int[]
        {
            CHO_XAC_NHAN,
            DANG_GIAO_HANG,
            DA_GIAO_HANG,
            GIAO_HANG_THAT_BAI,
            DA_HUY
        };
    }
}