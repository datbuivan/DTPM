using System.ComponentModel.DataAnnotations;

namespace DTPMBanQuanAo.Models
{
    public class PhieuNhapKho
    {
        [Key]
        public int Id { get; set; }
        public DateTime NgayNhap { get; set; }
        [Display(Name ="Tên Nhân viên")]
        public int NhanVienId { get; set; }
        [Display(Name ="Trạng thái")]
        public bool TrangThai { get; set; }
        [Display(Name ="Mô tả")]
        [StringLength(200)]
        public string MoTa {  get; set; }
        [Display(Name ="Tổng tiền")]
        public double TongTien {get;set;}
        public ICollection<ChiTietPNK> ChiTietPNKs { get; set; }

    }
}
