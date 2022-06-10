﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaHoaDES
{
    public partial class MaHoa : Form
    {
        private List<ThanhVien> listTV = new List<ThanhVien>();
        public MaHoa()
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
                    ChiaSeBiMat.Instance.KhoaChiaSe = int.Parse(txtKhoaChiaSe.Text.ToString());
                    ChiaSeBiMat.Instance.ThanhVienGiuKhoa = int.Parse(txtSoThanhVienGiuKhoa.Text.ToString());
                    ChiaSeBiMat.Instance.ThanhVienMoKhoa = int.Parse(txtSoThanhVienMoKhoa.Text.ToString());
                    if (ChiaSeBiMat.Instance.ThanhVienGiuKhoa < ChiaSeBiMat.Instance.ThanhVienMoKhoa)
                    {
                        MessageBox.Show("Số thành viên có thể mở khóa phải nhỏ hơn số thành viên giữ khóa.", "Thông báo");
                    }
                    else if (kiemTraNguyenTo(int.Parse(txtGiaTriP.Text.ToString())))
                    {
                        ChiaSeBiMat.Instance.NguyenToP = int.Parse(txtGiaTriP.Text.ToString());
                        List<int> biMat = new List<int>();

                        for (int i = 0; i < ChiaSeBiMat.Instance.ThanhVienMoKhoa - 1; i++)
                        {
                            Random random = new Random();
                            biMat.Add(random.Next(1, 10));
                        }

                        ChiaSeBiMat.Instance.BiMat = biMat;

                        List<ThanhVien> thanhVien = new List<ThanhVien>();
                        for (int i = 0; i < ChiaSeBiMat.Instance.ThanhVienGiuKhoa; i++)
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

        private int traoPi(int xi)
        {
            int Pi = 0;
            int i = 1;
            foreach (int bimat in ChiaSeBiMat.Instance.BiMat)
            {
                int tinh = (int)Math.Pow(xi, (double)(i));
                Pi += bimat * tinh;
                i++;
            }
            return Pi + ChiaSeBiMat.Instance.KhoaChiaSe;
        }

        private bool kiemTraNguyenTo(int so)
        {
            if (so > 1)
            {
                for (int i = 2; i <= Math.Sqrt(so); i++)
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
                int i = 0;
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
                int i = 0;
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
    }
}