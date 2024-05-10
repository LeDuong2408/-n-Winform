using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataBase
    {
        private static DataBase instance;
        public static DataBase Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataBase();
                return instance;
            }
        }
        public string strconn = @"Data Source=.;Initial Catalog = project_DBMS;Persist Security Info=True;User ID=" + GLOBAL.Username + ";Password=" + GLOBAL.Password + ";MultipleActiveResultSets=True";
        public string strAdmin = @"Data Source=.;Initial Catalog = project_DBMS;Integrated Security=True;MultipleActiveResultSets=True";
        
        public SqlConnection conn = null;
        public SqlConnection connAdmin = null;



        public SqlCommand cmd = null;
        public SqlDataReader reader = null;

        public void ketNoiDBAdmin()
        {
            connAdmin = new SqlConnection(strAdmin);
        }

        public void moKetNoiAdmin()
        {
            if (connAdmin == null)
            {
                ketNoiDBAdmin();
            }
            if (connAdmin.State == ConnectionState.Closed)
            {
                connAdmin.Open();
            }
        }

        public void dongKetNoiAdmin()
        {
            if (connAdmin != null && connAdmin.State == ConnectionState.Open)
            {
                connAdmin.Close();
            }
        }

        public void ketNoiDB()
        { 
            conn = new SqlConnection(strconn);
        }

        public void moKetNoi()
        {
            if (conn == null)
            {
                ketNoiDB();
            }
            if (conn.State == ConnectionState.Closed)
            {
                strconn = @"Data Source=.;Initial Catalog=project_DBMS;Persist Security Info=True;User ID=" + GLOBAL.Username + ";Password=" + GLOBAL.Password + ";MultipleActiveResultSets=True";
                conn = new SqlConnection(strconn);
                conn.Open();
            }
        }

        public void dongKetNoi()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        /// <summary>
        /// dùng để thực thi các procedure lấy dũ liệu (procedure thực hiện select)
        /// </summary>
        /// <param name="procName">tên procedure</param>
        /// <param name="param">danh sách tham số cyar procedure</param>
        /// <returns></returns>
        public DataTable LayDuLieu(string procName, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            if (param != null)
            {
                foreach (SqlParameter p in param)
                {
                    cmd.Parameters.Add(p);
                }
            }
            moKetNoi();
            try
            {

                cmd.Connection = conn;
                //moKetNoi();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.SelectCommand = cmd;
                da.Fill(dt);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dongKetNoi();
            }
            return dt;
        }
        /// <summary>
        /// Thực thi các proc không trả về dữ kiệu (hành động insert,update,delete)
        /// </summary>
        /// <param name="procName">tên procedure</param>
        /// <param name="param">danh sách tham số của procedure đó</param>
        /// <returns></returns>
        public int ThucThi(string procName, SqlParameter[] param)
        {
            cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            if (param != null)
            {
                foreach (SqlParameter p in param)
                {
                    cmd.Parameters.Add(p);
                }
            }
            moKetNoi();
            try
            {
                cmd.Connection = conn;

                int row = cmd.ExecuteNonQuery();
                dongKetNoi();
                return row;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
