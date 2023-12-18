using System.ComponentModel.DataAnnotations;
using DTPMBanQuanAo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DTPMBanQuanAo.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDBContext _context;
        private IWebHostEnvironment _hostEnv;
        [TempData]
        public string statusMessage { get; set; }
        public ProductController(AppDBContext context, IWebHostEnvironment hostEnv)
        {
            _context = context;
            _hostEnv = hostEnv;
        }
        public IActionResult Index()
        {
            var lstproduct = _context.SanPham.Include(p=>p.ThuongHieu).Include(p=>p.LoaiSanPham).ToList();
            return View(lstproduct);
        }
        public async Task<IActionResult> Upload(IFormFile file){
            var fileDic = "Files";
            string filePath = Path.Combine(_hostEnv.WebRootPath, fileDic);
            if(!Directory.Exists(filePath)){
                Directory.CreateDirectory(filePath);
            }
            var fileName = file.FileName;
            filePath = Path.Combine(filePath, fileName);
            await using FileStream fs = System.IO.File.Create(filePath);
            await file.CopyToAsync(fs);
            return RedirectToAction("Create");
        }
        private string UploadedFile(SanPham product){
            var fileDir = "Images";
            string FileName = null;
            if(product.FileImage != null){
                string filePath = Path.Combine(_hostEnv.WebRootPath, fileDir);
                if(!Directory.Exists(filePath)){
                Directory.CreateDirectory(filePath);
                }
                FileName = product.FileImage.FileName.Replace(" ", "");
                filePath = Path.Combine(filePath, FileName);
                using FileStream fs = System.IO.File.Create(filePath);
                product.FileImage.CopyTo(fs);
            }
            return FileName;
        } 
        [HttpGet]
        public IActionResult Create(){
            ViewBag.LoaiSanPham =new SelectList(_context.LoaiSanPham, "Id", "TenLoaiSP");
            ViewBag.ThuongHieu = new SelectList(_context.ThuongHieu, "Id", "TenThuongHieu");
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Create(SanPham product)
        {
            if (ModelState.IsValid)
            {
                if(product.FileImage != null)
                {
                    string FileName = UploadedFile(product);
                    product.HinhAnh = FileName;
                }
                _context.Add(product);
                await _context.SaveChangesAsync();
                statusMessage = "Vừa tạo sản phẩm mới";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id){
            if(id== null){
                return NotFound();
            }
            var product = await _context.SanPham.FirstOrDefaultAsync(p=>p.Id == id);
            if(product ==null){
                return NotFound();
            }
            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id){
            var product = await _context.SanPham.FindAsync(id);
            if(product == null){
                return NotFound();
            }
            try
            {
                _context.SanPham.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CreatePurchases(){
            ViewBag.SanPham = new SelectList(_context.SanPham, "Id", "Ten"); 
            ViewBag.TaiKhoan = new SelectList(_context.TaiKhoan.Where(p=>p.IdLoaiTK == 3), "Id", "Name"); 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePurchases(Purchases purchasesModel)
        {
            var purchases = purchasesModel.PhieuNhapKho;
            List<ChiTietPNK> purchasesDetail = purchasesModel.ChiTietPNK;
            DateTime date = DateTime.Now;
            purchases.NgayNhap = date;
            if(ModelState.IsValid){
                _context.Add(purchases);
                var createPurchases = await _context.SaveChangesAsync();
                if(createPurchases > 0)
                {
                    for(int i=0;i< purchasesDetail.Count;i++){
                        var purchasesTemp = await _context.PhieuNhapKho.FirstOrDefaultAsync(p=> p.NgayNhap.Equals(date));
                        int IdPurchases = purchasesTemp.Id;
                        purchasesDetail[i].PhieuNhapKhoId = IdPurchases;
                        purchasesDetail[i].TongTienMuc = purchasesDetail[i].SoLuong * purchasesDetail[i].DonGiaNhap;
                        _context.Add(purchasesDetail[i]);
                        await _context.SaveChangesAsync();
                        var product = _context.SanPham.FirstOrDefault(p => p.Id == purchasesDetail[i].SanPhamId);
                        if(product == null){
                            return NotFound();
                        }
                        product.SoLuong += purchasesDetail[i].SoLuong;
                        if(product.DonGiaNhap == 0)
                        {
                            product.DonGiaNhap = purchasesDetail[i].DonGiaNhap;
                        }
                        _context.Update(product);
                        await _context.SaveChangesAsync();
                    }
                }
                return Redirect(nameof(IndexPur));
            }
            return View(purchasesModel);
        }
        public IActionResult IndexPur(){
            return View();
        }
        public IActionResult IndexPurchases(){
            var lstPurchases = _context.PhieuNhapKho.ToList();
            return View(lstPurchases);
        }
        public IActionResult IndexPurchasesDetails(int? id){
            var lstPurchasesDetail = _context.ChiTietPNK.Where(p=>p.PhieuNhapKhoId == id).ToList();
            return View(lstPurchasesDetail);
        }
    }
}
