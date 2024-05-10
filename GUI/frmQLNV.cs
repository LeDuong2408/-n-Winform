using BLL;
using DTO;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmQLNV : Form
    {
        public frmQLNV()
        {
            InitializeComponent();
        }

        private void frmQLNV_Load(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void LayDuLieu()
        {
            dgvNhanVien.DataSource = NhanVienBLL.Instance.LayDuLieuBLL();
        }
        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            frmThemNhanVien frmThem = new frmThemNhanVien();
            this.Hide();
            frmThem.ShowDialog();
            this.Show();
            LayDuLieu();
        }

        private void btnThemNV_MouseHover(object sender, EventArgs e)
        {
            btnThemNV.BackColor = Color.FromArgb(192, 192, 192);
        }

        private void btnThemNV_MouseLeave(object sender, EventArgs e)
        {
            btnThemNV.BackColor = Color.White;
        }

        
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedCells.Count > 0)
            {
                NhanVien nv = NhanVienBLL.Instance.ChiTietNhanVien(dgvNhanVien);
                frmThongTinNhanVien frmThongTin = new frmThongTinNhanVien(nv,isEdit: true);
                this.Hide();
                frmThongTin.ShowDialog();
                this.Show();
                LayDuLieu();
            }
            else
                MessageBox.Show("Chưa chọn nhân viên", "Thông báo");
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhanVien.SelectedCells.Count > 0)
            {
                NhanVien nv = NhanVienBLL.Instance.ChiTietNhanVien(dgvNhanVien);
                frmThongTinNhanVien frmThongTinNhanVien = new frmThongTinNhanVien(nv);
                this.Hide();
                frmThongTinNhanVien.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Chưa chọn nhân viên", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa thông tin nhân viên này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DataGridViewRow row = dgvNhanVien.SelectedCells[0].OwningRow;
                int maNV = int.Parse(row.Cells["MaNV"].Value.ToString());
                try
                {
                    if (NhanVienBLL.Instance.XoaNhanVien(maNV))
                    {
                        MessageBox.Show("Xóa Thành công", "Thông Báo");
                        LayDuLieu();
                        TaiKhoanNVBLL.Instance.XoaTK(maNV);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông Báo");
                    }
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        if (error.Message.Contains("permission was denied"))
                        {
                            MessageBox.Show("Người dùng không có quyền thực hiện hành động này", "Thông báo");
                        }
                    }
                }
            }
        }

        private void dgvNhanVien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
