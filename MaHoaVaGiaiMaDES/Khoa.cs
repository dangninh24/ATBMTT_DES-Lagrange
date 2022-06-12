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
            foreach (var ch in khoa)
            {
                khoaK = khoaK.Cong(MaNhiPhan.ChuyenSoSangNhiPhan(Khoa.ChuyenHexaSangHe10(ch), 4));
            }
        }

        public bool KiemTraKhoa()
        {
            return (khoaK.DoDaiMaNhiPhan() % 64 == 0);
        }

        public void SinhKhoaCon()
        {
            DayKhoaPhu = new MaNhiPhan[16];
            MaNhiPhan C0, D0, MotKhoaPhu;
            MaNhiPhan[] ChuoiSauPC1 = CacChuanDES.TinhPC1(KhoaK);
            C0 = ChuoiSauPC1[0];
            D0 = ChuoiSauPC1[1];
            for (int i = 0; i < 16; i++)
            {
                C0 = C0.DichTraiBit(CacChuanDES.soBitDich[i]);
                D0 = D0.DichTraiBit(CacChuanDES.soBitDich[i]);
                MotKhoaPhu = CacChuanDES.TinhPC2(C0, D0);
                DayKhoaPhu[i] = MotKhoaPhu;
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
                    chNP = MaNhiPhan.ChuyenSoSangNhiPhan(Khoa.ChuyenHexaSangHe10(ch), 4);
                    chuoiNhiPhan = chuoiNhiPhan.Cong(chNP);
                }
            }
        }

        public bool KiemTra()
        {
            bool Kt = true;
            foreach (char ch in Chuoi)
            {
                if (!Khoa.Hex.Contains(ch))
                {
                    Kt = false;
                    break;

                }
            }
            return Kt;
        }

        public static int ChuyenHexaSangHe10(char K)
        {
            int KQ = 0;
            switch (K)
            {
                case '0':
                    KQ = 0;
                    break;
                case '1':
                    KQ = 1;
                    break;
                case '2':
                    KQ = 2;
                    break;
                case '3':
                    KQ = 3;
                    break;
                case '4':
                    KQ = 4;
                    break;
                case '5':
                    KQ = 5;
                    break;
                case '6':
                    KQ = 6;
                    break;
                case '7':
                    KQ = 7;
                    break;
                case '8':
                    KQ = 8;
                    break;
                case '9':
                    KQ = 9;
                    break;
                case 'A':
                    KQ = 10;
                    break;
                case 'B':
                    KQ = 11;
                    break;
                case 'C':
                    KQ = 12;
                    break;
                case 'D':
                    KQ = 13;
                    break;
                case 'E':
                    KQ = 14;
                    break;
                case 'F':
                    KQ = 15;
                    break;
            }
            return KQ;
        }
    }
}
