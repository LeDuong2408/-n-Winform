namespace DTO
{
    public class Hang
    {
        private int _maHang;
        private string _tenHang;
        private int _baoHanh;
        private string _xuatXu;
        private int _soLuong;
        private int _maNCC;
        private string _tenNCC;
        private int _maLoai;
        private string _tenLoai;
        private decimal _donGia;
        private string _trangThai;
        private decimal _giaNhap;
        private byte[] _anh;
    
        public Hang()
        {
        }

        public Hang(int maHang, string tenHang, int baoHanh, string xuatXu, int soLuong, int maNhaCungCap, string nhaCungCap, int maLoai, string loaiHang, decimal donGia, string trangThai)
        {
            MaHang = maHang;
            TenHang = tenHang;
            BaoHanh = baoHanh;
            XuatXu = xuatXu;
            SoLuong = soLuong;
            MaNCC = maNhaCungCap;
            TenNCC = nhaCungCap;
            MaLoai = maLoai;
            TenLoai = loaiHang;
            DonGia = donGia;
            TrangThai = trangThai;
        }

        public int MaHang { get => _maHang; set => _maHang = value; }
        public string TenHang { get => _tenHang; set => _tenHang = value; }
        public int BaoHanh { get => _baoHanh; set => _baoHanh = value; }
        public string XuatXu { get => _xuatXu; set => _xuatXu = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public int MaNCC { get => _maNCC; set => _maNCC = value; }
        public string TenNCC { get => _tenNCC; set => _tenNCC = value; }
        public int MaLoai { get => _maLoai; set => _maLoai = value; }
        public string TenLoai { get => _tenLoai; set => _tenLoai = value; }
        public decimal DonGia { get => _donGia; set => _donGia = value; }
        public string TrangThai { get => _trangThai; set => _trangThai = value; }
        public decimal GiaNhap { get => _giaNhap; set => _giaNhap = value; }
        public byte[] Anh { get => _anh; set => _anh = value; }
    }


}
