namespace GUI
{
    partial class ucHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbGia = new System.Windows.Forms.Label();
            this.lbTenHang = new System.Windows.Forms.Label();
            this.pbAnh = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // lbGia
            // 
            this.lbGia.AutoSize = true;
            this.lbGia.Location = new System.Drawing.Point(3, 191);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(38, 19);
            this.lbGia.TabIndex = 4;
            this.lbGia.Text = "Giá:";
            // 
            // lbTenHang
            // 
            this.lbTenHang.AutoSize = true;
            this.lbTenHang.Location = new System.Drawing.Point(3, 161);
            this.lbTenHang.Name = "lbTenHang";
            this.lbTenHang.Size = new System.Drawing.Size(105, 19);
            this.lbTenHang.TabIndex = 3;
            this.lbTenHang.Text = "Tên sản phẩm:";
            // 
            // pbAnh
            // 
            this.pbAnh.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbAnh.Image = global::GUI.Properties.Resources._360_F_496632203_ebd1fmChidWFuaYcoIKgRAAQqo00ReUC;
            this.pbAnh.Location = new System.Drawing.Point(0, 0);
            this.pbAnh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbAnh.Name = "pbAnh";
            this.pbAnh.Size = new System.Drawing.Size(171, 155);
            this.pbAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAnh.TabIndex = 0;
            this.pbAnh.TabStop = false;
            // 
            // ucHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbGia);
            this.Controls.Add(this.lbTenHang);
            this.Controls.Add(this.pbAnh);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucHang";
            this.Size = new System.Drawing.Size(171, 219);
            this.Load += new System.EventHandler(this.ucHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAnh;
        private System.Windows.Forms.Label lbGia;
        private System.Windows.Forms.Label lbTenHang;
    }
}
