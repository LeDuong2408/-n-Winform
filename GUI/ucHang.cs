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
    public partial class ucHang : UserControl
    {
        public Hang hang = new Hang();
        private bool isSale;
        public ucHang()
        {
            InitializeComponent();
        }
        public ucHang(Hang hang, bool isSale)
        {
            InitializeComponent();
            this.hang = hang;
            this.isSale = isSale;
            
        }

        private void ucHang_Load(object sender, EventArgs e)
        {
            lbTenHang.Text = $"Sản phẩm: {hang.TenHang}";
            if (isSale)
            {
                lbGia.Text = $"Giá bán: {hang.DonGia}";
            }
            else
            {
                lbGia.Text = $"Giá Nhập: {hang.GiaNhap}";
            }
            pbAnh.Image = Utils.Instance.converByteToImage(hang.Anh);
        }
    }
}
