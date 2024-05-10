using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_ThemSanPhamMoi : Form
    {
        private Hang sp = null;
        public frm_ThemSanPhamMoi()
        {
            InitializeComponent();
        }

        public frm_ThemSanPhamMoi(Hang hang)
        {
            InitializeComponent();
            this.sp = hang;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            txtTen.Text= "";
            txtXuatXu.Text = "";
            cbLoai.SelectedIndex = -1;
            cbNCC.SelectedIndex = -1;
            txtTen.Focus();
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

        

        private void frm_ThemSanPhamMoi_Load(object sender, EventArgs e)
        {
            pbAnh.Image = Properties.Resources._360_F_496632203_ebd1fmChidWFuaYcoIKgRAAQqo00ReUC;

            cbLoai.DisplayMember = "TenLoai";
            cbLoai.ValueMember = "MaLoai";
            DataTable dataTable = LoaiHangBLL.Instance.FindAll();
            cbLoai.DataSource = dataTable.DefaultView;
            cbLoai.SelectedIndex = -1;

            cbNCC.DisplayMember = "TenNCC";
            cbNCC.ValueMember = "MaNCC";
            dataTable = NhaCungCapBLL.Instance.FindAll();
            cbNCC.DataSource = dataTable.DefaultView;
            cbNCC.SelectedIndex = -1;

            if (sp != null)
            {
                btnThem.Text = "Lưu";
                txtTen.Text = sp.TenHang;
                txtBaoHanh.Text = sp.BaoHanh.ToString();
                txtGiaBan.Text = sp.DonGia.ToString();
                txtGiaNhap.Text = sp.GiaNhap.ToString();
                txtXuatXu.Text = sp.XuatXu;
                cbLoai.SelectedIndex = sp.MaLoai-1;
                cbNCC.SelectedIndex = sp.MaNCC-1;

                if (sp.Anh != null)
                    pbAnh.Image = converByteToImage(sp.Anh);
            }
            else
            {
                btnThem.Text = "Thêm sản phẩm";
            }
        }

        public Image converByteToImage(Byte[] byteArr)
        {
            if (byteArr == null)
                return null;
            MemoryStream memoryStream = new MemoryStream(byteArr);
            return Image.FromStream(memoryStream);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            Hang hang = new Hang();
            hang.TenHang = txtTen.Text;
            hang.MaLoai = int.Parse(cbLoai.SelectedValue.ToString());
            hang.XuatXu = txtXuatXu.Text;
            hang.MaNCC = int.Parse(cbNCC.SelectedValue.ToString());
            try
            {
                hang.GiaNhap = decimal.Parse(txtGiaNhap.Text);
            }
            catch
            {
                MessageBox.Show("Giá nhập không hợp lệ", "Thông báo");
                txtGiaNhap.Text = "";
                txtGiaNhap.Focus();
            }

            try
            {
                hang.DonGia = decimal.Parse(txtGiaBan.Text);
            }
            catch
            {
                MessageBox.Show("Giá bán không hợp lệ", "Thông báo");
                txtGiaBan.Text = "";
                txtGiaBan.Focus();
            }

            try
            {
                hang.BaoHanh = int.Parse(txtBaoHanh.Text);
            }
            catch
            {
                MessageBox.Show("Thời gian bảo hành không hợp lệ", "Thông báo");
                txtBaoHanh.Text = "";
                txtBaoHanh.Focus();
            }
            if (pbAnh.ImageLocation != null)
                hang.Anh = Utils.Instance.ImageToByteArray(pbAnh.ImageLocation);
            else
                hang.Anh = this.sp.Anh;

            if (sp == null)
            {

                if (HangBLL.Instance.ThemHang(hang))
                {
                    MessageBox.Show("Mặt hàng được thêm thành công", "Thông báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm hàng thất bại !!!", "Thông báo");
                }
            }
            else
            {
                hang.MaHang = sp.MaHang;
               
                if (HangBLL.Instance.SuaHang(hang))
                {
                    MessageBox.Show("Mặt hàng được cập nhật thành công", "Thông báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("cập nhật hàng thất bại !!!", "Thông báo");
                }
            }

        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            frmThemLoai fLoai = new frmThemLoai();
            fLoai.ShowDialog();
            //load lại combobox loai hang
            cbLoai.DisplayMember = "TenLoai";
            cbLoai.ValueMember = "MaLoai";
            DataTable dataTable = LoaiHangBLL.Instance.FindAll();
            cbLoai.DataSource = dataTable.DefaultView;
            cbLoai.SelectedIndex = -1;

        }
    }
}
