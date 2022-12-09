namespace MangaStore.Enums
{
    public class ProductCategory
    {
        public const int HAI_HUOC = 1;
        public const int KINH_DI = 2;
        public const int LANG_MAN = 3;
        public const int HOC_DUONG = 4;
        public const int GIA_TUONG = 5;
        public const int SIEU_NHIEN = 6;
        public const int TAM_LY = 7;
        public const int THE_THAO = 8;
        public const int DOI_THUONG = 9;
        public const int HANH_DONG = 10;
        public const int PHIEU_LUU = 11;
        public const int NGUOI_TRUONG_THANH = 12;
        public const int THANH_THIEU_NIEN = 13;

        //Hàm tạo array view trả về dictionary
        //với key là giá trị và value là tên thể loại
        public static Dictionary<string, int> getArrayView()
        {
            return new Dictionary<string, int>()
            {
                { "Hài hước", HAI_HUOC },
                { "Kinh dị", KINH_DI },
                { "Lãng mạn", LANG_MAN },
                { "Học đường", HOC_DUONG },
                { "Giả tưởng", GIA_TUONG },
                { "Siêu nhiên", SIEU_NHIEN },
                { "Tâm lý", TAM_LY },
                { "Thể thao", THE_THAO },
                { "Đời thường", DOI_THUONG },
                { "Hành động", HANH_DONG },
                { "Phiêu lưu", PHIEU_LUU },
                { "Người trưởng thành", NGUOI_TRUONG_THANH },
                { "Thanh thiếu niên", THANH_THIEU_NIEN },
            };
        }

        public static int[] valueArray()
        {
            int[] arr = 
            {   
                HAI_HUOC,
                KINH_DI,
                LANG_MAN,
                PHIEU_LUU,
                HOC_DUONG,
                GIA_TUONG ,
                SIEU_NHIEN,
                TAM_LY,
                THE_THAO,
                DOI_THUONG,
                HANH_DONG,
                PHIEU_LUU,
                NGUOI_TRUONG_THANH,
                THANH_THIEU_NIEN,
            };
            return arr;
        }
    }
}
