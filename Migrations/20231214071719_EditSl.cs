using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTPMBanQuanAo.Migrations
{
    public partial class EditSl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChiTietSanPham_Imei_SanPhamId",
                table: "ChiTietSanPham");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietSanPham_SanPhamId",
                table: "ChiTietSanPham");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "ChiTietSanPham");

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_SanPhamId",
                table: "ChiTietSanPham",
                column: "SanPhamId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChiTietSanPham_SanPhamId",
                table: "ChiTietSanPham");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "SanPham");

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "ChiTietSanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_Imei_SanPhamId",
                table: "ChiTietSanPham",
                columns: new[] { "Imei", "SanPhamId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_SanPhamId",
                table: "ChiTietSanPham",
                column: "SanPhamId");
        }
    }
}
