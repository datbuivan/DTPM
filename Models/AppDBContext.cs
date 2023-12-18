using Microsoft.EntityFrameworkCore;
using System;

namespace DTPMBanQuanAo.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TaiKhoan>()
                    .HasOne(e => e.LoaiTaiKhoan)
                    .WithMany(e => e.TaiKhoans)
                    .HasForeignKey(e => e.IdLoaiTK)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<LoaiSanPham>()
                    .HasOne(e => e.Parent)
                    .WithMany(e => e.Children)
                    .HasForeignKey(e => e.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SanPham>()
                    .HasOne(e => e.LoaiSanPham)
                    .WithMany(e => e.SanPhams)
                    .HasForeignKey(e => e.LoaiSanPhamId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SanPham>()
                    .HasOne(e => e.ThuongHieu)
                    .WithMany(e => e.SanPhams)
                    .HasForeignKey(e => e.ThuongHieuId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<DanhGia>()
                    .HasOne( e=> e.TaiKhoan)
                    .WithMany(e => e.DanhGias)
                    .HasForeignKey(e => e.KhachHangId) 
                    .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<DanhGia>()
                    .HasOne(e => e.SanPham)
                    .WithMany(e => e.DanhGias)
                    .HasForeignKey(e => e.SanPhamId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<DanhGia>(e =>{
                e.HasIndex(c => new { c.KhachHangId, c.ThoiGian }).IsUnique();
            });
            builder.Entity<DacTrung>()
                    .HasOne(e => e.LoaiDacTrung)
                    .WithMany(e => e.DacTrungs)
                    .HasForeignKey( e=> e.LoaiDacTrungId) 
                    .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<DTrungSanPham>(entity =>
            {
                entity.HasKey(c => new { c.SanPhamId, c.DacTrungId });
            });
            builder.Entity<DTrungSanPham>()
                    .HasOne<SanPham>(e => e.SanPham)
                    .WithMany(e => e.DTrungSanPhams)
                    .HasForeignKey(e => e.SanPhamId);
            builder.Entity<DTrungSanPham>()
                    .HasOne<DacTrung>(e => e.DacTrung)
                    .WithMany(e => e.DTrungSanPhams)
                    .HasForeignKey(e => e.DacTrungId);
            builder.Entity<DonDH>()
                    .HasOne(e => e.TaiKhoan)
                    .WithMany(e => e.DonDHs)
                    .HasForeignKey(e => e.NhanVienId);
            builder.Entity<DonDH>()
                    .HasOne(e => e.TaiKhoan)
                    .WithMany(e => e.DonDHs)
                    .HasForeignKey(e => e.KhachHangId);
            builder.Entity<DonDH>(entity =>
            {
                entity.HasIndex(c => new { c.KhachHangId, c.NgayDat }).IsUnique();
            });
            builder.Entity<ChiTietSanPham>()
                    .HasOne(e => e.SanPham)
                    .WithMany(e => e.ChiTietSanPhams)
                    .HasForeignKey(e => e.SanPhamId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ChiTietSanPham>(entity =>{
                entity.HasIndex(c => new {c.SanPhamId }).IsUnique();
            });
            builder.Entity<ChiTietPNK>()
                    .HasOne(e => e.SanPham)
                    .WithMany(e => e.ChiTietPNKs)
                    .HasForeignKey(e => e.SanPhamId);
            builder.Entity<ChiTietPNK>()
                    .HasOne(e => e.PhieuNhapKho)
                    .WithMany(e => e.ChiTietPNKs)
                    .HasForeignKey(e => e.PhieuNhapKhoId);
            builder.Entity<ChiTietPNK>(entity =>
            {
                entity.HasIndex(c => new { c.SanPhamId, c.PhieuNhapKhoId }).IsUnique();
            });
            builder.Entity<ChiTietDDH>()
                    .HasOne(e => e.DonDH)
                    .WithMany(e => e.ChiTietDDHs)
                    .HasForeignKey(e => e.DDHId);
            builder.Entity<ChiTietDDH>()
                    .HasOne(e => e.SanPham)
                    .WithMany(e => e.ChiTietDDHs)
                    .HasForeignKey(e => e.SanPhamId);
            builder.Entity<ChiTietDDH>(entity =>{
                entity.HasIndex(c => new {c.SanPhamId, c.DDHId}).IsUnique();
            });
            builder.Entity<ChiTietSanPham>()
                    .HasOne(e => e.ChiTietPNK)
                    .WithMany(e => e.ChiTietSanPhams)
                    .HasForeignKey(e => e.ChiTietPNKId);
        }

        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<LoaiTaiKhoan> LoaiTaiKhoan { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<ThuongHieu> ThuongHieu { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<DanhGia> DanhGia { get; set; }
        public DbSet<LoaiDacTrung> LoaiDacTrung { get; set; }
        public DbSet<DacTrung> DacTrung { get; set; }
        public DbSet<DTrungSanPham> DTrungSanPham {get; set; }
        public DbSet<DonDH> DonDH { get; set; }
        public DbSet<ChiTietSanPham> ChiTietSanPham { get; set; }
        public DbSet<PhieuNhapKho> PhieuNhapKho {get; set;}
        public DbSet<ChiTietPNK> ChiTietPNK {get; set;}
    }
}
