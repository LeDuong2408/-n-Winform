namespace GUI
{
    partial class frmThongTinNhanVien
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.lbNgayTuyenDung = new System.Windows.Forms.Label();
            this.lbChucVu = new System.Windows.Forms.Label();
            this.lbTrangThai = new System.Windows.Forms.Label();
            this.lbMaNV = new System.Windows.Forms.Label();
            this.pbAnh = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bthXoaQuyenQL = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnChonAnh);
            this.panel1.Controls.Add(this.lbNgayTuyenDung);
            this.panel1.Controls.Add(this.lbChucVu);
            this.panel1.Controls.Add(this.lbTrangThai);
            this.panel1.Controls.Add(this.lbMaNV);
            this.panel1.Controls.Add(this.pbAnh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 452);
            this.panel1.TabIndex = 0;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Location = new System.Drawing.Point(93, 210);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(85, 32);
            this.btnChonAnh.TabIndex = 10;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // lbNgayTuyenDung
            // 
            this.lbNgayTuyenDung.AutoSize = true;
            this.lbNgayTuyenDung.Location = new System.Drawing.Point(36, 379);
            this.lbNgayTuyenDung.Name = "lbNgayTuyenDung";
            this.lbNgayTuyenDung.Size = new System.Drawing.Size(130, 19);
            this.lbNgayTuyenDung.TabIndex = 4;
            this.lbNgayTuyenDung.Text = "Ngày tuyển dụng: ";
            this.lbNgayTuyenDung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbChucVu
            // 
            this.lbChucVu.AutoSize = true;
            this.lbChucVu.Location = new System.Drawing.Point(36, 290);
            this.lbChucVu.Name = "lbChucVu";
            this.lbChucVu.Size = new System.Drawing.Size(73, 19);
            this.lbChucVu.TabIndex = 3;
            this.lbChucVu.Text = "Chức vụ: ";
            this.lbChucVu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTrangThai
            // 
            this.lbTrangThai.AutoSize = true;
            this.lbTrangThai.Location = new System.Drawing.Point(36, 336);
            this.lbTrangThai.Name = "lbTrangThai";
            this.lbTrangThai.Size = new System.Drawing.Size(88, 19);
            this.lbTrangThai.TabIndex = 2;
            this.lbTrangThai.Text = "Trạng Thái: ";
            this.lbTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMaNV
            // 
            this.lbMaNV.AutoSize = true;
            this.lbMaNV.Location = new System.Drawing.Point(36, 244);
            this.lbMaNV.Name = "lbMaNV";
            this.lbMaNV.Size = new System.Drawing.Size(111, 19);
            this.lbMaNV.TabIndex = 1;
            this.lbMaNV.Text = "Mã nhân viên:  ";
            this.lbMaNV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbAnh
            // 
            this.pbAnh.Image = global::GUI.Properties.Resources.user_4073231;
            this.pbAnh.Location = new System.Drawing.Point(40, 9);
            this.pbAnh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbAnh.Name = "pbAnh";
            this.pbAnh.Size = new System.Drawing.Size(195, 191);
            this.pbAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAnh.TabIndex = 0;
            this.pbAnh.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.bthXoaQuyenQL);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(288, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 452);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(302, 384);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(85, 43);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtSDT);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(31, 333);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(359, 45);
            this.panel7.TabIndex = 7;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(131, 8);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(225, 27);
            this.txtSDT.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 19);
            this.label7.TabIndex = 3;
            this.label7.Text = "Số điện thoại";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtDiaChi);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(31, 256);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(359, 45);
            this.panel6.TabIndex = 7;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(131, 8);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(225, 27);
            this.txtDiaChi.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "Địa chỉ";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cbGioiTinh);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(31, 188);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(359, 45);
            this.panel5.TabIndex = 6;
            // 
            // cbGioiTinh
            // 
            this.cbGioiTinh.FormattingEnabled = true;
            this.cbGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cbGioiTinh.Location = new System.Drawing.Point(131, 7);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(225, 27);
            this.cbGioiTinh.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giới tính: ";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtNgaySinh);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(31, 108);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(359, 45);
            this.panel4.TabIndex = 5;
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgaySinh.Location = new System.Drawing.Point(131, 9);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(225, 27);
            this.dtNgaySinh.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngày sinh: ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTenNV);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(31, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(359, 45);
            this.panel3.TabIndex = 4;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(131, 8);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(225, 27);
            this.txtTenNV.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên nhân viên: ";
            // 
            // bthXoaQuyenQL
            // 
            this.bthXoaQuyenQL.Location = new System.Drawing.Point(129, 386);
            this.bthXoaQuyenQL.Name = "bthXoaQuyenQL";
            this.bthXoaQuyenQL.Size = new System.Drawing.Size(152, 43);
            this.bthXoaQuyenQL.TabIndex = 9;
            this.bthXoaQuyenQL.Text = "Xóa quyền quản lí";
            this.bthXoaQuyenQL.UseVisualStyleBackColor = true;
            this.bthXoaQuyenQL.Click += new System.EventHandler(this.bthXoaQuyenQL_Click);
            // 
            // frmThongTinNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 452);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmThongTinNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThongTinNhanVien";
            this.Load += new System.EventHandler(this.frmThongTinNhanVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbAnh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTrangThai;
        private System.Windows.Forms.Label lbMaNV;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbChucVu;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label lbNgayTuyenDung;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button bthXoaQuyenQL;
    }
}