namespace DTO

{
    public class KhachHang
    {
        private int _maKH;
        private string _tenKH;
        private string _sDT;
        private string _diaChi;
        private int _maCapBac;
        private string _capBac;

        public int MaKH { get => _maKH; set => _maKH = value; }
        public string TenKH { get => _tenKH; set => _tenKH = value; }
        public string SDT { get => _sDT; set => _sDT = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public int MaCapBac { get => _maCapBac; set => _maCapBac = value; }
        public string CapBac { get => _capBac; set => _capBac = value; }

        public KhachHang(int maKH, string tenKH, string sDT, string diaChi, int maCapBac, string capBac)
        {
            MaKH = maKH;
            TenKH = tenKH;
            SDT = sDT;
            DiaChi = diaChi;
            MaCapBac = maCapBac;
            CapBac = capBac;
        }

        public KhachHang()
        {
        }

    }
}
