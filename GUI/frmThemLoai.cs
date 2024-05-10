using BLL;
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
    public partial class frmThemLoai : Form
    {
        public frmThemLoai()
        {
            InitializeComponent();
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            string loai = txtTen.Text;

            if (LoaiHangBLL.Instance.Insert(loai))
            {
                MessageBox.Show("Đã thêm loại hàng","Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm loại hàng thất bại !!", "Thông báo");
            }
        }
    }
}
