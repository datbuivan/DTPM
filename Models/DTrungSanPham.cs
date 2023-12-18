namespace DTPMBanQuanAo.Models
{
    public class DTrungSanPham
    {
        public int DacTrungId { get; set; }
        public int SanPhamId { get; set; }
        public DacTrung DacTrung { get; set; }
        public SanPham SanPham { get; set; }  
    }
}
