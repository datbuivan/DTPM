using System.ComponentModel.DataAnnotations;

namespace DTPMBanQuanAo.Models
{
    public class DacTrung
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Loại đặc trưng")]
        public int LoaiDacTrungId { get; set; }
        [Display(Name = "Số thứ tự")]
        public int SoThuTu { get; set; }
        [Display(Name ="Tên đặc trưng")]
        [StringLength(50)]
        public string Ten {  get; set; }
        [Display(Name = "Ký hiệu")]
        public string KyHieu { get; set; }
        [Display(Name = "Giá trị")]
        [StringLength(50)]
        public string GiaTri { get; set; }
        [Display(Name = "Đơn vị")]
        [StringLength(50)]
        public string DonVi  { get; set; }
        [StringLength(50)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        public LoaiDacTrung LoaiDacTrung { get; set; }
        public ICollection<DTrungSanPham> DTrungSanPhams { get; set; } 

    }
}
