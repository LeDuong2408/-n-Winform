using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietDonNhap
    {
        private int _maChiTiet;
        private int _maDon;
        private int _maHang;
        private int _soLuong;
        private decimal _thanhTien;

        public int MaChiTiet { get => _maChiTiet; set => _maChiTiet = value; }
        public int MaDon { get => _maDon; set => _maDon = value; }
        public int MaHang { get => _maHang; set => _maHang = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public decimal ThanhTien { get => _thanhTien; set => _thanhTien = value; }

        public ChiTietDonNhap(int maChiTiet, int maDon, int maHang, int soLuong, decimal thanhTien)
        {
            MaChiTiet = maChiTiet;
            MaDon = maDon;
            MaHang = maHang;
            SoLuong = soLuong;
            ThanhTien = thanhTien;
        }

        public ChiTietDonNhap()
        {
        }
    }
}
