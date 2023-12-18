﻿// <auto-generated />
using System;
using DTPMBanQuanAo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DTPMBanQuanAo.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231211080655_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DTPMBanQuanAo.Models.ChiTietDDH", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DDHId")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DDHId");

                    b.HasIndex("SanPhamId", "DDHId")
                        .IsUnique();

                    b.ToTable("ChiTietDDH");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.ChiTietPNK", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PhieuNhapKhoId")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhieuNhapKhoId");

                    b.HasIndex("SanPhamId", "PhieuNhapKhoId")
                        .IsUnique();

                    b.ToTable("ChiTietPNK");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.ChiTietSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChiTietPNKId")
                        .HasColumnType("int");

                    b.Property<string>("Imei")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChiTietPNKId");

                    b.HasIndex("SanPhamId");

                    b.HasIndex("Imei", "SanPhamId")
                        .IsUnique();

                    b.ToTable("ChiTietSanPham");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.DacTrung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DonVi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GiaTri")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KyHieu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiDacTrungId")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SoThuTu")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LoaiDacTrungId");

                    b.ToTable("DacTrung");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.DanhGia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DanhGiaThu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KhachHangId")
                        .HasColumnType("int");

                    b.Property<string>("LoiBinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGian")
                        .HasColumnType("datetime2");

                    b.Property<int>("XepHang")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SanPhamId");

                    b.HasIndex("KhachHangId", "ThoiGian")
                        .IsUnique();

                    b.ToTable("DanhGia");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.DonDH", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("KhachHangId")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime2");

                    b.Property<int>("NhanVienId")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("KhachHangId", "NgayDat")
                        .IsUnique();

                    b.ToTable("DonDH");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.DTrungSanPham", b =>
                {
                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("DacTrungId")
                        .HasColumnType("int");

                    b.HasKey("SanPhamId", "DacTrungId");

                    b.HasIndex("DacTrungId");

                    b.ToTable("DTrungSanPham");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.LoaiDacTrung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TenLoaiDacTrung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiDacTrung");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.LoaiSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("TenLoaiSP")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("LoaiSanPham");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.LoaiTaiKhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TenLoaiTk")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("LoaiTaiKhoan");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.PhieuNhapKho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LoaiPhieu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<int>("NhanVienId")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PhieuNhapKho");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("DonGiaBan")
                        .HasColumnType("float");

                    b.Property<double>("DonGiaNhap")
                        .HasColumnType("float");

                    b.Property<string>("HinhAnh")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("LoaiSanPhamId")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ThuongHieuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoaiSanPhamId");

                    b.HasIndex("ThuongHieuId");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.TaiKhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdLoaiTK")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("IdLoaiTK");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.ThuongHieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("HinhAnh")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Mota")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TenThuongHieu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ThuongHieu");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.ChiTietDDH", b =>
                {
                    b.HasOne("DTPMBanQuanAo.Models.DonDH", "DonDH")
                        .WithMany("ChiTietDDHs")
                        .HasForeignKey("DDHId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTPMBanQuanAo.Models.SanPham", "SanPham")
                        .WithMany("ChiTietDDHs")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonDH");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.ChiTietPNK", b =>
                {
                    b.HasOne("DTPMBanQuanAo.Models.PhieuNhapKho", "PhieuNhapKho")
                        .WithMany("ChiTietPNKs")
                        .HasForeignKey("PhieuNhapKhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTPMBanQuanAo.Models.SanPham", "SanPham")
                        .WithMany("ChiTietPNKs")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhieuNhapKho");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.ChiTietSanPham", b =>
                {
                    b.HasOne("DTPMBanQuanAo.Models.ChiTietPNK", "ChiTietPNK")
                        .WithMany("ChiTietSanPhams")
                        .HasForeignKey("ChiTietPNKId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTPMBanQuanAo.Models.SanPham", "SanPham")
                        .WithMany("ChiTietSanPhams")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChiTietPNK");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.DacTrung", b =>
                {
                    b.HasOne("DTPMBanQuanAo.Models.LoaiDacTrung", "LoaiDacTrung")
                        .WithMany("DacTrungs")
                        .HasForeignKey("LoaiDacTrungId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LoaiDacTrung");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.DanhGia", b =>
                {
                    b.HasOne("DTPMBanQuanAo.Models.TaiKhoan", "TaiKhoan")
                        .WithMany("DanhGias")
                        .HasForeignKey("KhachHangId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DTPMBanQuanAo.Models.SanPham", "SanPham")
                        .WithMany("DanhGias")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SanPham");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.DonDH", b =>
                {
                    b.HasOne("DTPMBanQuanAo.Models.TaiKhoan", "TaiKhoan")
                        .WithMany("DonDHs")
                        .HasForeignKey("KhachHangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.DTrungSanPham", b =>
                {
                    b.HasOne("DTPMBanQuanAo.Models.DacTrung", "DacTrung")
                        .WithMany("DTrungSanPhams")
                        .HasForeignKey("DacTrungId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTPMBanQuanAo.Models.SanPham", "SanPham")
                        .WithMany("DTrungSanPhams")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DacTrung");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.LoaiSanPham", b =>
                {
                    b.HasOne("DTPMBanQuanAo.Models.LoaiSanPham", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.SanPham", b =>
                {
                    b.HasOne("DTPMBanQuanAo.Models.LoaiSanPham", "LoaiSanPham")
                        .WithMany("SanPhams")
                        .HasForeignKey("LoaiSanPhamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DTPMBanQuanAo.Models.ThuongHieu", "ThuongHieu")
                        .WithMany("SanPhams")
                        .HasForeignKey("ThuongHieuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LoaiSanPham");

                    b.Navigation("ThuongHieu");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.TaiKhoan", b =>
                {
                    b.HasOne("DTPMBanQuanAo.Models.LoaiTaiKhoan", "LoaiTaiKhoan")
                        .WithMany("TaiKhoans")
                        .HasForeignKey("IdLoaiTK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LoaiTaiKhoan");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.ChiTietPNK", b =>
                {
                    b.Navigation("ChiTietSanPhams");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.DacTrung", b =>
                {
                    b.Navigation("DTrungSanPhams");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.DonDH", b =>
                {
                    b.Navigation("ChiTietDDHs");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.LoaiDacTrung", b =>
                {
                    b.Navigation("DacTrungs");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.LoaiSanPham", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.LoaiTaiKhoan", b =>
                {
                    b.Navigation("TaiKhoans");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.PhieuNhapKho", b =>
                {
                    b.Navigation("ChiTietPNKs");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.SanPham", b =>
                {
                    b.Navigation("ChiTietDDHs");

                    b.Navigation("ChiTietPNKs");

                    b.Navigation("ChiTietSanPhams");

                    b.Navigation("DTrungSanPhams");

                    b.Navigation("DanhGias");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.TaiKhoan", b =>
                {
                    b.Navigation("DanhGias");

                    b.Navigation("DonDHs");
                });

            modelBuilder.Entity("DTPMBanQuanAo.Models.ThuongHieu", b =>
                {
                    b.Navigation("SanPhams");
                });
#pragma warning restore 612, 618
        }
    }
}
