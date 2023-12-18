namespace DTPMBanQuanAo.Models{
    public class ProductModel{
        public SanPham SanPham {get; set;} = new SanPham();
        public IFormFile FileUpload {get; set;}
    }
}