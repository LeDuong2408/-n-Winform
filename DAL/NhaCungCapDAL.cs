using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCungCapDAL
    {
        private  SqlCommand cmd = null;
        private static NhaCungCapDAL instance;
        public static NhaCungCapDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhaCungCapDAL();
                return instance;
            }
        }

        public String findByID(int maNCC)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "func_findNCCByID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maNCC", maNCC));
            var retValParam = new SqlParameter("RetVal", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.ReturnValue
            };
            cmd.Parameters.Add(retValParam);
            DataBase.Instance.moKetNoi();
            cmd.Connection = DataBase.Instance.conn;
            String tenNCC = null;
            cmd.ExecuteScalar();
            tenNCC = retValParam.Value.ToString();
            DataBase.Instance.dongKetNoi();
            return tenNCC;
        }

        public DataTable FindAll()
        {
            return DataBase.Instance.LayDuLieu("proc_selectAllNCC", null);
        }

        public bool Insert(NhaCungCap ncc)
        {

            SqlParameter[] param =
            {
                new SqlParameter("@TenNCC", ncc.TenNCC ),
                new SqlParameter("@DiaChi", ncc.DiaChi),
                new SqlParameter("@SDT", ncc.SDT),
                new SqlParameter("@Email", ncc.Email),
            };
            try
            {
                int result = DataBase.Instance.ThucThi("proc_themNCC", param);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            
        }

        public bool Update(NhaCungCap ncc)
        {

            SqlParameter[] param =
            {
                new SqlParameter("@MaNCC", ncc.MaNCC ),
                new SqlParameter("@TenNCC", ncc.TenNCC ),
                new SqlParameter("@DiaChi", ncc.DiaChi),
                new SqlParameter("@SDT", ncc.SDT),
                new SqlParameter("@Email", ncc.Email),
            };
            try
            {
                int result = DataBase.Instance.ThucThi("proc_UpdateNCC", param);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public bool Delete(int maNCC)
        {

            SqlParameter[] param =
            {
                new SqlParameter("@MaNCC", maNCC),
            };
            try
            {
                int result = DataBase.Instance.ThucThi("proc_DeleteNCC", param);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }
}
