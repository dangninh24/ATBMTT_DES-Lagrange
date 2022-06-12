using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaHoaDES.MaHoaVaGiaiMaDES
{
    public class TinhDES
    {
        private Khoa KhoaDES;

        public Khoa KhoaDES1 { get => KhoaDES; set => KhoaDES = value; }

        public MaNhiPhan ThucHienDES(Khoa khoa, MaNhiPhan Chuoi, int check)
        {
            this.KhoaDES = khoa;
            if (check == 1)
                Chuoi = Chuoi.ChinhDoDai();

            KhoaDES.SinhKhoaCon();
            MaNhiPhan[] DSChuoi = Chuoi.Chia(Chuoi.DoDaiMangMaNhiPhan() / 64);
            MaNhiPhan ChuoiKetQua;
            ChuoiKetQua = new MaNhiPhan(0);
            MaNhiPhan[] SauIP;
            MaNhiPhan SauIP_1;
            MaNhiPhan L, R, F, TG;
            for (int k = 0; k < DSChuoi.Length; k++)
            {
                SauIP = CacChuanDES.TinhIP(DSChuoi[k]);
                L = SauIP[0];
                R = SauIP[1];

                for (int i = 0; i < 16; i++)
                {
                    F = HamF(R, KhoaDES.DayKhoaPhu[check == 1 ? i : 15 - i]);
                    L = L.XOR(F);
                    TG = L;
                    L = R;
                    R = TG;
                }
                SauIP_1 = CacChuanDES.TinhIP_1(R, L);

                ChuoiKetQua = ChuoiKetQua.Cong(SauIP_1);
            }
            if (check == -1)
                ChuoiKetQua = ChuoiKetQua.Cat();
            return ChuoiKetQua;
        }

        public string ThucHienDESChuoi(Khoa key, string Chuoi, int check)
        {
            MaNhiPhan chuoi;
            if (check == 1)
            {
                chuoi = MaNhiPhan.ChuyenChuSangNhiPhan(Chuoi);
            }
            else
            {
                chuoi = MaNhiPhan.ChuyenChuSangChuoiNhiPhan(Chuoi);
            }
            MaNhiPhan ketQua = ThucHienDES(key, chuoi, check);
            if (check == 1)
            {
                return ketQua.VanBan;
            }
            if (ketQua == null)
            {
                MessageBox.Show("Lỗi giải mã . kiểm tra khóa ");
                return "";
            }
            return MaNhiPhan.ChuyenNhiPhanSangChu(ketQua);
        }

        private MaNhiPhan HamF(MaNhiPhan chuoi, MaNhiPhan Khoa)
        {
            MaNhiPhan ketQua = CacChuanDES.TinhE(chuoi);
            ketQua = ketQua.XOR(Khoa); 
            ketQua = CacChuanDES.TinhS_Box(ketQua);
            ketQua = CacChuanDES.TinhP(ketQua); 
            return ketQua;
        }
    }
}
