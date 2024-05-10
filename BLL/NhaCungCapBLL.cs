using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class NhaCungCapBLL
    {
        private static NhaCungCapBLL instance;
        public static NhaCungCapBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhaCungCapBLL();
                return instance;
            }
        }

        public String findNCCByID(int maNCC)
        {
            return NhaCungCapDAL.Instance.findByID(maNCC);
        }

        public List<string> findAllTenNCC()
        {
            DataTable dt = NhaCungCapDAL.Instance.FindAll();
            List<string> list = new List<string>();
            list.Add("");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr["TenNCC"].ToString());
            }
            return list;
        }

        public DataTable FindAll()
        {
            return NhaCungCapDAL.Instance.FindAll();
        }
        public bool Insert(NhaCungCap ncc)
        {
            try
            {
                return NhaCungCapDAL.Instance.Insert(ncc);
            }
            catch(SqlException ex) {
                throw ex;
            }
        }

        public bool Update(NhaCungCap ncc)
        {
            try
            {
                return NhaCungCapDAL.Instance.Update(ncc);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool Delete(int maNcc)
        {
            try
            {
                return NhaCungCapDAL.Instance.Delete(maNcc);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
