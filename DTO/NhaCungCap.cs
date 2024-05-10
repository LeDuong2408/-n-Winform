using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap
    {
        private int _maNCC;
        private string _tenNCC;
        private string _diaChi;
        private string sDT;
        private string _email;

        public NhaCungCap()
        {
        }

        public NhaCungCap(int maNCC, string tenNCC, string diaChi, string sDT, string email)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            DiaChi = diaChi;
            SDT = sDT;
            Email = email;
        }

        public int MaNCC { get => _maNCC; set => _maNCC = value; }
        public string TenNCC { get => _tenNCC; set => _tenNCC = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string Email { get => _email; set => _email = value; }
    }
}
