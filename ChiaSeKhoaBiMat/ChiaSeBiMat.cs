using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaHoaDES
{
    public class ChiaSeBiMat
    {
        private int khoaChiaSe;
        private int nguyenToP;
        private int thanhVienGiuKhoa;
        private int thanhVienMoKhoa;
        private List<ThanhVien> thanhVien;
        private List<int> biMat;
        private static ChiaSeBiMat instance;
        public int ThanhVienMoKhoa { get => thanhVienMoKhoa; set => thanhVienMoKhoa = value; }
        public int ThanhVienGiuKhoa { get => thanhVienGiuKhoa; set => thanhVienGiuKhoa = value; }
        public int NguyenToP { get => nguyenToP; set => nguyenToP = value; }
        public int KhoaChiaSe { get => khoaChiaSe; set => khoaChiaSe = value; }
        public List<ThanhVien> ThanhVien { get => thanhVien; set => thanhVien = value; }
        public List<int> BiMat { get => biMat; set => biMat = value; }
        public static ChiaSeBiMat Instance { 
            get
            {
                if(instance == null)
                {
                    instance = new ChiaSeBiMat();
                }
                return instance;
            }
            private set => instance = value; 
        }

        public ChiaSeBiMat() { }
        public ChiaSeBiMat(int khoaChiaSe, int nguyenToP, int thanhVienGiuKhoa, int thanhVienMoKhoa, List<ThanhVien> thanhVien)
        {
            KhoaChiaSe = khoaChiaSe;
            NguyenToP = nguyenToP;
            ThanhVienGiuKhoa = thanhVienGiuKhoa;
            ThanhVienMoKhoa = thanhVienMoKhoa;
            ThanhVien = thanhVien;
        }
    }
}
