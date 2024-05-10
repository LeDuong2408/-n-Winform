using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class formChiTietDonHang : Form
    {
        public DonBan donBan = new DonBan();
        public formChiTietDonHang(DonBan donban)
        {
            InitializeComponent();
            this.donBan = donban;
        }

        private void formChiTietDonHang_Load(object sender, EventArgs e)
        {
            lbMaDon1.Text = lbMaDon2.Text = $"#{donBan.MaDon}";
            lbTenKH.Text = donBan.TenKH;
            lbTongGT.Text = donBan.TongGT.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
            lbChietKhau.Text = donBan.ChieuKhau.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));donBan.TongGT.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
            lbThanhTien.Text = donBan.ThanhTien.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));donBan.TongGT.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
            lbNgayTao.Text = donBan.NgayTao;
            lbTrangThai.Text = donBan.TrangThai;
            lbVAT.Text = donBan.VAT.ToString("C0", CultureInfo.GetCultureInfo("vi-VN")); donBan.VAT.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
            lbRank.Text = KhachHangBLL.Instance.FindCapBacByMaKH(donBan.MaKH);

            dgvCTDon.DataSource = ChiTietDonBanBLL.Instance.FindByMaDon(donBan.MaDon);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datagridviewChiTietDonBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCloseChiTietDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }
    }
}
