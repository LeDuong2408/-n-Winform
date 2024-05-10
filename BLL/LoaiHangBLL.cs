using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiHangBLL
    {
        private static LoaiHangBLL instance;
        public static LoaiHangBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiHangBLL();
                return instance;
            }
        }
        public List<string> findAllTenLoai()
        {
            List<string> list = new List<string>();
            list.Add("");
            DataTable dt = LoaiHangDAL.Instance.findAll();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr["TenLoai"].ToString());
            }
            return list;
        }
        public String findLoaiByID(int maLoai)
        {
            return LoaiHangDAL.Instance.findLoaiByID(maLoai);
        }

        public DataTable FindAll()
        {
            return LoaiHangDAL.Instance.findAll();
        }

        public bool Insert(string tenLoai)
        {
            return LoaiHangDAL.Instance.Insert(tenLoai);
        }
    }
}
