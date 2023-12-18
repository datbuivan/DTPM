using System.ComponentModel.DataAnnotations;

namespace DTPMBanQuanAo.Models
{
    public class ChiTietDDH
    {
        [Key]
        public int Id { get; set; }
        public int SoLuong {  get; set; }
        public int DDHId { get; set; }
        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
        public DonDH DonDH { get; set; }
    }
}
