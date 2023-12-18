using System.ComponentModel.DataAnnotations;

namespace DTPMBanQuanAo.Models
{
    public class ChiTietPNK
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nhập số lượng sản phẩm")]
        [Range(0, int.MaxValue, ErrorMessage = "Nhập giá trị là số")]
        [Display(Name ="Số lượng")]
        public int SoLuong { get; set; }
        [Display(Name ="Tên sản phẩm")]
        public int SanPhamId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Nhập giá trị là số")]
        [Required(ErrorMessage ="Vui lòng nhập đơn giá")]
        [Display(Name ="Đơn giá nhập")] 
        public double DonGiaNhap {get; set;}
        [Display(Name ="Tổng tiền mục")] 
        public double TongTienMuc {get; set;}
        public int PhieuNhapKhoId { get; set; }
        public SanPham SanPham { get; set; }
        public PhieuNhapKho PhieuNhapKho { get; set; }
        public ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }

    }
}
