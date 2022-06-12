using MaHoaDES.MaHoaVaGiaiMaDES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaHoaDES
{
    public partial class DES : Form
    {
        private List<ThanhVien> listTV = new List<ThanhVien>();
        TinhDES TinhDES;
        Khoa KhoaK;
        public DES()
        {
            InitializeComponent();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtGiaTriP.Text = "";
            txtKhoaChiaSe.Text = "";
            txtSoThanhVienGiuKhoa.Text = "";
            txtSoThanhVienMoKhoa.Text = "";
            lstvThanhVienMoKhoa.Items.Clear();
            lstvThanhVien.Items.Clear();
            listTV.Clear();
            if (ChiaSeBiMat.Instance.ThanhVien != null)
            {
                ChiaSeBiMat.Instance.ThanhVien.Clear();
            }
            ChiaSeBiMat.Instance.ThanhVienMoKhoa = 0;
            ChiaSeBiMat.Instance.ThanhVienGiuKhoa = 0;
            ChiaSeBiMat.Instance.KhoaChiaSe = 0;
            ChiaSeBiMat.Instance.NguyenToP = 0;
        }

        private void btnKhoiPhucKhoa_Click(object sender, EventArgs e)
        {
            if (listTV.Count < ChiaSeBiMat.Instance.ThanhVienMoKhoa)
            {
                MessageBox.Show($"Bạn phải chọn ít nhất {ChiaSeBiMat.Instance.ThanhVienMoKhoa} thành viên.", "Thông báo");
            }
            else
            {
                float k = 0;
                for (int i = 0; i < ChiaSeBiMat.Instance.ThanhVienMoKhoa; i++)
                {
                    float tich = 1.0f;
                    for (int j = 0; j < ChiaSeBiMat.Instance.ThanhVienMoKhoa; j++)
                    {
                        if (j != i)
                        {
                            float b = (float)listTV[j].Xi - (float)listTV[i].Xi;
                            float n = (float)listTV[j].Xi / b;
                            tich = tich * n;
                        }
                    }

                    k = k + (float)listTV[i].Pi * tich;
                }
                lbThongBao.Text = $"Khóa bí mật là {k}";
            }

        }

        private void btnChiaSeKhoa_Click(object sender, EventArgs e)
        {
            if (txtKhoaChiaSe.Text.Equals("") || txtSoThanhVienGiuKhoa.Text.Equals("") || txtSoThanhVienMoKhoa.Text.Equals("") || txtGiaTriP.Text.Equals(""))
            {
                MessageBox.Show("Bạn nhập chưa đủ thông tin.", "Thông báo");
            }
            else
            {
                try
                {
                    ChiaSeBiMat.Instance.KhoaChiaSe = BigInteger.Parse(txtKhoaChiaSe.Text.ToString());
                    ChiaSeBiMat.Instance.ThanhVienGiuKhoa = BigInteger.Parse(txtSoThanhVienGiuKhoa.Text.ToString());
                    ChiaSeBiMat.Instance.ThanhVienMoKhoa = BigInteger.Parse(txtSoThanhVienMoKhoa.Text.ToString());
                    if (ChiaSeBiMat.Instance.ThanhVienGiuKhoa < ChiaSeBiMat.Instance.ThanhVienMoKhoa)
                    {
                        MessageBox.Show("Số thành viên có thể mở khóa phải nhỏ hơn số thành viên giữ khóa.", "Thông báo");
                    }
                    else if (kiemTraNguyenTo(BigInteger.Parse(txtGiaTriP.Text.ToString())))
                    {
                        ChiaSeBiMat.Instance.NguyenToP = BigInteger.Parse(txtGiaTriP.Text.ToString());
                        List<BigInteger> biMat = new List<BigInteger>();

                        for (BigInteger i = 0; i < ChiaSeBiMat.Instance.ThanhVienMoKhoa - 1; i++)
                        {
                            Random random = new Random();
                            biMat.Add(random.Next(1, 10));
                        }

                        ChiaSeBiMat.Instance.BiMat = biMat;

                        List<ThanhVien> thanhVien = new List<ThanhVien>();
                        for (BigInteger i = 0; i < ChiaSeBiMat.Instance.ThanhVienGiuKhoa; i++)
                        {
                            ThanhVien TV = new ThanhVien();
                            TV.Xi = i + 1;
                            TV.Pi = traoPi(TV.Xi);
                            thanhVien.Add(TV);
                        }

                        ChiaSeBiMat.Instance.ThanhVien = thanhVien;

                        lstvThanhVienMoKhoa.CheckBoxes = true;

                        foreach (ThanhVien thanhvien in ChiaSeBiMat.Instance.ThanhVien)
                        {
                            ListViewItem item = new ListViewItem(thanhvien.Xi.ToString());
                            item.SubItems.Add(thanhvien.Pi.ToString());
                            lstvThanhVien.Items.Add(item);
                        }

                        foreach (ThanhVien thanhvien in ChiaSeBiMat.Instance.ThanhVien)
                        {
                            ListViewItem item = new ListViewItem();
                            item.SubItems.Add(thanhvien.Xi.ToString());
                            item.SubItems.Add(thanhvien.Pi.ToString());
                            lstvThanhVienMoKhoa.Items.Add(item);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Giá trị P không phải số nguyên tố.", "Thông báo");
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Các trường nhập phải là số nguyên.", "Thông báo");
                }
            }
        }

        private BigInteger traoPi(BigInteger xi)
        {
            BigInteger Pi = 0;
            BigInteger i = 1;
            foreach (BigInteger bimat in ChiaSeBiMat.Instance.BiMat)
            {
                BigInteger tinh = (BigInteger)Math.Pow((double)xi, (double)(i));
                Pi += bimat * tinh;
                i++;
            }
            return Pi + ChiaSeBiMat.Instance.KhoaChiaSe;
        }

        private bool kiemTraNguyenTo(BigInteger so)
        {
            if (so > 1)
            {
                for (int i = 2; i <= Math.Sqrt((double)so); i++)
                {
                    if (so % i == 0)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        private void lstvThanhVienMoKhoa_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked == true)
            {
                BigInteger i = 0;
                foreach (ThanhVien thanhvien in ChiaSeBiMat.Instance.ThanhVien)
                {
                    if (e.Item.Index == i)
                    {
                        listTV.Add(thanhvien);
                        break;
                    }
                    i++;
                }
            }
            else
            {
                BigInteger i = 0;
                foreach (ThanhVien thanhvien in ChiaSeBiMat.Instance.ThanhVien)
                {
                    if (e.Item.Index == i)
                    {
                        listTV.Remove(thanhvien);
                        break;
                    }
                    i++;
                }
            }
        }

        private void btnMaHoa_Click(object sender, EventArgs e)
        {
            string maHoa = txtVanBanMaHoa.Text;
            string khoa = txtKhoaMaHoa.Text;
            

            if (maHoa.Equals("") || khoa.Equals(""))
            {
                MessageBox.Show("Văn bản hoặc khóa mã hóa không được để trống. ", "Thông báo");
            }
            else if (check(khoa, "Mã hóa"))
            {
                MaHoa();
            }
        }

        private void btnGiaiMa_Click(object sender, EventArgs e)
        {
            string giaiMa = txtVanBanGiaiMa.Text;
            string khoa = txtKhoaGiaiMa.Text;

            if (giaiMa.Equals("") || khoa.Equals(""))
            {
                MessageBox.Show("Văn bản hoặc khóa giải mã không được để trống. ", "Thông báo");
            } else if(check(khoa, "Giải mã"))
            {
                GiaiMa();
            }
        }

        private void MaHoa()
        {
            KhoaK = new Khoa(txtKhoaMaHoa.Text);
            TinhDES = new TinhDES();
            string kq = TinhDES.ThucHienDESText(KhoaK, txtVanBanMaHoa.Text, 1);
            txtMaHoa.Text = kq;
            if (kq == "")
            {
                return;
            }
            MessageBox.Show("Giải mã chuỗi thành công");
        }

        private void GiaiMa()
        {
            KhoaK = new Khoa(txtKhoaGiaiMa.Text);
            TinhDES = new TinhDES();
            string kq = TinhDES.ThucHienDESText(KhoaK, txtVanBanGiaiMa.Text, -1);
            txtGiaiMa.Text = kq;
            if (kq == "")
            {
                return;
            }
            MessageBox.Show("Giải mã chuỗi thành công");
        }

        private bool check(string khoa, string str)
        {
            if(khoa.Length == 16)
            {
                for(int i = 0; i < khoa.Length; i++)
                {
                    if (!((int)khoa[i] >= 48 && (int)khoa[i] <= 57) && !((int)khoa[i] >= 65 && (int)khoa[i] <= 70))
                    {
                        MessageBox.Show($"Khóa {str} phải có dạng HEX(16).");
                        return false;
                    }
                }
                return true;
            } else
            {
                MessageBox.Show($"Khóa {str} phải có dạng HEX(16).");
                return false;
            }
        }
    }
}