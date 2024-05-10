using BLL;
using DTO;
using log4net;
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
    public partial class frmQuanLiNCC : Form
    {
        public frmQuanLiNCC()
        {
            InitializeComponent();
        }

        private void frmQuanLiNCC_Load(object sender, EventArgs e)
        {
            LoadNCC();
        }

        private void LoadNCC()
        {
            dgvNCC.DataSource = NhaCungCapBLL.Instance.FindAll();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmNCC fNCC = new frmNCC();
            fNCC.ShowDialog();
            LoadNCC();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            DataGridViewRow row = dgvNCC.SelectedCells[0].OwningRow;

            ncc.MaNCC = int.Parse(row.Cells["MaNCC"].Value.ToString());
            ncc.TenNCC = row.Cells["TenNCC"].Value.ToString();
            ncc.DiaChi = row.Cells["DiaChi"].Value.ToString();
            ncc.SDT = row.Cells["SDT"].Value.ToString();
            ncc.Email = row.Cells["Email"].Value.ToString();

            frmNCC fNCC = new frmNCC(ncc);
            fNCC.ShowDialog();
            LoadNCC();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvNCC.SelectedCells[0].OwningRow;

            int maNCC = int.Parse(row.Cells["MaNCC"].Value.ToString());

            if (MessageBox.Show("Xác nhận xóa nhà cung cấp này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    if (NhaCungCapBLL.Instance.Delete(maNCC))
                    {
                        LoadNCC();
                        MessageBox.Show("Đã xóa nhà cung cấp.", "Thông báo");
                    }
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)

                        if (error.Message.Contains("permission was denied"))
                        {
                            MessageBox.Show("Người dùng không có quyền thực hiện hành động này", "Thông báo");
                        }
                }
                    
                
            }
        }
    }
}
