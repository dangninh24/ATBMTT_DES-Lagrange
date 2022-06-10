namespace MaHoaDES
{
    partial class MaHoa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbThongBao = new System.Windows.Forms.Label();
            this.lstvThanhVienMoKhoa = new System.Windows.Forms.ListView();
            this.XiNew = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PiNew = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnKhoiPhucKhoa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstvThanhVien = new System.Windows.Forms.ListView();
            this.Xi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnNhapLai = new System.Windows.Forms.Button();
            this.btnChiaSeKhoa = new System.Windows.Forms.Button();
            this.txtGiaTriP = new System.Windows.Forms.TextBox();
            this.txtSoThanhVienMoKhoa = new System.Windows.Forms.TextBox();
            this.txtSoThanhVienGiuKhoa = new System.Windows.Forms.TextBox();
            this.txtKhoaChiaSe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.luachon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 599);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 573);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mã hóa DES";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1000, 573);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chia sẻ khóa bí mật";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbThongBao);
            this.groupBox2.Controls.Add(this.lstvThanhVienMoKhoa);
            this.groupBox2.Controls.Add(this.btnKhoiPhucKhoa);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(517, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 522);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ghép khóa";
            // 
            // lbThongBao
            // 
            this.lbThongBao.AutoSize = true;
            this.lbThongBao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbThongBao.ForeColor = System.Drawing.Color.Red;
            this.lbThongBao.Location = new System.Drawing.Point(6, 403);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(0, 19);
            this.lbThongBao.TabIndex = 1;
            // 
            // lstvThanhVienMoKhoa
            // 
            this.lstvThanhVienMoKhoa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.luachon,
            this.XiNew,
            this.PiNew});
            this.lstvThanhVienMoKhoa.FullRowSelect = true;
            this.lstvThanhVienMoKhoa.GridLines = true;
            this.lstvThanhVienMoKhoa.HideSelection = false;
            this.lstvThanhVienMoKhoa.Location = new System.Drawing.Point(6, 21);
            this.lstvThanhVienMoKhoa.Name = "lstvThanhVienMoKhoa";
            this.lstvThanhVienMoKhoa.Size = new System.Drawing.Size(462, 342);
            this.lstvThanhVienMoKhoa.TabIndex = 11;
            this.lstvThanhVienMoKhoa.UseCompatibleStateImageBehavior = false;
            this.lstvThanhVienMoKhoa.View = System.Windows.Forms.View.Details;
            this.lstvThanhVienMoKhoa.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstvThanhVienMoKhoa_ItemChecked);
            // 
            // XiNew
            // 
            this.XiNew.Text = "Xi";
            this.XiNew.Width = 180;
            // 
            // PiNew
            // 
            this.PiNew.DisplayIndex = 2;
            this.PiNew.Text = "Pi";
            this.PiNew.Width = 180;
            // 
            // btnKhoiPhucKhoa
            // 
            this.btnKhoiPhucKhoa.Location = new System.Drawing.Point(187, 477);
            this.btnKhoiPhucKhoa.Name = "btnKhoiPhucKhoa";
            this.btnKhoiPhucKhoa.Size = new System.Drawing.Size(113, 23);
            this.btnKhoiPhucKhoa.TabIndex = 0;
            this.btnKhoiPhucKhoa.Text = "Khôi phục khóa";
            this.btnKhoiPhucKhoa.UseVisualStyleBackColor = true;
            this.btnKhoiPhucKhoa.Click += new System.EventHandler(this.btnKhoiPhucKhoa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(129, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(765, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHƯƠNG TRÌNH CHIA SẺ KHÓA BÍ MẬT DỰA VÀO SƠ ĐỒ NGƯỠNG SHAMIR";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstvThanhVien);
            this.groupBox1.Controls.Add(this.btnNhapLai);
            this.groupBox1.Controls.Add(this.btnChiaSeKhoa);
            this.groupBox1.Controls.Add(this.txtGiaTriP);
            this.groupBox1.Controls.Add(this.txtSoThanhVienMoKhoa);
            this.groupBox1.Controls.Add(this.txtSoThanhVienGiuKhoa);
            this.groupBox1.Controls.Add(this.txtKhoaChiaSe);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(6, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 522);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chìa khóa";
            // 
            // lstvThanhVien
            // 
            this.lstvThanhVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Xi,
            this.Pi});
            this.lstvThanhVien.FullRowSelect = true;
            this.lstvThanhVien.GridLines = true;
            this.lstvThanhVien.HideSelection = false;
            this.lstvThanhVien.Location = new System.Drawing.Point(6, 254);
            this.lstvThanhVien.Name = "lstvThanhVien";
            this.lstvThanhVien.Size = new System.Drawing.Size(493, 262);
            this.lstvThanhVien.TabIndex = 10;
            this.lstvThanhVien.UseCompatibleStateImageBehavior = false;
            this.lstvThanhVien.View = System.Windows.Forms.View.Details;
            // 
            // Xi
            // 
            this.Xi.Text = "Xi";
            this.Xi.Width = 246;
            // 
            // Pi
            // 
            this.Pi.Text = "Pi";
            this.Pi.Width = 246;
            // 
            // btnNhapLai
            // 
            this.btnNhapLai.Location = new System.Drawing.Point(254, 225);
            this.btnNhapLai.Name = "btnNhapLai";
            this.btnNhapLai.Size = new System.Drawing.Size(113, 23);
            this.btnNhapLai.TabIndex = 9;
            this.btnNhapLai.Text = "Nhập lại";
            this.btnNhapLai.UseVisualStyleBackColor = true;
            this.btnNhapLai.Click += new System.EventHandler(this.btnNhapLai_Click);
            // 
            // btnChiaSeKhoa
            // 
            this.btnChiaSeKhoa.Location = new System.Drawing.Point(99, 225);
            this.btnChiaSeKhoa.Name = "btnChiaSeKhoa";
            this.btnChiaSeKhoa.Size = new System.Drawing.Size(113, 23);
            this.btnChiaSeKhoa.TabIndex = 8;
            this.btnChiaSeKhoa.Text = "Chia sẻ khóa";
            this.btnChiaSeKhoa.UseVisualStyleBackColor = true;
            this.btnChiaSeKhoa.Click += new System.EventHandler(this.btnChiaSeKhoa_Click);
            // 
            // txtGiaTriP
            // 
            this.txtGiaTriP.Location = new System.Drawing.Point(297, 145);
            this.txtGiaTriP.Name = "txtGiaTriP";
            this.txtGiaTriP.Size = new System.Drawing.Size(147, 22);
            this.txtGiaTriP.TabIndex = 7;
            // 
            // txtSoThanhVienMoKhoa
            // 
            this.txtSoThanhVienMoKhoa.Location = new System.Drawing.Point(297, 112);
            this.txtSoThanhVienMoKhoa.Name = "txtSoThanhVienMoKhoa";
            this.txtSoThanhVienMoKhoa.Size = new System.Drawing.Size(147, 22);
            this.txtSoThanhVienMoKhoa.TabIndex = 6;
            // 
            // txtSoThanhVienGiuKhoa
            // 
            this.txtSoThanhVienGiuKhoa.Location = new System.Drawing.Point(297, 79);
            this.txtSoThanhVienGiuKhoa.Name = "txtSoThanhVienGiuKhoa";
            this.txtSoThanhVienGiuKhoa.Size = new System.Drawing.Size(147, 22);
            this.txtSoThanhVienGiuKhoa.TabIndex = 5;
            // 
            // txtKhoaChiaSe
            // 
            this.txtKhoaChiaSe.Location = new System.Drawing.Point(297, 45);
            this.txtKhoaChiaSe.Name = "txtKhoaChiaSe";
            this.txtKhoaChiaSe.Size = new System.Drawing.Size(147, 22);
            this.txtKhoaChiaSe.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(6, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Giá trị P";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(6, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số thành viên có thể mở khóa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số thành viên giữ khóa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Khóa cần chia sẻ";
            // 
            // luachon
            // 
            this.luachon.Text = "Lựa chọn";
            this.luachon.Width = 100;
            // 
            // MaHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 623);
            this.Controls.Add(this.tabControl1);
            this.Name = "MaHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGiaTriP;
        private System.Windows.Forms.TextBox txtSoThanhVienMoKhoa;
        private System.Windows.Forms.TextBox txtSoThanhVienGiuKhoa;
        private System.Windows.Forms.TextBox txtKhoaChiaSe;
        private System.Windows.Forms.Button btnNhapLai;
        private System.Windows.Forms.Button btnChiaSeKhoa;
        private System.Windows.Forms.Button btnKhoiPhucKhoa;
        private System.Windows.Forms.ListView lstvThanhVienMoKhoa;
        private System.Windows.Forms.ListView lstvThanhVien;
        private System.Windows.Forms.ColumnHeader Xi;
        private System.Windows.Forms.ColumnHeader Pi;
        private System.Windows.Forms.ColumnHeader XiNew;
        private System.Windows.Forms.ColumnHeader PiNew;
        private System.Windows.Forms.Label lbThongBao;
        private System.Windows.Forms.ColumnHeader luachon;
    }
}

