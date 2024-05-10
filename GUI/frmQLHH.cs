using BLL;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmQLHH : Form
    {
        public frmQLHH()
        {
            InitializeComponent();
        }
        private void loadCbNhaCungCap()
        {
            cbNCC.DisplayMember = "TenNCC";
            cbNCC.ValueMember = "MaNCC";
            DataTable dataTable = NhaCungCapBLL.Instance.FindAll();
            cbNCC.DataSource = dataTable.DefaultView;
            cbNCC.SelectedIndex = -1;
        }
        private void loadCbLoaiHang()
        {
            cbLoaiHang.DisplayMember = "TenLoai";
            cbLoaiHang.ValueMember = "MaLoai";
            DataTable dataTable = LoaiHangBLL.Instance.FindAll();
            cbLoaiHang.DataSource = dataTable.DefaultView;
            cbLoaiHang.SelectedIndex = -1;
        }
        private void loadCbXuatXu()
        {
            cbXuatXu.DataSource = HangBLL.Instance.findAllXuatXu();
        }
        private void frmQLHH_Load(object sender, EventArgs e)
        {
            LayDuLieu();
            loadCbNhaCungCap();
            loadCbLoaiHang();
            loadCbXuatXu();
        }

        public void LayDuLieu()
        {
            dgvHang.DataSource = HangBLL.Instance.LayDuLieuBLL();
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            frm_ThemSanPhamMoi fThemSP = new frm_ThemSanPhamMoi();
            fThemSP.ShowDialog();
            LayDuLieu();
        }
        private bool checkKeyNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                return false;
            return true;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenHang = txtTenHang.Text;
            string xuatXu = cbXuatXu.Text;
            string nhaCC = cbNCC.Text;
            string loai = cbLoaiHang.Text;
            dgvHang.DataSource = HangBLL.Instance.FindHang(tenHang, nhaCC,loai,xuatXu);
        }

        private void txtMaHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            LayDuLieu();
            ResetAll();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Hang hang = HangBLL.Instance.LayHang(dgvHang);
            frm_ThemSanPhamMoi fSP = new frm_ThemSanPhamMoi(hang);
            fSP.ShowDialog();
            LayDuLieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maHang = HangBLL.Instance.LayHang(dgvHang).MaHang;
                if (HangBLL.Instance.XoaHang(maHang))
                {
                    MessageBox.Show("Xóa thành công");
                    LayDuLieu();
                }
                else
                    MessageBox.Show("Xóa Thất bại");
            }
        }
        private void ResetAll()
        {
            txtTenHang.Text = "";
            cbLoaiHang.Text = "";
            cbXuatXu.Text = "";
            cbNCC.Text = "";
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void dgvHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
