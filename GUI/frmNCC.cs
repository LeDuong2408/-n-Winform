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
    public partial class frmNCC : Form
    {
        private NhaCungCap nhaCungcap = null;

        public frmNCC()
        {
            InitializeComponent();
        }

        public frmNCC(NhaCungCap ncc)
        {
            InitializeComponent();
            this.nhaCungcap = ncc;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhaCungCap nhaCungCap = new NhaCungCap();
            nhaCungCap.TenNCC = txtTen.Text;
            nhaCungCap.SDT = txtSDT.Text;
            nhaCungCap.Email = txtEmail.Text;
            nhaCungCap.DiaChi = txtDiaChi.Text;

            try
            {
                if (this.nhaCungcap == null)
                {
                    if (NhaCungCapBLL.Instance.Insert(nhaCungCap))
                    {
                        MessageBox.Show("Thêm thành công.", "Thông báo");
                        this.Close();
                    }
                }
                else
                {
                    nhaCungCap.MaNCC = this.nhaCungcap.MaNCC;
                    if (NhaCungCapBLL.Instance.Update(nhaCungCap))
                    {
                        MessageBox.Show("sửa thành công.", "Thông báo");
                        this.Close();
                    }
                }
            } catch(SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    if (error.Message.Contains("ck_lenSDT_KH"))
                    {
                        MessageBox.Show("Số điện thoại không tồn tại", "Lỗi");
                        txtSDT.Focus();
                    }
                    else if (error.Message.Contains("ck_email_NCC"))
                    {
                        MessageBox.Show("Email không hợp lệ", "Lỗi");
                        txtEmail.Focus();
                    }
                    else if (error.Message.Contains("UQ_Email_NCC"))
                    {
                        MessageBox.Show("Email đã tồn tại", "Lỗi");
                        txtEmail.Focus();
                    }
                    else if (error.Message.Contains("permission was denied"))
                    {
                        MessageBox.Show("Người dùng không có quyền thực hiện hành động này", "Thông báo");
                    }
                    else
                        MessageBox.Show($"Error Number: {error.Number}, Message: {error.Message}", "error");
                }
            }
        }

        private void frmNCC_Load(object sender, EventArgs e)
        {
            if (nhaCungcap != null)
            {
                txtTen.Text = nhaCungcap.TenNCC;
                txtDiaChi.Text = nhaCungcap.DiaChi;
                txtEmail.Text = nhaCungcap.Email;
                txtSDT.Text = nhaCungcap.SDT;
            }
        }
    }
}
