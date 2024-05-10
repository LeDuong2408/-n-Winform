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
    public class KhachHangBLL
    {
        private static KhachHangBLL instance;
        public static KhachHangBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangBLL();
                return instance;
            }
        }

        public DataTable FindAll()
        {   
            return KhachHangDAL.Instance.FindAll();
        }

        public bool Insert(KhachHang kh)
        {
            return KhachHangDAL.Instance.Insert(kh);
        }

        public bool Update(KhachHang kh)
        {
            return KhachHangDAL.Instance.Update(kh);
        }

        public DataTable FindBy(string tenKH, string capBac)
        {
            if (capBac == null)
                capBac = "";
            return KhachHangDAL.Instance.FindBy(tenKH, capBac);
        }

        public DataTable FindByTenHang(string tenhang)
        {
            return HangDAL.Instance.FindByTenHang(tenhang);
        }

        public string FindCapBacByMaKH(int maKH)
        {
            return KhachHangDAL.Instance.FindCapBacByMaKH(maKH);
        }

    }
}
