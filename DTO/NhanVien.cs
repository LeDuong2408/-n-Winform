using System;

namespace DTO
{
    public class NhanVien
    {
        private int _maNV;
        private string _tenNV;
        private string _ngaySinh;
        private string _gioiTinh;
        private string _diaChi;
        private string _SDT;
        private string _chucVu;
        private string _ngayTuyenDung;
        private string _trangThai;
        private byte[] _anh;

        public int MaNV { get => _maNV; set => _maNV = value; }
        public string TenNV { get => _tenNV; set => _tenNV = value; }
        public string NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public string ChucVu { get => _chucVu; set => _chucVu = value; }
        public string NgayTuyenDung { get => _ngayTuyenDung; set => _ngayTuyenDung = value; }
        public string TrangThai { get => _trangThai; set => _trangThai = value; }
        public byte[] Anh { get => _anh; set => _anh = value; }

        public NhanVien(int maNV, string tenNV, string ngaySinh, string gioiTinh, string diaChi, string sDT, string chucVu, string ngaytd, byte[] anh = null)
        {
            MaNV = maNV;
            TenNV = tenNV;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            SDT = sDT;
            ChucVu = chucVu;
            NgayTuyenDung = ngaytd;
            _anh = anh;
        }

        public NhanVien()
        {
        }

    }
}
