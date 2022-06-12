using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaHoaDES.MaHoaVaGiaiMaDES
{
    public class MaNhiPhan
    {
        private int[] mangMaNhiPhan;
        private string _vanBan;

        public int[] MangMaNhiPhan { get => mangMaNhiPhan; set => mangMaNhiPhan = value; }
        public string _VanBan { get => _vanBan; set => _vanBan = value; }

        public int DoDaiMangMaNhiPhan()
        {
            return MangMaNhiPhan.Length;
        }

        public MaNhiPhan(int doDai)
        {
            MangMaNhiPhan = new int[doDai];
        }

        public MaNhiPhan(int[] maNhiPhan)
        {
            this.MangMaNhiPhan = maNhiPhan;
        }

        public MaNhiPhan(char kyTu)
        {
            MangMaNhiPhan = new int[16];
            int Ma = (int)kyTu;
            int i = 15;
            while (Ma > 0)
            {
                MangMaNhiPhan[i] = Ma % 2;
                Ma = Ma / 2;
                i--;
            }
        }

        public string VanBan
        {
            get { return ChuyenMaNhiPhanSangChu(); }
        }

        public string ChuyenMaNhiPhanSangChu()
        {
            string str = "";
            foreach (var ch in MangMaNhiPhan)
            {
                str += ch.ToString();
            }
            return str;
        }

        public MaNhiPhan Cat(long viTri, long SoLuong)
        {
            int[] MangCat = new int[SoLuong];
            for (long i = viTri; i < viTri + SoLuong; i++)
            {
                MangCat[i - viTri] = MangMaNhiPhan[i];
            }
            return (new MaNhiPhan(MangCat));
        }

        public MaNhiPhan ChinhDoDai()
        {
            int Mod64 = DoDaiMangMaNhiPhan() % 64;
            int so = 64 - Mod64;
            MaNhiPhan chuoiBu = new MaNhiPhan(so);
            MaNhiPhan ketQua = new MaNhiPhan(MangMaNhiPhan);
            ketQua = ketQua.Cong(chuoiBu);

            MaNhiPhan ChuoiChieuDai = MaNhiPhan.ChuyenSoSangMangNhiPhan((int)DoDaiMangMaNhiPhan(), 64);
            ketQua = ketQua.Cong(ChuoiChieuDai);
            return ketQua;
        }

        public MaNhiPhan Cat()
        {
            MaNhiPhan Chuoi = this.Cat(DoDaiMangMaNhiPhan() - 64, 64);
            long so = MaNhiPhan.ChuyenNhiPhanSangSo(Chuoi);
            MaNhiPhan ketQua = this.Cat(0, DoDaiMangMaNhiPhan() - 64); 
            if (so < 0 || so > ketQua.DoDaiMangMaNhiPhan())
                return null;
            ketQua = ketQua.Cat(0, so);
            return ketQua;
        }

        public MaNhiPhan XOR(MaNhiPhan Chuoi)
        {
            if (DoDaiMangMaNhiPhan() != Chuoi.DoDaiMangMaNhiPhan())
                return null;
            MaNhiPhan ketQua = new MaNhiPhan(DoDaiMangMaNhiPhan());
            int x = 0, y = 0;
            for (int i = 0; i < ketQua.DoDaiMangMaNhiPhan(); i++)
            {
                x = MangMaNhiPhan[i];
                y = Chuoi.MangMaNhiPhan[i];
                if (x != y) 
                {
                    ketQua.MangMaNhiPhan[i] = 1;
                }
                else
                {
                    ketQua.MangMaNhiPhan[i] = 0;
                }
            }
            return ketQua;
        }


        public MaNhiPhan DichTraiBit(int so)
        {
            MaNhiPhan ketQua = new MaNhiPhan(MangMaNhiPhan);
            int tam = 0;
            for (int i = 0; i < so; i++) 
            {
                tam = MangMaNhiPhan[0];
                for (int j = 0; j < MangMaNhiPhan.Length - 1; j++)
                {
                    ketQua.MangMaNhiPhan[j] = MangMaNhiPhan[j + 1]; 
                }
                ketQua.MangMaNhiPhan[MangMaNhiPhan.Length - 1] = tam; 
            }
            return (ketQua);
        }

        public MaNhiPhan Cong(MaNhiPhan chuoi)
        {
            MaNhiPhan ketQua = new MaNhiPhan(chuoi.DoDaiMangMaNhiPhan() + this.DoDaiMangMaNhiPhan());
            for (int i = 0; i < DoDaiMangMaNhiPhan(); i++)
            {
                ketQua.MangMaNhiPhan[i] = MangMaNhiPhan[i];
            }
            for (int i = 0; i < chuoi.DoDaiMangMaNhiPhan(); i++)
            {
                ketQua.MangMaNhiPhan[DoDaiMangMaNhiPhan() + i] = chuoi.MangMaNhiPhan[i];
            }
            return ketQua; 
        }

        public MaNhiPhan[] Chia()
        {
            MaNhiPhan Trai = new MaNhiPhan(this.DoDaiMangMaNhiPhan() / 2);
            MaNhiPhan Phai = new MaNhiPhan(DoDaiMangMaNhiPhan() - Trai.DoDaiMangMaNhiPhan());
            for (int i = 0; i < Trai.DoDaiMangMaNhiPhan(); i++)
            {
                Trai.MangMaNhiPhan[i] = MangMaNhiPhan[i];
            }
            for (int i = 0; i < Phai.DoDaiMangMaNhiPhan(); i++)
            {
                Phai.MangMaNhiPhan[i] = MangMaNhiPhan[i + Trai.DoDaiMangMaNhiPhan()];
            }
            return (new MaNhiPhan[] { Trai, Phai });
        }

        public MaNhiPhan[] Chia(int so)
        {
            MaNhiPhan[] ketQua = new MaNhiPhan[so];
            MaNhiPhan chuoi;
            int Bit = DoDaiMangMaNhiPhan() / so;
            int[] maNP = new int[Bit];
            int leng = Bit;
            for (int i = 0; i < so; i++)
            {
                if (i * Bit + Bit > DoDaiMangMaNhiPhan())
                {
                    Bit = DoDaiMangMaNhiPhan() - i * Bit;
                }
                maNP = new int[Bit];
                for (int j = i * Bit; j < i * Bit + Bit; j++)
                {
                    maNP[j - i * Bit] = MangMaNhiPhan[j];
                }
                chuoi = new MaNhiPhan(maNP);
                ketQua[i] = chuoi;
            }
            return (ketQua);
        }

        public static MaNhiPhan ChuyenSoSangMangNhiPhan(int So, int doDai)
        {
            MaNhiPhan chuoi = new MaNhiPhan(doDai);
            int i = doDai - 1;
            while (So > 0)
            {
                chuoi.MangMaNhiPhan[i] = So % 2;
                So = So / 2;
                i--;
            }
            return chuoi;
        }

        public static int[] ChuyenSoSangMangMaNhiPhan(int So, int doDai)
        {
            int[] MangNP = new int[doDai];
            int i = doDai - 1;
            while (So > 0)
            {
                MangNP[i] = So % 2;
                So = So / 2;
                i--;
            }
            return MangNP;
        }

        public static string ChuyenSoSangStringNhiPhan(int So, int doDai)
        {
            return ChuyenSoSangMangNhiPhan(So, doDai).VanBan;
        }

        public static int ChuyenNhiPhanSangSo(MaNhiPhan chuoi)
        {
            int ketQua = 0;
            for (int i = chuoi.DoDaiMangMaNhiPhan() - 1; i >= 0; i--)
            {
                ketQua += chuoi.MangMaNhiPhan[i] * (int)Math.Pow(2, chuoi.DoDaiMangMaNhiPhan() - i - 1);
            }
            return ketQua;
        }

        public static MaNhiPhan ChuyenChuSangChuoiNhiPhan(string chuoi)
        {
            try
            {
                chuoi = chuoi.Trim();
                int[] MangNP = new int[chuoi.Length];
                for (int i = chuoi.Length - 1; i >= 0; i--)
                {
                    MangNP[i] = int.Parse(chuoi[i].ToString());
                }
                return (new MaNhiPhan(MangNP));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo");
                return null;
            }

        }

        public static int ChuyenMangSangByte(int[] mang, int dau, int cuoi)
        {
            int ketQua = 0;
            for (int i = cuoi - 1; i >= dau; i--)
            {
                ketQua += mang[i] * (int)Math.Pow(2, cuoi - i - 1);
            }
            return ketQua;
        }

        public static int ChuyenNhiPhanSangSo(string chuoi)
        {
            int ketQua = 0;
            for (int i = chuoi.Length - 1; i >= 0; i--)
            {
                ketQua += int.Parse(chuoi[i].ToString()) * (int)Math.Pow(2, chuoi.Length - i - 1);
            }
            return ketQua;
        }

        public static string ChuyenNhiPhanSangChu(MaNhiPhan chuoi)
        {
            int tongSoChu = chuoi.DoDaiMangMaNhiPhan() / 16;
            MaNhiPhan[] Mang = chuoi.Chia(tongSoChu);
            string ketQua = "";
            foreach (var ch in Mang)
            {
                ketQua += (char)ChuyenNhiPhanSangSo(ch);
            }
            return ketQua;
        }

        public static MaNhiPhan ChuyenChuSangNhiPhan(string str)
        {
            MaNhiPhan ketQua = new MaNhiPhan(0);
            MaNhiPhan chuoi;
            foreach (var ch in str)
            {
                chuoi = new MaNhiPhan(ch);
                ketQua = ketQua.Cong(chuoi);
            }
            return ketQua;
        }

        public static MaNhiPhan ChuyenKhoaSangNhiPhan(string str)
        {
            MaNhiPhan ketQua = new MaNhiPhan(0);
            MaNhiPhan chuoi;
            foreach (var ch in str)
            {
                chuoi = MaNhiPhan.ChuyenSoSangMangNhiPhan((int)ch, 16);
                ketQua = ketQua.Cong(chuoi);
            }
            return ketQua;
        }

    }
}