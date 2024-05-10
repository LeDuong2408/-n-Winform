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
    public partial class frmBanHang : Form
    {
        public KhachHang khachhang =  null;
        DonBan donBan = new DonBan();
        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            flpHang.Controls.Clear();
            List<Hang> list = HangBLL.Instance.LayDuLieuBLL();
            foreach (Hang hang in list)
            {
                ucHang item = new ucHang(hang, isSale: true);
                item.Tag= hang;
                item.Click += ucHang_Click;

                flpHang.Controls.Add(item);
            }


            cbVoucher.DisplayMember = "TenVoucher";
            cbVoucher.ValueMember = "MaVoucher";
            DataTable dataTable = VoucherBLL.Instance.FindAll();

            cbVoucher.DataSource = dataTable.DefaultView;
            cbVoucher.SelectedIndexChanged -= cbVoucher_SelectedIndexChanged;
            cbVoucher.SelectedIndex = -1;
            cbVoucher.SelectedIndexChanged += cbVoucher_SelectedIndexChanged;



        }
        private void ucHang_Click(object sender, EventArgs e)
        {
            if (donBan.MaDon != 0) // có đơn bán thì mới có thể click vào các uc_hang
            {
                // gán sender bằng ucHang mà bạn đã nhấp vào
                ucHang clickedItem = sender as ucHang;
                ChiTietDonHang ctDonBan = new ChiTietDonHang();
                ctDonBan.MaHang = clickedItem.hang.MaHang;
                ctDonBan.MaDon = this.donBan.MaDon;
                ctDonBan.SoLuong = 1;
                ctDonBan.ThanhTien = clickedItem.hang.DonGia;
                try
                {
                    if (ChiTietDonBanBLL.Instance.Insert(ctDonBan))
                    {
                        LoadDon();
                        ctDonBan.MaChiTiet = ChiTietDonBanBLL.Instance.GetMaCT();
                        ucChiTietDon ucCTDonBan = new ucChiTietDon(ctDonBan, isSale: true);
                        ucCTDonBan.SoLuongChanged += ucCTDon_SoLuongChanged;
                        flpChiTietDon.Controls.Add(ucCTDonBan);
                    }
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        if (error.Message.Contains("Khong co du hang"))
                        {
                            MessageBox.Show("Mặt hàng này hiện đã hết", "Thông báo");
                        }
                        else if (error.Message.Contains("da thanh toan"))
                        {
                            MessageBox.Show("Không được thay đổi đơn hàng đã thanh toán !!", "Thông Báo");
                        }
                    }
                }
            }
        }

        private void ucCTDon_SoLuongChanged(object sender, EventArgs e)
        {
            LoadDon();
        }
        private void LoadDon()
        {
            donBan = DonBanBLL.Instance.GetDonBanById(donBan.MaDon);
            lbTongGT.Text = $"Tổng giá trị: {donBan.TongGT}";
            lbChietKhau.Text = $"Chiết khấu: {donBan.ChieuKhau}";
            lbThanhTien.Text = $"Thành tiền: {donBan.ThanhTien}";
            lbVAT.Text = $"VAT: {donBan.VAT}";
        }

        public void GetValue(KhachHang kh)
        {
            this.khachhang = kh;
        }
        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            frmQuanLiKhachHang frmQuanLiKH = new frmQuanLiKhachHang();
            // kiểm tra đơn đã được tạo chưa nến khach hang = null => đơn chưa được tao
            if (khachhang == null)
            {
                frmQuanLiKH.mydata = new frmQuanLiKhachHang.GETDATA(GetValue);
                frmQuanLiKH.ShowDialog();
                if (khachhang != null)
                {
                    //lấy thông tin nhân viên tạo đơn từ formQuanLi
                    frmQuanLi frmQL = Application.OpenForms.OfType<frmQuanLi>().FirstOrDefault();
                    NhanVien nhanVienTaoDon = frmQL.nhanVien;
                    donBan.MaNV = nhanVienTaoDon.MaNV;

                    //them  đon bán vào database
                    try
                    {
                        if (DonBanBLL.Instance.Insert(donBan.MaNV, khachhang.MaKH))
                        {
                            lbKhachHang.Text = $"Khách hàng: {khachhang.TenKH}";
                            donBan.MaKH = khachhang.MaKH;
                            donBan.MaDon = DonBanBLL.Instance.GetMaDon();
                            flpChiTietDon.Controls.Clear();
                        }
                        LoadDon();
                    }
                    catch (SqlException ex)
                    {
                        foreach (SqlError error in ex.Errors)
                            if (error.Message.Contains("Nhan vien ki thuat khong duoc tao don ban"))
                            {
                                MessageBox.Show("Nhân viên kĩ thuật không được tạo đơn bán","Thông Báo");
                            }
                            else
                                MessageBox.Show(error.Message, "lỗi");
                    }

                }
            }
            // nếu đơn đã được tạo => người dùng đang muốn đổi khách hang của đơn đó
            else 
            {
                frmQuanLiKH.mydata = new frmQuanLiKhachHang.GETDATA(GetValue);
                frmQuanLiKH.ShowDialog();
                if (khachhang != null)
                {
                    //update khach hang cua don
                    try
                    {
                        if (DonBanBLL.Instance.UpdateKH(donBan.MaDon, khachhang.MaKH))
                        {
                            MessageBox.Show("Đổi tên người mua thành công", "Thông báo");
                            lbKhachHang.Text = $"Khách hàng: {khachhang.TenKH}";
                            donBan.MaKH = khachhang.MaKH;
                            LoadDon();
                        }
                    }
                    catch (SqlException ex)
                    {
                        foreach (SqlError error in ex.Errors)
                            if (error.Message.Contains("Khong duoc sua khi don da thanh toan"))
                            {
                                MessageBox.Show("Không được thay đổi đơn hàng đã thanh toán !!", "Thông Báo");
                            }
                            else
                                MessageBox.Show(error.Message, "lỗi");
                    }
                }
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (khachhang == null)
            {
                MessageBox.Show("Chưa chọn khách hàng", "Thông báo");
            }
            else
            {
                frmThemKhachHang frm = new frmThemKhachHang(khachhang, isUpdate: true);
                frm.ShowDialog();
            }
        }

        private void txtTenHang_TextChanged(object sender, EventArgs e)
        {
            flpHang.Controls.Clear();
            string tenHang = txtTenHang.Text;
            List<Hang> list = HangBLL.Instance.FindByTenHang(tenHang);
            foreach (Hang hang in list)
            {
                ucHang item = new ucHang(hang, isSale: true);
                item.Tag = hang;
                item.Click += ucHang_Click;

                flpHang.Controls.Add(item);
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (donBan.MaDon != 0)
            {
                int maVoucher = int.Parse(cbVoucher.SelectedValue.ToString());
                try
                {
                    if (DonBanBLL.Instance.UpdateVoucher(maVoucher, donBan.MaDon))
                    {
                        donBan.MaVoucher = maVoucher;
                        MessageBox.Show("Đã đổi voucher", "thông báo");
                        LoadDon();
                    }
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                        if (error.Message.Contains("Khong su dung duoc voucher nay"))
                        {
                            MessageBox.Show("Voucher đã hết hạn", "Thông Báo");
                        }
                        else if (error.Message.Contains("Nhan vien ki thuat khong duoc tao don ban"))
                        {
                            MessageBox.Show("Nhân viên kĩ thuật không được tạo đơn bán", "Thông Báo");
                        }
                        else if (error.Message.Contains("Khong duoc sua khi don da thanh toan"))
                            {
                                MessageBox.Show("Không được thay đổi đơn hàng đã thanh toán !!", "Thông Báo");
                            }
                        else
                            MessageBox.Show(error.Message, "lỗi");
                }
            }    
            //lbChietKhau.Text = cbVoucher.SelectedValue.ToString();
            //lbVAT.Text = cbVoucher.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (donBan.TrangThai == "Đã thanh toán")
            {
                MessageBox.Show("Không thể thanh toán đơn hàng đã thanh toán !!", "Thông Báo");
            }
            else
            {
                if (MessageBox.Show("Bạn muốn xác nhận thanh toán đơn này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {


                    try
                    {
                        if (DonBanBLL.Instance.ThanhToanDon(donBan.MaDon))
                        {
                            MessageBox.Show("Đã thanh toán đơn", "Thông báo");
                            donBan.TrangThai = "Đã thanh toán";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Thanh toán thất bại", "Thông báo");
                    }
                }
            }
        }
    }
}
