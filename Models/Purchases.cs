namespace DTPMBanQuanAo.Models;
public class Purchases{
    public PhieuNhapKho PhieuNhapKho {get; set;} = new PhieuNhapKho();
    public List<ChiTietPNK> ChiTietPNK {get; set;} = new List<ChiTietPNK>();


}