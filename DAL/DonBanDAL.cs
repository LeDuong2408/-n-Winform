using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DonBanDAL
    {
        private static DonBanDAL instance;
        public static DonBanDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DonBanDAL();
                return instance;
            }
        }

        public bool Insert(int maNV, int maKH)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@MaKH", maKH)
            };

            int result = DataBase.Instance.ThucThi("insertDonBan", param);
            return result > 0;
        }

        public int GetMaDon()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetMaDonBan";
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

        public bool UpdateKH(int maDon, int maKH)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MaDon", maDon),
                new SqlParameter("@MaKH", maKH)
            };

            int result = DataBase.Instance.ThucThi("proc_UpdateDonBan_MaKH", param);
            return result > 0;
        }
      
        public decimal GetTongGTById(int maDon)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetGTDonBanById";
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

        public DataTable GetDonBanById(int maDon)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MaDon", maDon),
            };

            return DataBase.Instance.LayDuLieu("proc_GetDonBanById", param);
            
        }

        public bool UpdateVoucher(int maVoucher, int maDon)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MaVoucher", maVoucher),
                new SqlParameter("@MaDon", maDon)
            };

            int result = DataBase.Instance.ThucThi("proc_UpdateDonBan_Mavvoucher", param);
            return result > 0;
        }

        public bool ThanhToanDon(int maDon)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MaDon", maDon),
            };

            int result = DataBase.Instance.ThucThi("proc_ThanhToanDonBan", param);
            return result > 0;
        }

        public DataTable FindByAll(DateTime ngayBD, DateTime ngayKT, string trangthai)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@NgayBatDau",ngayBD),
                new SqlParameter("@NgayKetThuc",ngayKT),
                new SqlParameter("TrangThai", trangthai)
            };
            return DataBase.Instance.LayDuLieu("proc_FindDonBanByNgay", param);
        }

        public DataTable FindAll()
        {
            DataTable dt = new DataTable();
            return DataBase.Instance.LayDuLieu("proc_findAllDonBan", null);
        }
    }
}
