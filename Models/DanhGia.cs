using System.ComponentModel.DataAnnotations;

namespace DTPMBanQuanAo.Models
{
    public class DanhGia
    {
        [Key]
        public int Id { get; set; }
        public int KhachHangId { get; set; }
        public int SanPhamId {  get; set; }
        [Display(Name = "Xếp hạng")]
        public int XepHang {  get; set; }
        public DateTime ThoiGian { get; set; }
        [Display(Name = "Lời bình")]
        public string LoiBinh { get; set; }
        public string DanhGiaThu { get; set; }

        public TaiKhoan TaiKhoan { get; set; }
        public SanPham SanPham { get; set; }


    }
}
