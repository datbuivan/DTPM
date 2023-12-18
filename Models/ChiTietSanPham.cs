using System.ComponentModel.DataAnnotations;

namespace DTPMBanQuanAo.Models
{
    public class ChiTietSanPham
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Không được để trống")]
        [Display(Name ="Imei")]
        [StringLength(30)]
        public string Imei { get; set; }
        [Display(Name ="Mã Phiếu nhập kho")]
        public int ChiTietPNKId { get; set; }
        [Display(Name ="Sản phẩm")]
        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
        public ChiTietPNK ChiTietPNK { get; set; }
    }
}
