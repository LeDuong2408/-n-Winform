using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Voucher
    {
        private int _maVoucher;
        private string _tenVoucher;
        private string _ngayBatDau;
        private string _ngayKetThuc;
        private int _khuyenMai;
        private decimal _giamToiDa;
        private int _soLuong;

        public Voucher()
        {
        }

        public int MaVoucher { get => _maVoucher; set => _maVoucher = value; }
        public string TenVoucher { get => _tenVoucher; set => _tenVoucher = value; }
       
        public int KhuyenMai { get => _khuyenMai; set => _khuyenMai = value; }
        public decimal GiamToiDa { get => _giamToiDa; set => _giamToiDa = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public string NgayBatDau { get => _ngayBatDau; set => _ngayBatDau = value; }
        public string NgayKetThuc { get => _ngayKetThuc; set => _ngayKetThuc = value; }
    }
}
