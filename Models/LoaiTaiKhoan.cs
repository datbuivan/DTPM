using System.ComponentModel.DataAnnotations;

namespace DTPMBanQuanAo.Models
{
    public class LoaiTaiKhoan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Tên loại tài khoản")]
        public string TenLoaiTk { get; set; }
        public ICollection<TaiKhoan> TaiKhoans {  get; set; }

    }
}
