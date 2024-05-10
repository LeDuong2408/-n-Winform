using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        private void frmThongKe_Load(object sender, EventArgs e)
        {
            // Thực thi stored procedure và lấy dữ liệu
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=projectCuoiKi_new;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("ThongKeTheoNgay", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ngaybatdau", SqlDbType.Date).Value = DateTime.Parse("2023-11-1");
                    cmd.Parameters.AddWithValue("@ngayketthuc", SqlDbType.Date).Value = DateTime.Parse("2023-11-11");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                }
            }


            // Thiết lập thuộc tính cho loạt dữ liệu
            chart1.Series["Doanh thu"].ChartType = SeriesChartType.Column;
            chart1.Series["Doanh thu"].XValueMember = "Ngay";
            chart1.Series["Doanh thu"].YValueMembers = "DoanhThu";


            // Thiết lập nguồn dữ liệu và vẽ biểu đồ
            chart1.DataSource = dataTable;
            dgvThongKe.DataSource = dataTable;

            int tongGiaTri = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                tongGiaTri += Convert.ToInt32(row["DoanhThu"]);
            }
            lblTongGiaTri.Text += tongGiaTri.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
            chart1.DataBind();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Thực thi stored procedure và lấy dữ liệu
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=project_DBMS;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("ThongKeTheoNgay", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ngaybatdau", SqlDbType.Date).Value = dpkBatDau.Value;
                    cmd.Parameters.AddWithValue("@ngayketthuc", SqlDbType.Date).Value = dpkKetThuc.Value;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                }
            }



            // Thiết lập thuộc tính cho loạt dữ liệu
            chart1.Series["Doanh thu"].ChartType = SeriesChartType.Column;
            chart1.Series["Doanh thu"].XValueMember = "Ngay";
            chart1.Series["Doanh thu"].YValueMembers = "DoanhThu";

            // Thiết lập nguồn dữ liệu và vẽ biểu đồ
            chart1.DataSource = dataTable;
            dgvThongKe.DataSource = dataTable;

            int tongGiaTri = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                tongGiaTri += Convert.ToInt32(row["DoanhThu"]);
            }
            lblTongGiaTri.Text = $"Tổng giá trị: {tongGiaTri.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"))}";
            chart1.DataBind();
        }
    }
}
