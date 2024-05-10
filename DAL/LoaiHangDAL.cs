using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiHangDAL
    {
        private SqlCommand cmd = null;
        private static LoaiHangDAL instance;
        public static LoaiHangDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiHangDAL();
                return instance;
            }
        }

        public DataTable findAll()
        {
            return DataBase.Instance.LayDuLieu("proc_selectAllLoai", null);
        }

        public String findLoaiByID(int maLoai)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "func_findLoaiByID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maLoai", maLoai));
            var retValParam = new SqlParameter("RetVal", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.ReturnValue
            };
            cmd.Parameters.Add(retValParam);
            DataBase.Instance.moKetNoi();
            cmd.Connection = DataBase.Instance.conn;
            String tenLoai = null;
            cmd.ExecuteScalar();
            tenLoai = retValParam.Value.ToString();
            DataBase.Instance.dongKetNoi();
            return tenLoai;
        }

        public bool Insert(string tenLoai)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@TenLoai", tenLoai),
            };
            int result = DataBase.Instance.ThucThi("proc_ThemLoai", param);
            return result > 0;
        }

    }
}
