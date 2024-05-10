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
    public partial class ucChiTietDon : UserControl
    {
        public ChiTietDonHang CTDon;
        private Hang hang = new Hang();
        bool isSale = false;
        public ucChiTietDon()
        {
            InitializeComponent();
        }

        public ucChiTietDon(ChiTietDonHang CTDonNhap, bool isSale)
        {
            InitializeComponent();
            this.CTDon = CTDonNhap;
            this.isSale = isSale;
            this.hang = HangBLL.Instance.FindById(this.CTDon.MaHang);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int soLuong = CTDon.SoLuong;
            soLuong -= 1;
            if (soLuong > 0)
            {
                if (!isSale)
                {
                    try
                    {
                        if (ChiTietDonNhapBLL.Instance.UpdateSoLuongHang(CTDon.MaChiTiet, soLuong))
                        {
                            lbThanhTien.Text = (soLuong * hang.GiaNhap).ToString();
                            CTDon.SoLuong = soLuong;
                            lbSoLuong.Text = (soLuong).ToString();
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
                else
                {
                    try
                    {
                        if (ChiTietDonBanBLL.Instance.UpdateSoLuongHang(CTDon.MaChiTiet, soLuong))
                        {
                            lbThanhTien.Text = (soLuong * hang.DonGia).ToString();
                            CTDon.SoLuong = soLuong;
                            lbSoLuong.Text = (soLuong).ToString();
                        }
                    }
                    catch (SqlException ex)
                    {
                        foreach (SqlError error in ex.Errors)
                            if (error.Message.Contains("Khong duoc thay doi khi don da thanh toan"))
                            {
                                MessageBox.Show("Không được sửa đơn hàng đã thanh toán", "Thông báo");
                            }
                            else
                                MessageBox.Show(error.Message, "lỗi");
                    }
                }
                OnSoLuongChanged(EventArgs.Empty);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int soLuong = CTDon.SoLuong;
            soLuong += 1;
            
            if (!isSale)
            {
                try
                {
                    if (ChiTietDonNhapBLL.Instance.UpdateSoLuongHang(CTDon.MaChiTiet, soLuong))
                    {
                        lbSoLuong.Text = soLuong.ToString();
                        CTDon.SoLuong = soLuong;
                        lbThanhTien.Text = (soLuong * hang.GiaNhap).ToString();
                    }
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        if (error.Message.Contains("da thanh toan"))
                        {
                            MessageBox.Show("Không được sửa đơn hàng đã thanh toán", "Thông báo");
                        }
                    }
                }

            }

            else
            {
                try
                {
                    ChiTietDonBanBLL.Instance.UpdateSoLuongHang(CTDon.MaChiTiet, soLuong);
                    lbThanhTien.Text = (soLuong * hang.DonGia).ToString();
                    lbSoLuong.Text = soLuong.ToString();
                    CTDon.SoLuong = soLuong;
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        if (error.Message.Contains("kHONG DU HANG"))
                        {
                            MessageBox.Show("Mặt hàng này hiện đã hết", "Thông báo");
                        }
                        else if (error.Message.Contains("Khong duoc thay doi khi don da thanh toan"))
                        {
                            MessageBox.Show("Không được sửa đơn hàng đã thanh toán", "Thông báo");
                        }
                        else
                            MessageBox.Show(error.Message, "Thông báo");
                    }
                }


            }
            OnSoLuongChanged(EventArgs.Empty);
        }

        private void ucChiTietDon_Load(object sender, EventArgs e)
        {
            llbTenHang.Text = hang.TenHang.ToString();
            if (isSale)
                lbThanhTien.Text = hang.DonGia.ToString();
            else
                lbThanhTien.Text = hang.GiaNhap.ToString();
        }

        public event EventHandler SoLuongChanged;

        protected virtual void OnSoLuongChanged(EventArgs e)
        {
            SoLuongChanged?.Invoke(this, e);
        }
    }
}
