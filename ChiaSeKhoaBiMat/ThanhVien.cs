using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaHoaDES
{
    public class ThanhVien
    {
        private BigInteger xi;
        private BigInteger pi;

        public BigInteger Pi { get => pi; set => pi = value; }
        public BigInteger Xi { get => xi; set => xi = value; }

        public ThanhVien(){ }

        public ThanhVien(BigInteger xi, BigInteger pi)
        {
            this.Xi = xi;
            this.Pi = pi;
        }
        
    }
}
