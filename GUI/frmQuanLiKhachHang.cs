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
    public partial class frmQuanLiKhachHang : Form
    {
        public frmQuanLiKhachHang()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmQuanLiKhachHang_Load(object sender, EventArgs e)
        {
            FindAllKhachHang();
        }

        private void FindAllKhachHang()
        {
            dgvKhachHang.DataSource = KhachHangBLL.Instance.FindAll();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmThemKhachHang frmThemKH = new frmThemKhachHang();
            frmThemKH.ShowDialog();
            FindAllKhachHang();
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            DataGridViewRow row = dgvKhachHang.SelectedCells[0].OwningRow;
            kh.MaKH = int.Parse(row.Cells["MaKH"].Value.ToString());
            kh.TenKH = row.Cells["HoTen"].Value.ToString();
            kh.SDT = row.Cells["SDT"].Value.ToString();
            kh.DiaChi = row.Cells["DiaChi"].Value.ToString();
            kh.MaCapBac = int.Parse(row.Cells["MaCapBac"].Value.ToString());    
            kh.CapBac = row.Cells["CapBac"].Value.ToString();

            frmThemKhachHang frmThemKH = new frmThemKhachHang(kh, isUpdate: true);
            frmThemKH.ShowDialog();
            FindAllKhachHang();
        }
        //chuyển dữ liệu về form bán hàng
        public delegate void GETDATA(KhachHang kh);
        public GETDATA mydata;
        private void dgvKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            KhachHang kh = new KhachHang();
            DataGridViewRow row = dgvKhachHang.SelectedCells[0].OwningRow;
            kh.MaKH = int.Parse(row.Cells["MaKH"].Value.ToString());
            kh.TenKH = row.Cells["HoTen"].Value.ToString();
            kh.SDT = row.Cells["SDT"].Value.ToString();
            kh.DiaChi = row.Cells["DiaChi"].Value.ToString();
            kh.MaCapBac = int.Parse(row.Cells["MaCapBac"].Value.ToString());
            kh.CapBac = row.Cells["CapBac"].Value.ToString();
            //Chuyển dữ liệu qua form Bán hàng
            try
            {
                mydata(kh);
                this.Close();
            }
            catch 
            {
                frmThemKhachHang frmThemKH = new frmThemKhachHang(kh, isUpdate: false);
                frmThemKH.ShowDialog();
            }
            
            
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            FindAllKhachHang();
            txtTenKH.Text = "";
            cbCapBac.SelectedIndex = 0;
        }
        private void FindBy()
        {
            string capbac = cbCapBac.Text;
            string tenKH = txtTenKH.Text;
            dgvKhachHang.DataSource = KhachHangBLL.Instance.FindBy(tenKH, capbac);
        }
        private void cbCapBac_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindBy();
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            FindBy();
        }
    }
}
