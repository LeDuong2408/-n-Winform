using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmThemNhanVien : Form
    {
       
        public frmThemNhanVien()
        {
            InitializeComponent();
        }

        private void frmThemNhanVien_Load(object sender, EventArgs e)
        {
            dtNgayTuyenDung.Value = DateTime.Now;
            pbAnh.Image = Properties.Resources.user1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            NhanVien newNhanVien = new NhanVien();
            newNhanVien.TenNV = txtTenNV.Text;
            newNhanVien.NgaySinh = dtNgaySinh.Value.ToString("yyyy/MM/dd");
            newNhanVien.GioiTinh = cbGioiTinh.Text;
            newNhanVien.SDT = txtSDT.Text;
            newNhanVien.DiaChi = txtDiaChi.Text;
            newNhanVien.ChucVu = cbChucVu.Text;
            newNhanVien.NgayTuyenDung = dtNgayTuyenDung.Value.ToString("yyyy/MM/dd");
            newNhanVien.Anh = ImageToByteArray(pbAnh.Image);
            try
            {
                if (NhanVienBLL.Instance.ThemNhanVien(newNhanVien))
                {
                    txtTenNV.Focus();
                    TaiKhoanNV tk = new TaiKhoanNV();
                    tk.manv = TaiKhoanNVBLL.Instance.GetMaNV();
                    tk.matkhau = txtMatKhau.Text;
                    tk.taikhoan = txtTenDangNhap.Text;

                    try
                    {
                        if (TaiKhoanNVBLL.Instance.Insert(tk))
                            MessageBox.Show("Thêm nhân viên thành công", "Thông báo");
                    }
                    catch (SqlException ex)
                    {
                        foreach (SqlError error in ex.Errors)
                            if (error.Message.Contains("Mat Khau"))
                            {
                                MessageBox.Show("Mật khẩu phải có tối thiểu 8 kí tự và 1 kí tự đăc biệt", "Lỗi");
                                txtSDT.Focus();
                            }
                            else if (error.Message.Contains("UQ_TaiKhoan"))
                            {
                                MessageBox.Show("Tạo tài khoản thất bại do tên đăng nhập đã tồn tại", "Lỗi");
                                txtSDT.Focus();
                            }

                            else
                                MessageBox.Show(error.Message, "lỗi");
                        NhanVienBLL.Instance.XoaNhanVien(tk.manv);
                    }
                    this.Close();
                }

                } catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    if (error.Message.Contains("ck_lenSTD_NV"))
                    {
                        MessageBox.Show("Số điện thoại không tồn tại", "Lỗi");
                        txtSDT.Focus();
                    }
                    else if (error.Message.Contains("ck_NgaySinhNV"))
                    {
                        MessageBox.Show("nhân viên chưa đủ tuổi lao động", "lỗi");
                        dtNgaySinh.Focus();
                    }
                    else if (error.Message.Contains("SDTNhanVien"))
                    {
                        MessageBox.Show("Số điện thoại đã được đăng kí", "lỗi");
                        txtSDT.Focus();
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

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (img.ShowDialog() == DialogResult.OK)
            {
                pbAnh.ImageLocation = img.FileName;
            }
        }
        /// <summary>
        /// Chuyển đổi một hình ảnh thành một mảng byte.
        /// </summary>
        /// <param name="image">Hình ảnh cần chuyển đổi.</param>
        /// <returns>Mảng byte chứa dữ liệu hình ảnh.</returns>
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
