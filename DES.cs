using MaHoaDES.MaHoaVaGiaiMaDES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace MaHoaDES
{
    public partial class DES : Form
    {
        private List<ThanhVien> listTV = new List<ThanhVien>();
        bool check = true; // file là true - false là văn bản.
        bool phuongPhap = true; // true là mã hóa - false là giải mã.
        TinhDES tinhDes;
        Khoa khoaK;

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
                            biMat.Add(random.Next(0, (int)ChiaSeBiMat.Instance.NguyenToP));
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
                        if (ChiaSeBiMat.Instance.ThanhVien != null)
                        {
                            ChiaSeBiMat.Instance.ThanhVien.Clear();
                            lstvThanhVien.Items.Clear();
                            lstvThanhVienMoKhoa.Items.Clear();
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
            check = false;
            phuongPhap = true;
            des();
        }

        private void btnGiaiMa_Click(object sender, EventArgs e)
        {
            check = false;
            phuongPhap = false;
            des();
        }

        private void btnMaHoaFile_Click(object sender, EventArgs e)
        {
            check = true;
            phuongPhap = true;
            des();
        }

        private void btnGiaiMaFile_Click(object sender, EventArgs e)
        {
            check = true;
            phuongPhap = false;
            des();
        }

        private void des()
        {
            tinhDes = new TinhDES();

            if(check) // true là file
            {
                khoaK = new Khoa(txtKhoaFile.Text);
                if(phuongPhap) // true là mã hóa
                {
                    MaNhiPhan file = docFile(txtDuongDanFile.Text);
                    MaNhiPhan noiDungFile = TinhDES.ThucHienDES(khoaK, file, true);
                    ghifile(txtDuongDanFile.Text.Replace(".", "_new."), noiDungFile);
                    lbDem.Text = "Hoàn thành";
                    MessageBox.Show("Mã hóa thành công!", "Thông báo");
                }
                else // false là giải mã.
                {
                    MaNhiPhan file = docFile(txtDuongDanFile.Text);
                    MaNhiPhan noiDungFile = TinhDES.ThucHienDES(khoaK, file, false);
                    if (noiDungFile == null)
                    {
                        MessageBox.Show("Lỗi! Nội dung file là null", "Thông báo");
                        return;
                    }
                    ghifile(txtDuongDanFile.Text.Replace(".", "_new."), noiDungFile);
                    lbDem.Text = "Hoàn thành";
                    MessageBox.Show("Giải mã thành công!", "Thông báo");
                }
            } else // false là văn bản
            {
                khoaK = new Khoa(txtKhoaVanBan.Text);
                if (phuongPhap) // true là mã hóa
                {
                    txtNoiDungVanBanSau.Text = TinhDES.ThucHienDESChuoi(khoaK, txtNoiDungVanBanTruoc.Text, true);
                    MessageBox.Show("Mã hóa thành công!", "Thông báo");
                }
                else // false là giải mã.
                {
                    txtNoiDungVanBanSau.Text = TinhDES.ThucHienDESChuoi(khoaK, txtNoiDungVanBanTruoc.Text, false);
                    MessageBox.Show("Giải mã thành công!", "Thông báo");
                }
            }
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                txtDuongDanFile.Clear();
                txtDuongDanFile.Enabled = false;
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    txtDuongDanFile.Text = open.FileName;
                    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                    Document document = app.Documents.Open(open.FileName);

                    txtNoiDungFile.Text = document.Content.Text;
                    app.Quit();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("File đã bị hỏng do mã hóa có thể vẫn giải mã được.", "Thông báo");
            }

        }

        public void ghifile(string fileName, MaNhiPhan noiDung)
        {
            byte[] bytes = new byte[noiDung.MangMaNhiPhan.Length / 8];
            for (int i = 0; i < noiDung.MangMaNhiPhan.Length / 8; i++)
            {
                bytes[i] = (byte)MaNhiPhan.ChuyenMangSangByte(noiDung.MangMaNhiPhan, i * 8, i * 8 + 8);
            }
            File.WriteAllBytes(fileName, bytes);

        }

        public MaNhiPhan docFile(string fileName)
        {
            if(fileName != "")
            {
                int doDai = 8;
                MaNhiPhan chuoi;
                MaNhiPhan ketQua = new MaNhiPhan(0);
                byte[] fileBytes = File.ReadAllBytes(fileName);
                foreach (byte items in fileBytes)
                {
                    chuoi = MaNhiPhan.ChuyenSoSangMangNhiPhan(items, doDai);
                    ketQua = ketQua.Cong(chuoi);
                }
                return ketQua;
            }

            return null;

        }
    }
}