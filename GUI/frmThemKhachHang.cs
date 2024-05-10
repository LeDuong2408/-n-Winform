using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmThemKhachHang : Form
    {
        private KhachHang khachHang = null;
        private bool isUpdate = false;
        public frmThemKhachHang()
        {
            InitializeComponent();
        }

        public frmThemKhachHang(KhachHang kh, bool isUpdate = false)
        {
            InitializeComponent();
            this.khachHang = kh;
            this.isUpdate = isUpdate;
        }

        private void frmThemKhachHang_Load(object sender, EventArgs e)
        {

            if (khachHang == null)
            {
                lbTieuDe.Text = "Thêm khách hàng mới";
            }
            else if (isUpdate)
            {
                lbTieuDe.Text = "Sửa thông tin khách hàng";
                txtDiaChi.Text = khachHang.DiaChi;
                txtSDT.Text = khachHang.SDT;
                txtTenKH.Text = khachHang.TenKH;
                cbCapBac.SelectedIndex = khachHang.MaCapBac;
            }
            else
            {
                lbTieuDe.Text = "Thông tin khách hàng";
                txtDiaChi.Text = khachHang.DiaChi;
                txtSDT.Text = khachHang.SDT;
                txtTenKH.Text = khachHang.TenKH;
                cbCapBac.SelectedIndex = khachHang.MaCapBac-1;
                txtDiaChi.ReadOnly = true;
                txtSDT.ReadOnly = true;
                txtTenKH.ReadOnly = true;
                cbCapBac.Enabled = false;
                btnLuu.Visible = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.TenKH = txtTenKH.Text;
            kh.SDT = txtSDT.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.MaCapBac = cbCapBac.SelectedIndex + 1;
            if (kh.MaCapBac == 0)
                kh.MaCapBac = khachHang.MaCapBac;
            if (khachHang == null)
            {
                try
                {
                    if (KhachHangBLL.Instance.Insert(kh))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        this.Close();
                    }
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        if (error.Message.Contains("UQ_SDT"))
                        {
                            MessageBox.Show("Số điện thoại không tồn tại", "Lỗi");
                            txtSDT.Focus();
                        }
                        else
                            MessageBox.Show($"Error Number: {error.Number}, Message: {error.Message}", "error");
                    }
                }

            }
            else
            {
                kh.MaKH = khachHang.MaKH;
                try
                {

                    if (KhachHangBLL.Instance.Update(kh))
                    {
                        MessageBox.Show("Sửa thông tin thành công", "Thông báo");
                        this.Close();
                    }
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        if (error.Message.Contains("UQ_SDT"))
                        {
                            MessageBox.Show("Số điện thoại không tồn tại", "Lỗi");
                            txtSDT.Focus();
                        }
                        else
                            MessageBox.Show($"Error Number: {error.Number}, Message: {error.Message}", "error");
                    }
                }
            }
        }
    }
}
