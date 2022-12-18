﻿namespace MangaStore.Enums
{
    public class Province
    {
        public const int ANGIANG = 1;
        public const int BA_RIA_VUNG_TAU = 2;
        public const int BACGIANG = 3;
        public const int BACKAN = 4;
        public const int BACLIEU = 5;
        public const int BACNINH = 6;
        public const int BENTRE = 7;
        public const int BINHDINH = 8;
        public const int BINHDUONG = 9;
        public const int BINHPHUOC = 10;
        public const int BINHTHUAN = 11;
        public const int CAMAU = 12;
        public const int CANTHO = 13;
        public const int CAOBANG = 14;
        public const int DANANG = 15;
        public const int DAKLAK = 16;
        public const int DAKNONG = 17;
        public const int DIENBIEN = 18;
        public const int DONGNAI = 19;
        public const int DONGTHAP = 20;
        public const int GIALAI = 21;
        public const int HAGIANG = 22;
        public const int HANAM = 23;
        public const int HANOI = 24;
        public const int HATINH = 25;
        public const int HAIDUONG = 26;
        public const int HAIPHONG = 27;
        public const int HAUGIANG = 28;
        public const int HOABINH = 29;
        public const int HOCHIMINH = 30;
        public const int HUNGYEN = 31;
        public const int KHANHHOA = 32;
        public const int KIENGIANG = 33;
        public const int KONTUM = 34;
        public const int LAICHAU = 35;
        public const int LAMDONG = 36;
        public const int LANGSON = 37;
        public const int LAOCAI = 38;
        public const int LONGAN = 39;
        public const int NAMDINH = 40;
        public const int NGHEAN = 41;
        public const int NINHBINH = 42;
        public const int NINHTHUAN = 43;
        public const int PHUTHO = 44;
        public const int PHUYEN = 45;
        public const int QUANGBINH = 46;
        public const int QUANGNAM = 47;
        public const int QUANGNGAI = 48;
        public const int QUANGNINH = 49;
        public const int QUANGTRI = 50;
        public const int SOCTRANG = 51;
        public const int SONLA = 52;
        public const int TAYNINH = 53;
        public const int THAIBINH = 54;
        public const int THAINGUYEN = 55;
        public const int THANHHOA = 56;
        public const int THUATHIENHUE = 57;
        public const int TIENGIANG = 58;
        public const int TRAVINH = 59;
        public const int TUYENQUANG = 60;
        public const int VINHLONG = 61;
        public const int VINHPHUC = 62;
        public const int YENBAI = 63;

        //make a dictionary like in fuction getArrayView
        //the difference is that the value is map to each int variable
        //in this class
        public static Dictionary<string, int> getArrayView()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("An Giang", ANGIANG);
            result.Add("Bà Rịa - Vũng Tàu", BA_RIA_VUNG_TAU);
            result.Add("Bắc Giang", BACGIANG);
            result.Add("Bắc Kạn", BACKAN);
            result.Add("Bạc Liêu", BACLIEU);
            result.Add("Bắc Ninh", BACNINH);
            result.Add("Bến Tre", BENTRE);
            result.Add("Bình Định", BINHDINH);
            result.Add("Bình Dương", BINHDUONG);
            result.Add("Bình Phước", BINHPHUOC);
            result.Add("Bình Thuận", BINHTHUAN);
            result.Add("Cà Mau", CAMAU);
            result.Add("Cần Thơ", CANTHO);
            result.Add("Cao Bằng", CAOBANG);
            result.Add("Đà Nẵng", DANANG);
            result.Add("Đắk Lắk", DAKLAK);
            result.Add("Đắk Nông", DAKNONG);
            result.Add("Điện Biên", DIENBIEN);
            result.Add("Đồng Nai", DONGNAI);
            result.Add("Đồng tháp", DONGTHAP);
            result.Add("Gia Lai", GIALAI);
            result.Add("Hà Giang", HAGIANG);
            result.Add("Hà Nam", HANAM);
            result.Add("Hà Nội", HANOI);
            result.Add("Hà Tĩnh", HATINH);
            result.Add("Hải Dương", HAIDUONG);
            result.Add("Hải Phòng", HAIPHONG);
            result.Add("Hậu Giang", HAUGIANG);
            result.Add("Hòa Bình", HOABINH);
            result.Add("Hồ Chí Minh", HOCHIMINH);
            result.Add("Hưng Yên", HUNGYEN);
            result.Add("Khánh Hòa", KHANHHOA);
            result.Add("Kiên Giang", KIENGIANG);
            result.Add("Kon Tum", KONTUM);
            result.Add("Lai Châu", LAICHAU);
            result.Add("Lâm Đồng", LAMDONG);
            result.Add("Lạng Sơn", LANGSON);
            result.Add("Lào Cai", LAOCAI);
            result.Add("Long An", LONGAN);
            result.Add("Nam Định", NAMDINH);
            result.Add("Nghệ An", NGHEAN);
            result.Add("Ninh Bình", NINHBINH);
            result.Add("Ninh Thuận", NINHTHUAN);
            result.Add("Phú Thọ", PHUTHO);
            result.Add("Phú Yên", PHUYEN);
            result.Add("Quảng Bình", QUANGBINH);
            result.Add("Quảng Nam", QUANGNAM);
            result.Add("Quảng Ngãi", QUANGNGAI);
            result.Add("Quảng Ninh", QUANGNINH);
            result.Add("Quảng Trị", QUANGTRI);
            result.Add("Sóc Trăng", SOCTRANG);
            result.Add("Sơn La", SONLA);
            result.Add("Tây Ninh", TAYNINH);
            result.Add("Thái Bình", THAIBINH);
            result.Add("Thái Nguyên", THAINGUYEN);
            result.Add("Thanh Hóa", THANHHOA);
            result.Add("Thừa Thiên Huế", THUATHIENHUE);
            result.Add("Tiền Giang", TIENGIANG);
            result.Add("Trà Vinh", TRAVINH);
            result.Add("Tuyên Quang", TUYENQUANG);
            result.Add("Vĩnh Long", VINHLONG);
            result.Add("Vĩnh Phúc", VINHPHUC);
            result.Add("Yên Bái", YENBAI);
            return result;
        }

        //make an int array that take all int variable in this class
        // and return it, name this function getValue
        public static int[] getValue()
        {
            int[] result = new int[63];
            result[0] = ANGIANG;
            result[1] = BA_RIA_VUNG_TAU;
            result[2] = BACGIANG;
            result[3] = BACKAN;
            result[4] = BACLIEU;
            result[5] = BACNINH;
            result[6] = BENTRE;
            result[7] = BINHDINH;
            result[8] = BINHDUONG;
            result[9] = BINHPHUOC;
            result[10] = BINHTHUAN;
            result[11] = CAMAU;
            result[12] = CANTHO;
            result[13] = CAOBANG;
            result[14] = DANANG;
            result[15] = DAKLAK;
            result[16] = DAKNONG;
            result[17] = DIENBIEN;
            result[18] = DONGNAI;
            result[19] = DONGTHAP;
            result[20] = GIALAI;
            result[21] = HAGIANG;
            result[22] = HANAM;
            result[23] = HANOI;
            result[24] = HATINH;
            result[25] = HAIDUONG;
            result[26] = HAIPHONG;
            result[27] = HAUGIANG;
            result[28] = HOABINH;
            result[29] = HOCHIMINH;
            result[30] = HUNGYEN;
            result[31] = KHANHHOA;
            result[32] = KIENGIANG;
            result[33] = KONTUM;
            result[34] = LAICHAU;
            result[35] = LAMDONG;
            result[36] = LANGSON;
            result[37] = LAOCAI;
            result[38] = LONGAN;
            result[39] = NAMDINH;
            result[40] = NGHEAN;
            result[41] = NINHBINH;
            result[42] = NINHTHUAN;
            result[43] = PHUTHO;
            result[44] = PHUYEN;
            result[45] = QUANGBINH;
            result[46] = QUANGNAM;
            result[47] = QUANGNGAI;
            result[48] = QUANGNINH;
            result[49] = QUANGTRI;
            result[50] = SOCTRANG;
            result[51] = SONLA;
            result[52] = TAYNINH;
            result[53] = THAIBINH;
            result[54] = THAINGUYEN;
            result[55] = THANHHOA;
            result[56] = THUATHIENHUE;
            result[57] = TIENGIANG;
            result[58] = TRAVINH;
            result[59] = TUYENQUANG;
            result[60] = VINHLONG;
            result[61] = VINHPHUC;
            result[62] = YENBAI;
            return result;
        }
    }
}