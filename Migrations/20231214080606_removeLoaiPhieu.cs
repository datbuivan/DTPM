using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTPMBanQuanAo.Migrations
{
    public partial class removeLoaiPhieu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiPhieu",
                table: "PhieuNhapKho");

            migrationBuilder.AddColumn<double>(
                name: "DonGiaNhap",
                table: "ChiTietPNK",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonGiaNhap",
                table: "ChiTietPNK");

            migrationBuilder.AddColumn<string>(
                name: "LoaiPhieu",
                table: "PhieuNhapKho",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
