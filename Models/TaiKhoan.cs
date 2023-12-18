using System.ComponentModel.DataAnnotations;

namespace DTPMBanQuanAo.Models
{
    public class TaiKhoan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name= "Tên tài khoản")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Display(Name="Mật khẩu")]
        [StringLength(50)]
        public string Password {  get; set; }
        [StringLength(30)]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        public int IdLoaiTK { get; set; }

        public LoaiTaiKhoan LoaiTaiKhoan { get; set; } 
        public ICollection<DanhGia> DanhGias { get; set; }
        public ICollection<DonDH> DonDHs { get; set; }

        
    }
}
