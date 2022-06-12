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

        public MaNhiPhan ThucHienDES(Khoa key, MaNhiPhan ChuoiVaoDai, int MaHoaHayGiaiMa)
        {
            this.KhoaDES = key;
            if (MaHoaHayGiaiMa == 1)
                ChuoiVaoDai = ChuoiVaoDai.ChinhDoDai64();

            KhoaDES.SinhKhoaCon();
            MaNhiPhan[] DSChuoiVao = ChuoiVaoDai.Chia(ChuoiVaoDai.DoDaiMaNhiPhan() / 64);
            MaNhiPhan ChuoiVao, ChuoiKQ;
            ChuoiKQ = new MaNhiPhan(0);
            MaNhiPhan[] ChuoiSauIP;
            MaNhiPhan ChuoiSauIP_1;
            MaNhiPhan L, R, F, TG;
            for (int k = 0; k < DSChuoiVao.Length; k++)
            {
                ChuoiSauIP = CacChuanDES.TinhIP(DSChuoiVao[k]);
                L = ChuoiSauIP[0];
                R = ChuoiSauIP[1];

                for (int i = 0; i < 16; i++)
                {
                    F = HamF(R, KhoaDES.DayKhoaPhu[MaHoaHayGiaiMa == 1 ? i : 15 - i]);
                    L = L.XOR(F);
                    TG = L;
                    L = R;
                    R = TG;
                }
                ChuoiSauIP_1 = CacChuanDES.TinhIP_1(R, L);

                ChuoiKQ = ChuoiKQ.Cong(ChuoiSauIP_1);
            }
            if (MaHoaHayGiaiMa == -1) 
                ChuoiKQ = ChuoiKQ.CatDuLieu64();
            return ChuoiKQ;
        }

        public string ThucHienDESText(Khoa key, string ChuoiVao, int MaHoaHayGiaiMa)
        {
            MaNhiPhan chuoiNhiPhan;
            if (MaHoaHayGiaiMa == 1)
            {
                chuoiNhiPhan = MaNhiPhan.ChuyenChuSangNhiPhan(ChuoiVao);
            }
            else
            {
                chuoiNhiPhan = MaNhiPhan.ChuyenChuSangChuoiNhiPhan(ChuoiVao);
            }
            MaNhiPhan KQ = ThucHienDES(key, chuoiNhiPhan, MaHoaHayGiaiMa);
            if (MaHoaHayGiaiMa == 1)
            {
                return KQ.VanBan;
            }
            if (KQ == null)
            {
                MessageBox.Show("Lỗi giải mã . kiểm tra khóa ");
                return "";
            }
            return MaNhiPhan.ChuyenNhiPhanSangChu(KQ);
        }

        private MaNhiPhan HamF(MaNhiPhan chuoiVao, MaNhiPhan KhoaCon)
        {
            MaNhiPhan KQ = CacChuanDES.TinhE(chuoiVao);
            KQ = KQ.XOR(KhoaCon); 
            KQ = CacChuanDES.TinhS_Box(KQ);
            KQ = CacChuanDES.TinhP(KQ); 
            return KQ;
        }
    }
}
