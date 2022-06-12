using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaHoaDES.MaHoaVaGiaiMaDES
{
    public class Khoa
    {
        private MaNhiPhan khoaK;
        private MaNhiPhan[] dayKhoaPhu;
        private string chuoi;
        private int _doDaiChuoi;
        private MaNhiPhan chuoiNhiPhan;
        public static string Hex = "0123456789ABCDEF";

        public MaNhiPhan KhoaK { get => khoaK; set => khoaK = value; }
        public MaNhiPhan[] DayKhoaPhu { get => dayKhoaPhu; set => dayKhoaPhu = value; }
        public string Chuoi { get => chuoi; set => chuoi = value; }
        public int _DoDaiChuoi { get => _doDaiChuoi; set => _doDaiChuoi = value; }
        public MaNhiPhan ChuoiNhiPhan { get => chuoiNhiPhan; set => chuoiNhiPhan = value; }

        public Khoa(string khoa)
        {
            khoaK = new MaNhiPhan(0);
            foreach (var items in khoa)
            {
                khoaK = khoaK.Cong(MaNhiPhan.ChuyenSoSangMangNhiPhan(Khoa.ChuyenHexaSangHe10(items), 4));
            }
        }

        public bool KiemTraKhoa()
        {
            return (khoaK.DoDaiMangMaNhiPhan() % 64 == 0);
        }

        public void SinhKhoaCon()
        {
            DayKhoaPhu = new MaNhiPhan[16];
            MaNhiPhan C, D, KhoaP;
            MaNhiPhan[] ChuoiSauPC1 = CacChuanDES.TinhPC1(KhoaK);
            C = ChuoiSauPC1[0];
            D = ChuoiSauPC1[1];
            for (int i = 0; i < 16; i++)
            {
                C = C.DichTraiBit(CacChuanDES.soBitDich[i]);
                D = D.DichTraiBit(CacChuanDES.soBitDich[i]);
                KhoaP = CacChuanDES.TinhPC2(C, D);
                DayKhoaPhu[i] = KhoaP;
            }

        }

        public int DoDaiChuoi
        {
            get { return Chuoi.Length; }
        }

        public Khoa(string chuoi, bool check)
        {
            this.Chuoi = chuoi.ToUpper(); 
            MaNhiPhan chNP;   
            if (KiemTra())
            {
                chuoiNhiPhan = new MaNhiPhan(0);
                foreach (var ch in Chuoi)
                {
                    chNP = MaNhiPhan.ChuyenSoSangMangNhiPhan(Khoa.ChuyenHexaSangHe10(ch), 4);
                    chuoiNhiPhan = chuoiNhiPhan.Cong(chNP);
                }
            }
        }

        public bool KiemTra()
        {
            bool check = true;
            foreach (char items in Chuoi)
            {
                if (!Khoa.Hex.Contains(items))
                {
                    check = false;
                    break;

                }
            }
            return check;
        }

        public static int ChuyenHexaSangHe10(char K)
        {
            int ketQua = 0;
            switch (K)
            {
                case '0':
                    ketQua = 0;
                    break;
                case '1':
                    ketQua = 1;
                    break;
                case '2':
                    ketQua = 2;
                    break;
                case '3':
                    ketQua = 3;
                    break;
                case '4':
                    ketQua = 4;
                    break;
                case '5':
                    ketQua = 5;
                    break;
                case '6':
                    ketQua = 6;
                    break;
                case '7':
                    ketQua = 7;
                    break;
                case '8':
                    ketQua = 8;
                    break;
                case '9':
                    ketQua = 9;
                    break;
                case 'A':
                    ketQua = 10;
                    break;
                case 'B':
                    ketQua = 11;
                    break;
                case 'C':
                    ketQua = 12;
                    break;
                case 'D':
                    ketQua = 13;
                    break;
                case 'E':
                    ketQua = 14;
                    break;
                case 'F':
                    ketQua = 15;
                    break;
            }
            return ketQua;
        }
    }
}
