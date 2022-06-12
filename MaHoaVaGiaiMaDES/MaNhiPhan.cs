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
        private int[] mangNhiPhan;
        private string _vanBan;

        public int[] MangNhiPhan { get => mangNhiPhan; set => mangNhiPhan = value; }
        public string _VanBan { get => _vanBan; set => _vanBan = value; }

        public int DoDaiMaNhiPhan()
        {
            return MangNhiPhan.Length;
        }

        public MaNhiPhan(int doDai)
        {
            MangNhiPhan = new int[doDai];
        }

        public MaNhiPhan(int[] maNhiPhan)
        {
            this.MangNhiPhan = maNhiPhan;
        }

        public MaNhiPhan(char kyTu)
        {
            MangNhiPhan = new int[16];
            int MaUnicode = (int)kyTu;
            int i = 15;
            while (MaUnicode > 0)
            {
                MangNhiPhan[i] = MaUnicode % 2;
                MaUnicode = MaUnicode / 2;
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
            foreach (var ch in MangNhiPhan)
            {
                str += ch.ToString();
            }
            return str;
        }

        public MaNhiPhan Cat(long viTriBatDau, long SoLuong)
        {
            int[] mangNhiPhanDuocCat = new int[SoLuong];
            for (long i = viTriBatDau; i < viTriBatDau + SoLuong; i++)
            {
                mangNhiPhanDuocCat[i - viTriBatDau] = MangNhiPhan[i];
            }
            return (new MaNhiPhan(mangNhiPhanDuocCat));
        }

        public MaNhiPhan ChinhDoDai64()
        {
            int Mod = DoDaiMaNhiPhan() % 64;
            int thieu = 64 - Mod;
            MaNhiPhan chuoiBuThieu = new MaNhiPhan(thieu);
            MaNhiPhan KQ = new MaNhiPhan(MangNhiPhan);
            KQ = KQ.Cong(chuoiBuThieu);

            MaNhiPhan ChuoiChieuDai = MaNhiPhan.ChuyenSoSangNhiPhan((int)DoDaiMaNhiPhan(), 64);
            KQ = KQ.Cong(ChuoiChieuDai);
            return KQ;
        }

        public MaNhiPhan CatDuLieu64()
        {
            MaNhiPhan ChuoiChieuDai = this.Cat(DoDaiMaNhiPhan() - 64, 64);
            long d = MaNhiPhan.ChuyenNhiPhanSangSo(ChuoiChieuDai);
            MaNhiPhan KQ = this.Cat(0, DoDaiMaNhiPhan() - 64); 
            if (d < 0 || d > KQ.DoDaiMaNhiPhan())
                return null;
            KQ = KQ.Cat(0, d);
            return KQ;
        }

        public MaNhiPhan XOR(MaNhiPhan Chuoi2)
        {
            if (DoDaiMaNhiPhan() != Chuoi2.DoDaiMaNhiPhan())
                return null;
            MaNhiPhan ChuoiKQ = new MaNhiPhan(DoDaiMaNhiPhan());
            int x = 0, y = 0;
            for (int i = 0; i < ChuoiKQ.DoDaiMaNhiPhan(); i++)
            {
                x = MangNhiPhan[i];
                y = Chuoi2.MangNhiPhan[i];
                if (x != y) 
                {
                    ChuoiKQ.MangNhiPhan[i] = 1;
                }
                else
                {
                    ChuoiKQ.MangNhiPhan[i] = 0;
                }
            }
            return ChuoiKQ;
        }


        public MaNhiPhan DichTraiBit(int SoBitDich)
        {
            MaNhiPhan KQ = new MaNhiPhan(MangNhiPhan);
            int tam = 0;
            for (int i = 0; i < SoBitDich; i++) 
            {
                tam = MangNhiPhan[0];
                for (int j = 0; j < MangNhiPhan.Length - 1; j++)
                {
                    KQ.MangNhiPhan[j] = MangNhiPhan[j + 1]; 
                }
                KQ.MangNhiPhan[MangNhiPhan.Length - 1] = tam; 
            }
            return (KQ);
        }

        public MaNhiPhan Cong(MaNhiPhan chuoi2)
        {
            MaNhiPhan ChuoiKQ = new MaNhiPhan(chuoi2.DoDaiMaNhiPhan() + this.DoDaiMaNhiPhan());
            for (int i = 0; i < DoDaiMaNhiPhan(); i++)
            {
                ChuoiKQ.MangNhiPhan[i] = MangNhiPhan[i];
            }
            for (int i = 0; i < chuoi2.DoDaiMaNhiPhan(); i++)
            {
                ChuoiKQ.MangNhiPhan[DoDaiMaNhiPhan() + i] = chuoi2.MangNhiPhan[i];
            }
            return ChuoiKQ; 
        }

        public MaNhiPhan[] ChiaDoi()
        {
            MaNhiPhan ChuoiTrai = new MaNhiPhan(this.DoDaiMaNhiPhan() / 2);
            MaNhiPhan ChuoiPhai = new MaNhiPhan(DoDaiMaNhiPhan() - ChuoiTrai.DoDaiMaNhiPhan());
            for (int i = 0; i < ChuoiTrai.DoDaiMaNhiPhan(); i++)
            {
                ChuoiTrai.MangNhiPhan[i] = MangNhiPhan[i];
            }
            for (int i = 0; i < ChuoiPhai.DoDaiMaNhiPhan(); i++)
            {
                ChuoiPhai.MangNhiPhan[i] = MangNhiPhan[i + ChuoiTrai.DoDaiMaNhiPhan()];
            }
            return (new MaNhiPhan[] { ChuoiTrai, ChuoiPhai });
        }

        public MaNhiPhan[] Chia(int SoLuong)
        {
            MaNhiPhan[] KQ = new MaNhiPhan[SoLuong];
            MaNhiPhan chuoi;
            int SoBit = DoDaiMaNhiPhan() / SoLuong;
            int[] NhiPhan = new int[SoBit];
            int leng = SoBit;
            for (int i = 0; i < SoLuong; i++)
            {
                if (i * SoBit + SoBit > DoDaiMaNhiPhan())
                {
                    SoBit = DoDaiMaNhiPhan() - i * SoBit;
                }
                NhiPhan = new int[SoBit];
                for (int j = i * SoBit; j < i * SoBit + SoBit; j++)
                {
                    NhiPhan[j - i * SoBit] = MangNhiPhan[j];
                }
                chuoi = new MaNhiPhan(NhiPhan);
                KQ[i] = chuoi;
            }
            return (KQ);
        }

        public static MaNhiPhan ChuyenSoSangNhiPhan(int SoInput, int doDai)
        {
            MaNhiPhan ChuoiKQ = new MaNhiPhan(doDai);
            int i = doDai - 1;
            while (SoInput > 0)
            {
                ChuoiKQ.MangNhiPhan[i] = SoInput % 2;
                SoInput = SoInput / 2;
                i--;
            }
            return ChuoiKQ;
        }

        public static int[] ChuyenSoSangMangNhiPhan(int SoInput, int doDai)
        {
            int[] MangNhiPhan = new int[doDai];
            int i = doDai - 1;
            while (SoInput > 0)
            {
                MangNhiPhan[i] = SoInput % 2;
                SoInput = SoInput / 2;
                i--;
            }
            return MangNhiPhan;
        }

        public static string ChuyenSoSangStringNhiPhan(int SoInput, int doDai)
        {
            return ChuyenSoSangNhiPhan(SoInput, doDai).VanBan;
        }

        public static int ChuyenNhiPhanSangSo(MaNhiPhan ChuoiVao)
        {
            int KQ = 0;
            for (int i = ChuoiVao.DoDaiMaNhiPhan() - 1; i >= 0; i--)
            {
                KQ += ChuoiVao.MangNhiPhan[i] * (int)Math.Pow(2, ChuoiVao.DoDaiMaNhiPhan() - i - 1);
            }
            return KQ;
        }

        public static MaNhiPhan ChuyenChuSangChuoiNhiPhan(string ChuoiVao)
        {
            try
            {
                ChuoiVao = ChuoiVao.Trim();
                int[] mangNhiPhan = new int[ChuoiVao.Length];
                for (int i = ChuoiVao.Length - 1; i >= 0; i--)
                {
                    mangNhiPhan[i] = int.Parse(ChuoiVao[i].ToString());
                }
                return (new MaNhiPhan(mangNhiPhan));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo");
                return null;
            }

        }

        public static int ChuyenMangSangByte(int[] mang, int batDau, int KetThuc)
        {
            int KQ = 0;
            for (int i = KetThuc - 1; i >= batDau; i--)
            {
                KQ += mang[i] * (int)Math.Pow(2, KetThuc - i - 1);
            }
            return KQ;
        }

        public static int ChuyenNhiPhanSangSo(string ChuoiVao)
        {
            int KQ = 0;
            for (int i = ChuoiVao.Length - 1; i >= 0; i--)
            {
                KQ += int.Parse(ChuoiVao[i].ToString()) * (int)Math.Pow(2, ChuoiVao.Length - i - 1);
            }
            return KQ;
        }

        public static string ChuyenNhiPhanSangChu(MaNhiPhan ChuoiVao)
        {
            int soChu = ChuoiVao.DoDaiMaNhiPhan() / 16;
            MaNhiPhan[] MangChuoi = ChuoiVao.Chia(soChu);
            string KQ = "";
            foreach (var ch in MangChuoi)
            {
                KQ += (char)ChuyenNhiPhanSangSo(ch);
            }
            return KQ;
        }

        public static MaNhiPhan ChuyenChuSangNhiPhan(string text)
        {
            MaNhiPhan KQ = new MaNhiPhan(0);
            MaNhiPhan chuoi;
            foreach (var ch in text)
            {
                chuoi = new MaNhiPhan(ch);
                KQ = KQ.Cong(chuoi);
            }
            return KQ;
        }

        public static MaNhiPhan ChuyenKhoaSangNhiPhan(string text)
        {
            MaNhiPhan KQ = new MaNhiPhan(0);
            MaNhiPhan chuoi;
            foreach (var ch in text)
            {
                chuoi = MaNhiPhan.ChuyenSoSangNhiPhan((int)ch, 16);
                KQ = KQ.Cong(chuoi);
            }
            return KQ;
        }

    }
}