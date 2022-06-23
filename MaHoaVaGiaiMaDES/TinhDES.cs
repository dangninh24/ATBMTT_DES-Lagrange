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
        private static Khoa KhoaDES { get; set; }


        public static MaNhiPhan ThucHienDES(Khoa khoa, MaNhiPhan Chuoi, bool check)
        {
            KhoaDES = khoa;
            if (check == true)
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
                    F = HamF(R, KhoaDES.DayKhoaPhu[check == true ? i : 15 - i]);
                    L = L.XOR(F);
                    TG = L;
                    L = R;
                    R = TG;
                }
                SauIP_1 = CacChuanDES.TinhIP_1(R, L);

                ChuoiKetQua = ChuoiKetQua.Cong(SauIP_1);
            }
            if (check == false)
                ChuoiKetQua = ChuoiKetQua.Cat();
            return ChuoiKetQua;
        }

        public static string ThucHienDESChuoi(Khoa key, string Chuoi, bool check)
        {
            MaNhiPhan chuoi;
            if (check == true)
            {
                chuoi = MaNhiPhan.ChuyenChuSangNhiPhan(Chuoi);
            }
            else
            {
                chuoi = MaNhiPhan.ChuyenChuSangChuoiNhiPhan(Chuoi);
            }
            MaNhiPhan ketQua = ThucHienDES(key, chuoi, check);
            if (check == true)
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

        private static MaNhiPhan HamF(MaNhiPhan chuoi, MaNhiPhan Khoa)
        {
            MaNhiPhan ketQua = CacChuanDES.TinhE(chuoi);
            ketQua = ketQua.XOR(Khoa); 
            ketQua = CacChuanDES.TinhS_Box(ketQua);
            ketQua = CacChuanDES.TinhP(ketQua); 
            return ketQua;
        }
    }
}
