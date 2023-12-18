using System.ComponentModel.DataAnnotations;

namespace DTPMBanQuanAo.Models
{
    public class ThuongHieu
    {
        [Key]
        public int Id {  get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Tên thương hiệu")]
        public string TenThuongHieu { get; set; }

        [StringLength(200)]
        public string HinhAnh { get; set; }
        [StringLength(200)]
        [Display(Name = "Mô tả")]
        public string Mota {  get; set; }

        public ICollection<SanPham> SanPhams { get; set; }


    }
}
