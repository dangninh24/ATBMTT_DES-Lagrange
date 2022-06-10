using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MaHoaDES
{
    public class ChiaSeBiMat
    {
        private BigInteger khoaChiaSe;
        private BigInteger nguyenToP;
        private BigInteger thanhVienGiuKhoa;
        private BigInteger thanhVienMoKhoa;
        private List<ThanhVien> thanhVien;
        private List<BigInteger> biMat;
        private static ChiaSeBiMat instance;
        public BigInteger ThanhVienMoKhoa { get => thanhVienMoKhoa; set => thanhVienMoKhoa = value; }
        public BigInteger ThanhVienGiuKhoa { get => thanhVienGiuKhoa; set => thanhVienGiuKhoa = value; }
        public BigInteger NguyenToP { get => nguyenToP; set => nguyenToP = value; }
        public BigInteger KhoaChiaSe { get => khoaChiaSe; set => khoaChiaSe = value; }
        public List<ThanhVien> ThanhVien { get => thanhVien; set => thanhVien = value; }
        public List<BigInteger> BiMat { get => biMat; set => biMat = value; }
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
        public ChiaSeBiMat(BigInteger khoaChiaSe, BigInteger nguyenToP, BigInteger thanhVienGiuKhoa, BigInteger thanhVienMoKhoa, List<ThanhVien> thanhVien)
        {
            KhoaChiaSe = khoaChiaSe;
            NguyenToP = nguyenToP;
            ThanhVienGiuKhoa = thanhVienGiuKhoa;
            ThanhVienMoKhoa = thanhVienMoKhoa;
            ThanhVien = thanhVien;
        }
    }
}
