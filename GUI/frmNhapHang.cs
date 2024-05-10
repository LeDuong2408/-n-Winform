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
    public partial class frmNhapHang : Form
    {
        public DonNhap donNhap = new DonNhap();
        public frmNhapHang()
        {
            InitializeComponent();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            pnDonNhap.Visible= false;
            List<Hang> list = HangBLL.Instance.LayDuLieuBLL();
            foreach (Hang hang in list)
            {
                ucHang item = new ucHang(hang, isSale: false);
                item.Click += ucHang_Click;
               
                item.Tag = hang;
                

                flpHang.Controls.Add(item);
            }
        }

        private void ucHang_Click(object sender, EventArgs e)
        {
            if (donNhap.MaDon != 0)
            {
                // gán sender bằng ucHang mà bạn đã nhấp vào
                ucHang clickedItem = sender as ucHang;
                ChiTietDonHang ctDonNhap = new ChiTietDonHang();
                ctDonNhap.MaHang = clickedItem.hang.MaHang;
                ctDonNhap.MaDon = this.donNhap.MaDon;
                ctDonNhap.SoLuong = 1;
                ctDonNhap.ThanhTien = clickedItem.hang.GiaNhap;
                try
                {
                    if (ChiTietDonNhapBLL.Instance.Insert(ctDonNhap))
                    {
                        LoadTongGT();
                        ctDonNhap.MaChiTiet = ChiTietDonNhapBLL.Instance.GetMaCT();
                        ucChiTietDon ucCTDonNhap = new ucChiTietDon(ctDonNhap, isSale: false);
                        ucCTDonNhap.SoLuongChanged += ucCTDonNhap_SoLuongChanged;
                        flpChiTietDonNhap.Controls.Add(ucCTDonNhap);
                    }
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                        if (error.Message.Contains("don da thanh toan"))
                        {
                            MessageBox.Show("Không được thay đổi đơn hàng đã thanh toán", "Thông Báo");
                        }
                        else
                            MessageBox.Show(error.Message, "lỗi");
                }
            }
        }

        private void ucCTDonNhap_SoLuongChanged(object sender, EventArgs e)
        {
            LoadTongGT();
        }
        private void LoadTongGT()
        {
            donNhap.TongGT = DonNhapBLL.Instance.GetTongGTById(donNhap.MaDon);
            lbTongGT.Text = $"Tổng giá trị: {donNhap.TongGT}";
        }

        private void btnThemDonNhap_Click(object sender, EventArgs e)
        {
            pnDonNhap.Visible = true;
            //lấy thông tin nhân viên từ form cha (form quản lí)
            frmQuanLi frmQL = Application.OpenForms.OfType<frmQuanLi>().FirstOrDefault();
            NhanVien nhanVienTaoDon = frmQL.nhanVien;
            if (DonNhapBLL.Instance.Insert(nhanVienTaoDon.MaNV))
            {
                donNhap.MaDon = DonNhapBLL.Instance.GetMaDon();
                flpChiTietDonNhap.Controls.Clear(); 
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đơn hàng đã được lưu", "Thông báo");
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (DonNhapBLL.Instance.UpdateThanhToan(donNhap.MaDon))
            {
                MessageBox.Show("Thông Báo", "Đã thanh toán");
            }
        }
    }
}
