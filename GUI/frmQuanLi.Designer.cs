namespace GUI
{
    partial class frmQuanLi
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
            this.btnQLHH = new System.Windows.Forms.Button();
            this.btnQLNV = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnNCC = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnBanHang = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbChucVu = new System.Windows.Forms.Label();
            this.lbTenNV = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pbAvata = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pnBody = new System.Windows.Forms.Panel();
            this.btnDonHang = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvata)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQLHH
            // 
            this.btnQLHH.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnQLHH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnQLHH.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLHH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLHH.Location = new System.Drawing.Point(0, 53);
            this.btnQLHH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQLHH.Name = "btnQLHH";
            this.btnQLHH.Size = new System.Drawing.Size(189, 53);
            this.btnQLHH.TabIndex = 3;
            this.btnQLHH.Text = "Quản lí Hàng hóa";
            this.btnQLHH.UseVisualStyleBackColor = false;
            this.btnQLHH.Click += new System.EventHandler(this.btnQLHH_Click);
            // 
            // btnQLNV
            // 
            this.btnQLNV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQLNV.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnQLNV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLNV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQLNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLNV.Location = new System.Drawing.Point(0, 0);
            this.btnQLNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.btnQLNV.Name = "btnQLNV";
            this.btnQLNV.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQLNV.Size = new System.Drawing.Size(189, 53);
            this.btnQLNV.TabIndex = 2;
            this.btnQLNV.Text = "Quản lí nhân viên";
            this.btnQLNV.UseVisualStyleBackColor = false;
            this.btnQLNV.Click += new System.EventHandler(this.btnQLNV_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 653);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnDonHang);
            this.panel3.Controls.Add(this.btnNCC);
            this.panel3.Controls.Add(this.btnThongKe);
            this.panel3.Controls.Add(this.btnNhapHang);
            this.panel3.Controls.Add(this.btnKhachHang);
            this.panel3.Controls.Add(this.btnBanHang);
            this.panel3.Controls.Add(this.btnQLHH);
            this.panel3.Controls.Add(this.btnQLNV);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 216);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(191, 437);
            this.panel3.TabIndex = 1;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDangXuat.BackgroundImage = global::GUI.Properties.Resources.icons8_exit_96;
            this.btnDangXuat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDangXuat.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Location = new System.Drawing.Point(854, 9);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(54, 38);
            this.btnDangXuat.TabIndex = 9;
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnNCC
            // 
            this.btnNCC.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNCC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNCC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNCC.Location = new System.Drawing.Point(0, 318);
            this.btnNCC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNCC.Name = "btnNCC";
            this.btnNCC.Size = new System.Drawing.Size(189, 53);
            this.btnNCC.TabIndex = 8;
            this.btnNCC.Text = "Nhà cung cấp";
            this.btnNCC.UseVisualStyleBackColor = false;
            this.btnNCC.Click += new System.EventHandler(this.btnNCC_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnThongKe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Location = new System.Drawing.Point(0, 265);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(189, 53);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNhapHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNhapHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapHang.Location = new System.Drawing.Point(0, 212);
            this.btnNhapHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(189, 53);
            this.btnNhapHang.TabIndex = 6;
            this.btnNhapHang.Text = "Nhập Hàng";
            this.btnNhapHang.UseVisualStyleBackColor = false;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnKhachHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 159);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(189, 53);
            this.btnKhachHang.TabIndex = 5;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.UseVisualStyleBackColor = false;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnBanHang
            // 
            this.btnBanHang.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBanHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBanHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanHang.Location = new System.Drawing.Point(0, 106);
            this.btnBanHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(189, 53);
            this.btnBanHang.TabIndex = 4;
            this.btnBanHang.Text = "Bán hàng";
            this.btnBanHang.UseVisualStyleBackColor = false;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 216);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbChucVu);
            this.panel5.Controls.Add(this.lbTenNV);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 149);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(189, 66);
            this.panel5.TabIndex = 1;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // lbChucVu
            // 
            this.lbChucVu.AutoSize = true;
            this.lbChucVu.Location = new System.Drawing.Point(34, 43);
            this.lbChucVu.Name = "lbChucVu";
            this.lbChucVu.Size = new System.Drawing.Size(64, 19);
            this.lbChucVu.TabIndex = 1;
            this.lbChucVu.Text = "Chức vụ";
            // 
            // lbTenNV
            // 
            this.lbTenNV.AutoSize = true;
            this.lbTenNV.Location = new System.Drawing.Point(34, 12);
            this.lbTenNV.Name = "lbTenNV";
            this.lbTenNV.Size = new System.Drawing.Size(101, 19);
            this.lbTenNV.TabIndex = 0;
            this.lbTenNV.Text = "Tên nhân viên";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pbAvata);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(189, 149);
            this.panel4.TabIndex = 0;
            // 
            // pbAvata
            // 
            this.pbAvata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAvata.Location = new System.Drawing.Point(0, 0);
            this.pbAvata.Name = "pbAvata";
            this.pbAvata.Size = new System.Drawing.Size(189, 149);
            this.pbAvata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAvata.TabIndex = 0;
            this.pbAvata.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnDangXuat);
            this.panel6.Controls.Add(this.btnThoat);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(191, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(973, 62);
            this.panel6.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Transparent;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnThoat.Image = global::GUI.Properties.Resources.button__2_;
            this.btnThoat.Location = new System.Drawing.Point(893, 6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 43);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // pnBody
            // 
            this.pnBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBody.Location = new System.Drawing.Point(191, 62);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(973, 591);
            this.pnBody.TabIndex = 1;
            // 
            // btnDonHang
            // 
            this.btnDonHang.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDonHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDonHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonHang.Location = new System.Drawing.Point(0, 371);
            this.btnDonHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.Size = new System.Drawing.Size(189, 53);
            this.btnDonHang.TabIndex = 9;
            this.btnDonHang.Text = "Lịch sử đơn hàng";
            this.btnDonHang.UseVisualStyleBackColor = false;
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);
            // 
            // frmQuanLi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 653);
            this.Controls.Add(this.pnBody);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmQuanLi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuanLi";
            this.Load += new System.EventHandler(this.frmQuanLi_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAvata)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQLHH;
        private System.Windows.Forms.Button btnQLNV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel pnBody;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pbAvata;
        private System.Windows.Forms.Label lbChucVu;
        private System.Windows.Forms.Label lbTenNV;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnNCC;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnDonHang;
    }
}