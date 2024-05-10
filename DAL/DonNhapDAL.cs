using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonNhapDAL
    {
        private static DonNhapDAL instance;
        public static DonNhapDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DonNhapDAL();
                return instance;
            }
        }

        public bool Insert(int maNV)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MaNV", maNV),
            };

            int result = DataBase.Instance.ThucThi("insertDonNhap", param);
            return result > 0;
        }

        public int GetMaDon()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetMaDon";
            cmd.CommandType = CommandType.StoredProcedure;
            var retValParam = new SqlParameter("RetVal", SqlDbType.Int)
            {
                Direction = ParameterDirection.ReturnValue
            };
            cmd.Parameters.Add(retValParam);
            DataBase.Instance.moKetNoi();
            cmd.Connection = DataBase.Instance.conn;
            cmd.ExecuteScalar();
            int maDon = int.Parse(retValParam.Value.ToString());
            DataBase.Instance.dongKetNoi();
            return maDon;
        }

        public decimal GetTongGTById(int maDon)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetGTDonNhapById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaDon", maDon));
            var retValParam = new SqlParameter("RetVal", SqlDbType.Int)
            {
                Direction = ParameterDirection.ReturnValue
            };
            cmd.Parameters.Add(retValParam);
            DataBase.Instance.moKetNoi();
            cmd.Connection = DataBase.Instance.conn;
            cmd.ExecuteScalar();
            decimal TongGt = decimal.Parse(retValParam.Value.ToString());
            DataBase.Instance.dongKetNoi();
            return TongGt;
        }

        public bool UpdateThanhToan(int maDon)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MaDon", maDon)
            };
            int result = DataBase.Instance.ThucThi("UpdateTrangThaiDonNhap", param);
            return result > 0;
        }
    }
}
