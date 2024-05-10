using System;

namespace DTO
{
    public class DonBan
    {
        private int _maDon;
        private string _ngayTao;
        private int _maKH;
        private int _maNV;
        private int _maVoucher;
        private string _trangThai;
        private decimal _tongGT;
        private decimal _chieuKhau;
        private decimal _thanhTien;
        private decimal _vAT;
        private string _tenKH;
  
        public int MaDon { get => _maDon; set => _maDon = value; }
         public int MaKH { get => _maKH; set => _maKH = value; }
        public int MaNV { get => _maNV; set => _maNV = value; }
        public int MaVoucher { get => _maVoucher; set => _maVoucher = value; }
        public string TrangThai { get => _trangThai; set => _trangThai = value; }
        public decimal TongGT { get => _tongGT; set => _tongGT = value; }
        public decimal ChieuKhau { get => _chieuKhau; set => _chieuKhau = value; }
        public decimal ThanhTien { get => _thanhTien; set => _thanhTien = value; }
        public decimal VAT { get => _vAT; set => _vAT = value; }
        public string NgayTao { get => _ngayTao; set => _ngayTao = value; }
        public string TenKH { get => _tenKH; set => _tenKH = value; }

        public DonBan()
        {
        }
    }
}
