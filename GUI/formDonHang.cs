using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class formDonHang : Form
    {
        public formDonHang()
        {
            InitializeComponent();
        }

        private void formDonHang_Load(object sender, EventArgs e)
        {
            dgvDonBan.DataSource = FindAllDonBan();
            lbSoLuong.Text = dgvDonBan.RowCount.ToString();
        }

        private List<DonBan> FindAllDonBan()
        {
            List<DonBan> list = DonBanBLL.Instance.FindAll();
            return list;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //formChiTietDonHang detail = new formChiTietDonHang();
            //detail.ShowDialog();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            dgvDonBan.DataSource = FindAllDonBan();
            lbSoLuong.Text = dgvDonBan.RowCount.ToString();
        }

        private void dtpNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayBD = dtpNgayBatDau.Value;
            DateTime ngayKT = dtpNgayKetThuc.Value;
            string trangthai = cbTrangThai.Text;

            dgvDonBan.DataSource = DonBanBLL.Instance.FindByAll(ngayBD, ngayKT, trangthai);
            lbSoLuong.Text = dgvDonBan.RowCount.ToString();

        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpNgayBatDau_ValueChanged(sender, e);
        }

        private void dgvDonBan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DonBan donban = new DonBan();
            DataGridViewRow row = dgvDonBan.SelectedCells[0].OwningRow;
            donban.MaNV = int.Parse(row.Cells["MaNV"].Value.ToString());
            donban.MaDon = int.Parse(row.Cells["MaDon"].Value.ToString());
            donban.MaKH = int.Parse(row.Cells["MaKH"].Value.ToString());
            donban.TenKH = row.Cells["TenKH"].Value.ToString();
            donban.ThanhTien = decimal.Parse(row.Cells["ThanhTien"].Value.ToString());
            donban.TongGT = decimal.Parse(row.Cells["TongGT"].Value.ToString());
            donban.ChieuKhau = decimal.Parse(row.Cells["ChietKhau"].Value.ToString());
            donban.VAT = decimal.Parse(row.Cells["VAT"].Value.ToString());
            donban.NgayTao = row.Cells["NgayTao"].Value.ToString();
            donban.TrangThai = row.Cells["TrangThai"].Value.ToString();
            donban.MaVoucher = int.Parse(row.Cells["MaVoucher"].Value.ToString());

            formChiTietDonHang fCTDonHang = new formChiTietDonHang(donban);
            this.Hide();
            fCTDonHang.ShowDialog();
            dgvDonBan.DataSource = FindAllDonBan();
            this.Show();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {

        }
    }
}
