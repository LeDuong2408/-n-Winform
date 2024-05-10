using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietDonNhapBLL
    {
        private static ChiTietDonNhapBLL instance;
        public static ChiTietDonNhapBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietDonNhapBLL();
                return instance;
            }
        }

        public bool Insert(ChiTietDonHang ct)
        {
            return ChiTietDonNhapDAL.Instance.Insert(ct);
        }

        public int GetMaCT()
        {
            return ChiTietDonNhapDAL.Instance.GetMaCT();
        }

        public bool UpdateSoLuongHang(int maCT, int soLuong)
        {
            try
            {
                return ChiTietDonNhapDAL.Instance.UpdateSoLuongHang(maCT, soLuong);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
