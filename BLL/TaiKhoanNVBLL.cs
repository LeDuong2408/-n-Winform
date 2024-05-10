using DAL;
using DTO;
using System;

namespace BLL
{
    public class TaiKhoanNVBLL
    {
        private static TaiKhoanNVBLL instance;
        public static TaiKhoanNVBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoanNVBLL();
                return instance;
            }
        }
        public string checkLogin(TaiKhoanNV tk)
        {
            if (tk.taikhoan == "")
                return "empty account";
            if (tk.matkhau == "")
                return "empty password";
            return TaiKhoanNVDAL.Instance.checkLogin(tk);
        }

        public bool Insert(TaiKhoanNV taiKhoanNV)
        {
            try
            {
                return TaiKhoanNVDAL.Instance.Insert(taiKhoanNV);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public int GetMaNV()
        {
            return TaiKhoanNVDAL.Instance.GetMaNV();
        }

        public bool XoaTK(int maNV)
        {
            try
            {
                return TaiKhoanNVDAL.Instance.XoaTK(maNV);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}
