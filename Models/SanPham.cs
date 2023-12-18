using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTPMBanQuanAo.Models
{
    public class SanPham
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(50)]
        [Display(Name = "Tên sản phẩm")]
        public string Ten { get; set; }
        [StringLength(200)]
        [Display(Name ="Image")]
        public string HinhAnh { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập đơn giá nhập")]
        [Range(0, int.MaxValue, ErrorMessage="Nhập giá trị từ {1}")]
        [Display(Name ="Đơn Giá Nhập")]
        public double DonGiaNhap { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập giá bán")]
        [Range(0, int.MaxValue, ErrorMessage="Nhập giá trị từ {1}")]
        [Display(Name ="Đơn Giá Bán")]
        public double DonGiaBan  { get; set; }
        [Display(Name ="Số Lượng")]
        [Range(0, int.MaxValue, ErrorMessage="Nhập giá trị từ {1}")]
        public int SoLuong { get; set; }
        [StringLength(200)]
        [Display(Name = "Mô tả")]
        public string MoTa {  get; set; }
        [Display(Name ="Loại sản phẩm")]
        public int LoaiSanPhamId { get; set; }
        public LoaiSanPham LoaiSanPham { get; set; }
        [Display(Name ="Thương hiệu ")]
        public int ThuongHieuId { get; set; }
        public ThuongHieu ThuongHieu { get; set; }
        public ICollection<DanhGia> DanhGias { get; set; }
        public ICollection<DTrungSanPham> DTrungSanPhams { get; set; }
        public ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public ICollection<ChiTietPNK> ChiTietPNKs { get; set; }
        public ICollection<ChiTietDDH> ChiTietDDHs { get; set; }
        [NotMapped]
        public IFormFile FileImage {get; set;}
    }
}
