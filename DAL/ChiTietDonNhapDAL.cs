using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietDonNhapDAL
    {
        private static ChiTietDonNhapDAL instance;
        public static ChiTietDonNhapDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietDonNhapDAL();
                return instance;
            }
        }

        public bool Insert(ChiTietDonHang ct)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MaDon", ct.MaDon),
                new SqlParameter("@MaHang", ct.MaHang),
                new SqlParameter("@SoLuong", ct.SoLuong),
            };

            int result = DataBase.Instance.ThucThi("proc_ThemCTDonNhap", param);
            return result > 0;
        }

        public int GetMaCT()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetMaCTDonNhap";
            cmd.CommandType = CommandType.StoredProcedure;
            var retValParam = new SqlParameter("RetVal", SqlDbType.Int)
            {
                Direction = ParameterDirection.ReturnValue
            };
            cmd.Parameters.Add(retValParam);
            DataBase.Instance.moKetNoi();
            cmd.Connection = DataBase.Instance.conn;
            cmd.ExecuteScalar();
            int maCT = int.Parse(retValParam.Value.ToString());
            DataBase.Instance.dongKetNoi();
            return maCT;
        }

        public bool UpdateSoLuongHang(int maCT, int soLuong)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MaCT", maCT),
                new SqlParameter("@SoLuong", soLuong),
            };
            try
            {
                int result = DataBase.Instance.ThucThi("proc_UpdateSoLuongCTDonNhap", param);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
