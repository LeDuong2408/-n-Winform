using BLL;
using CrystalDecisions.ReportAppServer.DataDefModel;
using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void txtTaiKhoan_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtTaiKhoan.Text == "Your Name")
            {
                txtTaiKhoan.Text = "";
                txtTaiKhoan.ForeColor = Color.Black;
            }
        }

        private void txtTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "Your Name")
            {
                txtTaiKhoan.Text = "";
                txtTaiKhoan.ForeColor = Color.Black;
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Password")
            {
                txtMatKhau.PasswordChar = '*';
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.Black;
            }
        }

        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {

            if (txtTaiKhoan.Text == "")
            {
                txtTaiKhoan.Text = "Your Name";
                txtTaiKhoan.ForeColor = Color.Silver;
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                txtMatKhau.PasswordChar = '\0';
                txtMatKhau.Text = "Password";
                txtMatKhau.ForeColor = Color.Silver;
            }
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '\0')
            {
                btnShowPass.BackgroundImage = global::GUI.Properties.Resources.hide_2767146;
                txtMatKhau.PasswordChar = '*';
            }
            else
            {
                btnShowPass.BackgroundImage = global::GUI.Properties.Resources.eye_3926043;
                txtMatKhau.PasswordChar = '\0';
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (thongbao == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string ten = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            TaiKhoanNV tk = new TaiKhoanNV();
            tk.taikhoan = ten;
            tk.matkhau = matkhau;
            TaiKhoanNVBLL tkBLL = new TaiKhoanNVBLL();
            string result = tkBLL.checkLogin(tk);
            if (result == "successful")
            {

                NhanVien nv = NhanVienBLL.Instance.FindByUserName(ten);
                frmQuanLi frmQuanLi = new frmQuanLi(nv);
                this.Hide();
                frmQuanLi.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaiKhoan_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
    }
}
