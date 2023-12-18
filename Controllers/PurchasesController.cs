using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore;
using DTPMBanQuanAo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DTPMBanQuanAo.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly AppDBContext _context;
        public PurchasesController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(){
            ViewBag.SanPham = new SelectList(_context.SanPham, "Id", "Ten"); 
            ViewBag.TaiKhoan = new SelectList(_context.TaiKhoan.Where(p=>p.IdLoaiTK == 3), "Id", "Name"); 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PurchasesModel purchasesModel)
        {
            var purchases = purchasesModel.PhieuNhapKho;
            var purchasesDetail = purchasesModel.ChiTietPNK;
            DateTime date = DateTime.Now;
            var createPurchasesDetail = 0;
            purchases.NgayNhap = date;
            if(ModelState.IsValid){
                _context.Add(purchases);
                var createPurchases = await _context.SaveChangesAsync();
                if(createPurchases > 0)
                {
                    var purchasesTemp = await _context.PhieuNhapKho.FirstOrDefaultAsync(p=> p.NgayNhap.Equals(date));
                    int IdPurchases = purchasesTemp.Id;
                    purchasesDetail.PhieuNhapKhoId = IdPurchases;
                    purchasesDetail.TongTienMuc = purchasesDetail.SoLuong * purchasesDetail.DonGiaNhap;
                    _context.Add(purchasesDetail);
                    createPurchasesDetail= await _context.SaveChangesAsync();
                }
                if(createPurchasesDetail > 0)
                {
                    var product = _context.SanPham.FirstOrDefault(p => p.Id == purchasesDetail.SanPhamId);
                    if(product == null){
                        return NotFound();
                    }
                    product.SoLuong += purchasesDetail.SoLuong;
                    if(product.DonGiaNhap == 0)
                    {
                        product.DonGiaNhap = purchasesDetail.DonGiaNhap;
                    }
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
            }

            return View(purchasesModel);
        }
    }
}
