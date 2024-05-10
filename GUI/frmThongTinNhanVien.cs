using BLL;
using DTO;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmThongTinNhanVien : Form
    {
        private bool isEdit;
        private NhanVien NhanVien;
        public frmThongTinNhanVien()
        {
            InitializeComponent();
        }
        public frmThongTinNhanVien(NhanVien nv, bool isEdit=false)
        {
            InitializeComponent();
            txtTenNV.Text = nv.TenNV.ToString();
            txtDiaChi.Text = nv.DiaChi.ToString();
            txtSDT.Text = nv.SDT.ToString();
            cbGioiTinh.Text = nv.GioiTinh.ToString();
            lbMaNV.Text += " " + nv.MaNV.ToString();
            dtNgaySinh.Value = DateTime.ParseExact(nv.NgaySinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            pbAnh.Image = converByteToImage(nv.Anh);
            lbChucVu.Text += nv.ChucVu;
            lbTrangThai.Text += nv.TrangThai;
            lbNgayTuyenDung.Text += nv.NgayTuyenDung;

            this.isEdit = isEdit;
            this.NhanVien= nv;


        }
        public Image converByteToImage(Byte[] byteArr)
        {
            if (byteArr == null)
                return null;
            MemoryStream memoryStream = new MemoryStream(byteArr);
            return Image.FromStream(memoryStream);
        }
        private void frmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            if (!isEdit)
            {
                txtTenNV.ReadOnly = true;
                txtSDT.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                dtNgaySinh.Enabled = false;
                cbGioiTinh.Enabled = false;
                btnLuu.Text = "Cấp quyền quản lí";
                btnChonAnh.Visible = false;
            }   
            else
            {
                txtTenNV.ReadOnly = false;
                txtSDT.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                dtNgaySinh.Enabled = true;
                cbGioiTinh.Enabled = true;
                btnLuu.Text = "Lưu";
                btnChonAnh.Visible = true;
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhanVien.TenNV = txtTenNV.Text;
            NhanVien.NgaySinh = dtNgaySinh.Value.ToString("yyyy/MM/dd");
            NhanVien.GioiTinh = cbGioiTinh.Text;
            NhanVien.SDT = txtSDT.Text;
            NhanVien.DiaChi = txtDiaChi.Text;
            NhanVien.Anh = ImageToByteArray(pbAnh.Image);
            if (isEdit)
            {
                try
                {
                    if (!NhanVienBLL.Instance.SuaThongTin(NhanVien))
                        txtTenNV.Focus();
                    else
                    {
                        MessageBox.Show("Sửa nhân viên thành công", "Thông báo");
                        this.Close();
                    }
                }
                catch (SqlException ex)
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
            else
            {
                try
                {
                    if (NhanVienBLL.Instance.CapQuyenQL(NhanVien.MaNV)) ;
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        if (error.Message.Contains("permission was denied"))
                        {
                            MessageBox.Show("Người dùng không có quyền thực hiện hành động này", "Thông báo");
                        }
                        else
                            MessageBox.Show($"Error Number: {error.Number}, Message: {error.Message}", "error");
                    }
                }
            }
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bthXoaQuyenQL_Click(object sender, EventArgs e)
        {
            try
            {
                if (NhanVienBLL.Instance.XoaQuyenQL(NhanVien.MaNV)) ;
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    if (error.Message.Contains("permission was denied"))
                    {
                        MessageBox.Show("Người dùng không có quyền thực hiện hành động này", "Thông báo");
                    }
                    else
                        MessageBox.Show($"Error Number: {error.Number}, Message: {error.Message}", "error");
                }
            }
        }
    }
}
