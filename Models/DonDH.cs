using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DTPMBanQuanAo.Models
{
    public class DonDH
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Ngày đặt")]
        public DateTime NgayDat { get; set; }
        [Display(Name ="Khách hàng")]
        public int KhachHangId { get; set; }
        [Display(Name ="Nhân viên")]
        public int NhanVienId {  get; set; }
        [Display(Name ="Trạng thái đơn hàng")]
        public bool TrangThai { get; set; }
        [StringLength(200)]
        [Display(Name ="Mô tả")]
        public string MoTa {  get; set; }
        [Display(Name ="Trạng thái thanh toán")]
        public bool TrangThaiThanhToan {get; set;}
        [Display(Name ="Tổng tiền")]
        public double TongTien {get; set;}
        public TaiKhoan TaiKhoan { get; set; }
        public ICollection<ChiTietDDH> ChiTietDDHs { get; set; }

    }
}
