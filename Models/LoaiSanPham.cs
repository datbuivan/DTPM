using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTPMBanQuanAo.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name = "Tên loại sản phẩm")]
        public string TenLoaiSP { get; set; }
        //[ForeignKey("ParentId")]
        public LoaiSanPham Parent { get; set;  }
        public int? ParentId { get; set; }
        public ICollection<LoaiSanPham> Children { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }

       



    }
}
