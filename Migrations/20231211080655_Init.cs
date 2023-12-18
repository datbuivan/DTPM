using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTPMBanQuanAo.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiDacTrung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiDacTrung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDacTrung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiSP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiSanPham_LoaiSanPham_ParentId",
                        column: x => x.ParentId,
                        principalTable: "LoaiSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoaiTaiKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiTk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiTaiKhoan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhapKho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    LoaiPhieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhapKho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThuongHieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DacTrung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiDacTrungId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    SoThuTu = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KyHieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaTri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DacTrung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DacTrung_LoaiDacTrung_LoaiDacTrungId",
                        column: x => x.LoaiDacTrungId,
                        principalTable: "LoaiDacTrung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdLoaiTK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_LoaiTaiKhoan_IdLoaiTK",
                        column: x => x.IdLoaiTK,
                        principalTable: "LoaiTaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DonGiaNhap = table.Column<double>(type: "float", nullable: false),
                    DonGiaBan = table.Column<double>(type: "float", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LoaiSanPhamId = table.Column<int>(type: "int", nullable: false),
                    ThuongHieuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiSanPham_LoaiSanPhamId",
                        column: x => x.LoaiSanPhamId,
                        principalTable: "LoaiSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPham_ThuongHieu_ThuongHieuId",
                        column: x => x.ThuongHieuId,
                        principalTable: "ThuongHieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonDH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KhachHangId = table.Column<int>(type: "int", nullable: false),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonDH", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonDH_TaiKhoan_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPNK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    PhieuNhapKhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPNK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietPNK_PhieuNhapKho_PhieuNhapKhoId",
                        column: x => x.PhieuNhapKhoId,
                        principalTable: "PhieuNhapKho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPNK_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhGia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachHangId = table.Column<int>(type: "int", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    XepHang = table.Column<int>(type: "int", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoiBinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhGiaThu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhGia_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DanhGia_TaiKhoan_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DTrungSanPham",
                columns: table => new
                {
                    DacTrungId = table.Column<int>(type: "int", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTrungSanPham", x => new { x.SanPhamId, x.DacTrungId });
                    table.ForeignKey(
                        name: "FK_DTrungSanPham_DacTrung_DacTrungId",
                        column: x => x.DacTrungId,
                        principalTable: "DacTrung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DTrungSanPham_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDDH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DDHId = table.Column<int>(type: "int", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDDH", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietDDH_DonDH_DDHId",
                        column: x => x.DDHId,
                        principalTable: "DonDH",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDDH_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imei = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ChiTietPNKId = table.Column<int>(type: "int", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_ChiTietPNK_ChiTietPNKId",
                        column: x => x.ChiTietPNKId,
                        principalTable: "ChiTietPNK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDDH_DDHId",
                table: "ChiTietDDH",
                column: "DDHId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDDH_SanPhamId_DDHId",
                table: "ChiTietDDH",
                columns: new[] { "SanPhamId", "DDHId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPNK_PhieuNhapKhoId",
                table: "ChiTietPNK",
                column: "PhieuNhapKhoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPNK_SanPhamId_PhieuNhapKhoId",
                table: "ChiTietPNK",
                columns: new[] { "SanPhamId", "PhieuNhapKhoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_ChiTietPNKId",
                table: "ChiTietSanPham",
                column: "ChiTietPNKId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_Imei_SanPhamId",
                table: "ChiTietSanPham",
                columns: new[] { "Imei", "SanPhamId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_SanPhamId",
                table: "ChiTietSanPham",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_DacTrung_LoaiDacTrungId",
                table: "DacTrung",
                column: "LoaiDacTrungId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_KhachHangId_ThoiGian",
                table: "DanhGia",
                columns: new[] { "KhachHangId", "ThoiGian" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_SanPhamId",
                table: "DanhGia",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_DonDH_KhachHangId_NgayDat",
                table: "DonDH",
                columns: new[] { "KhachHangId", "NgayDat" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DTrungSanPham_DacTrungId",
                table: "DTrungSanPham",
                column: "DacTrungId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPham_ParentId",
                table: "LoaiSanPham",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_LoaiSanPhamId",
                table: "SanPham",
                column: "LoaiSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_ThuongHieuId",
                table: "SanPham",
                column: "ThuongHieuId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_IdLoaiTK",
                table: "TaiKhoan",
                column: "IdLoaiTK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDDH");

            migrationBuilder.DropTable(
                name: "ChiTietSanPham");

            migrationBuilder.DropTable(
                name: "DanhGia");

            migrationBuilder.DropTable(
                name: "DTrungSanPham");

            migrationBuilder.DropTable(
                name: "DonDH");

            migrationBuilder.DropTable(
                name: "ChiTietPNK");

            migrationBuilder.DropTable(
                name: "DacTrung");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "PhieuNhapKho");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "LoaiDacTrung");

            migrationBuilder.DropTable(
                name: "LoaiTaiKhoan");

            migrationBuilder.DropTable(
                name: "LoaiSanPham");

            migrationBuilder.DropTable(
                name: "ThuongHieu");
        }
    }
}
