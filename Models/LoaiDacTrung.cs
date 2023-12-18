using System.ComponentModel.DataAnnotations;

namespace DTPMBanQuanAo.Models
{
    public class LoaiDacTrung
    {
        [Key]
        public int Id { get; set; }
        public string TenLoaiDacTrung { get; set; }

        public ICollection<DacTrung> DacTrungs { get; set;}
    }
}
