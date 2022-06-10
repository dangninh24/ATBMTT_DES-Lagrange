using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaHoaDES
{
    public class ThanhVien
    {
        private int xi;
        private int pi;

        public int Pi { get => pi; set => pi = value; }
        public int Xi { get => xi; set => xi = value; }

        public ThanhVien(){ }

        public ThanhVien(int xi, int pi)
        {
            this.Xi = xi;
            this.Pi = pi;
        }
        
    }
}
