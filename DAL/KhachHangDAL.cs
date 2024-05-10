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
    public class KhachHangDAL
    {
        private static KhachHangDAL instance;
        public static KhachHangDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAL();
                return instance;
            }
        }

        public DataTable FindAll()
        {
            return DataBase.Instance.LayDuLieu("proc_selectAllKH", null);
        }

        public bool Insert(KhachHang kh)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@TenKH", kh.TenKH),
                new SqlParameter("@SDT", kh.SDT),
                new SqlParameter("@DiaChi", kh.DiaChi),
                new SqlParameter("@MaCapBac", kh.MaCapBac)
            };

            int result = DataBase.Instance.ThucThi("proc_themKH", param);
            return result > 0;
        }

        public bool Update(KhachHang kh)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@TenKH", kh.TenKH),
                new SqlParameter("@SDT", kh.SDT),
                new SqlParameter("@DiaChi", kh.DiaChi),
                new SqlParameter("@MaCapBac", kh.MaCapBac),
                new SqlParameter("@MaKH", kh.MaKH)
            };

            int result = DataBase.Instance.ThucThi("proc_UpdateKH", param);
            return result > 0;
        }

        public bool DeleteById(int id)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MaKH", id)
            };

            int result = DataBase.Instance.ThucThi("proc_DeleteKHById", param);
            return result > 0;
        }

        public DataTable FindBy(string tenKH, string capBac)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@TenKH", tenKH),
                new SqlParameter("@CapBac", capBac)
            };
            return DataBase.Instance.LayDuLieu("proc_selectBy", param);
        }

        public string FindCapBacByMaKH(int maKH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "func_findCapBacByMaKH";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaKH", maKH));
            var retValParam = new SqlParameter("RetVal", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.ReturnValue
            };
            cmd.Parameters.Add(retValParam);
            DataBase.Instance.moKetNoi();
            cmd.Connection = DataBase.Instance.conn;
            cmd.ExecuteScalar();
            string capbac = retValParam.Value.ToString();
            DataBase.Instance.dongKetNoi();
            return capbac;
        }
    }
}
