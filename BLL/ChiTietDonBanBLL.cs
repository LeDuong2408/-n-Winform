using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietDonBanBLL
    {
        private static ChiTietDonBanBLL instance;
        public static ChiTietDonBanBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietDonBanBLL();
                return instance;
            }
        }

        public bool Insert(ChiTietDonHang ct)
        {
            return ChiTietDonBanDAL.Instance.Insert(ct);
        }

        public int GetMaCT()
        {
            return ChiTietDonBanDAL.Instance.GetMaCT();
        }

        public bool UpdateSoLuongHang(int maCT, int soLuong)
        {
            try
            {
                return ChiTietDonBanDAL.Instance.UpdateSoLuongHang(maCT, soLuong);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<ChiTietDonHang> FindByMaDon(int madon)
        {
            DataTable dt = ChiTietDonBanDAL.Instance.FindByMaDon(madon);
            List<ChiTietDonHang> list = new List<ChiTietDonHang>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ConverDataRowToCTDon(dr));
            }

            return list;
        }

        private ChiTietDonHang ConverDataRowToCTDon(DataRow row)
        {
            ChiTietDonHang ctDon = new ChiTietDonHang();

            ctDon.MaChiTiet = int.Parse(row["MaChiTiet"].ToString());
            ctDon.MaDon = int.Parse(row["MaDon"].ToString());
            ctDon.SoLuong = int.Parse(row["SoLuong"].ToString());
            ctDon.ThanhTien = decimal.Parse(row["ThanhTien"].ToString());
            ctDon.MaHang = int.Parse(row["MaHang"].ToString());
            ctDon.TenHang = row["TenHang"].ToString();

            return ctDon;
        }
    }
}
