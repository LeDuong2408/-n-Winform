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
    public class DonBanBLL
    {
        private static DonBanBLL instance;
        public static DonBanBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DonBanBLL();
                return instance;
            }
        }

        public bool Insert(int maNV, int maKH)
        {
            return DonBanDAL.Instance.Insert(maNV,maKH);
        }

        public int GetMaDon()
        {
            return DonBanDAL.Instance.GetMaDon();
        }

        public bool UpdateKH(int maDon, int maKH)
        {
            return DonBanDAL.Instance.UpdateKH(maDon,maKH);
        }

        public decimal GetTongGTById(int maDon)
        {
            return DonBanDAL.Instance.GetTongGTById((int)maDon);
        }

        public DonBan GetDonBanById(int maDon)
        {
            DataTable dt = DonBanDAL.Instance.GetDonBanById((int)maDon);
            DonBan donBan= new DonBan();
            DataRow dr = dt.Rows[0];
            donBan = ConverDataRowToDonBan(dr);
            return donBan;
        }

        private DonBan ConverDataRowToDonBan(DataRow dr)
        {
            DonBan donban = new DonBan();
            donban.MaDon = int.Parse(dr["MaDon"].ToString());
            donban.NgayTao = Convert.ToDateTime(dr["NgayTao"]).ToString("dd/MM/yyy");
            donban.MaNV = int.Parse(dr["MaNV"].ToString());
            donban.MaKH = int.Parse(dr["MaKH"].ToString());
            try
            {
                donban.MaVoucher = int.Parse(dr["MaVoucher"].ToString());
            }
            catch
            {
                donban.MaVoucher = 0;
            }
            donban.TrangThai = dr["TrangThai"].ToString();
            donban.TongGT = decimal.Parse(dr["TongGT"].ToString());
            donban.ChieuKhau = decimal.Parse(dr["ChietKhau"].ToString());
            donban.VAT = decimal.Parse(dr["VAT"].ToString());
            donban.ThanhTien = decimal.Parse(dr["ThanhTien"].ToString());
            try
            {
                donban.TenKH = dr["HoTen"].ToString();
            }
            catch
            {
                donban.TenKH = "";
            }


            return donban;
        }

        public bool UpdateVoucher(int maVoucher, int maDon)
        {
            return DonBanDAL.Instance.UpdateVoucher(maVoucher, maDon);
        }

        public bool ThanhToanDon(int maDon)
        {
            return DonBanDAL.Instance.ThanhToanDon((int)maDon);
        }

        public List<DonBan> FindAll()
        {
            List<DonBan> list = new List<DonBan>();
            DataTable dt = DonBanDAL.Instance.FindAll();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConverDataRowToDonBan(row));
            }

            return list;
        }

        public List<DonBan> FindByAll(DateTime ngayBD, DateTime ngayKT, string trangthai)
        {
            if (trangthai == "All")
                trangthai = "";

            List<DonBan> list = new List<DonBan>();
            DataTable dt = DonBanDAL.Instance.FindByAll(ngayBD, ngayKT, trangthai);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConverDataRowToDonBan(row));
            }

            return list;
        }
    }
}
