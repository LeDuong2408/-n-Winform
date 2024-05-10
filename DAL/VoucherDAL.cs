using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VoucherDAL
    {
        private static VoucherDAL instance;
        public static VoucherDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new VoucherDAL();
                return instance;
            }
        }

        public DataTable FindAll()
        {
            return DataBase.Instance.LayDuLieu("proc_selectAllVoucher", null);
        }
    }
}
