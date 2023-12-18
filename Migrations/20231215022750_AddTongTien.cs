using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTPMBanQuanAo.Migrations
{
    public partial class AddTongTien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "PhieuNhapKho",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TongTien",
                table: "PhieuNhapKho",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TongTien",
                table: "DonDH",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "TrangThaiThanhToan",
                table: "DonDH",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TongTienMuc",
                table: "ChiTietPNK",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TongTien",
                table: "PhieuNhapKho");

            migrationBuilder.DropColumn(
                name: "TongTien",
                table: "DonDH");

            migrationBuilder.DropColumn(
                name: "TrangThaiThanhToan",
                table: "DonDH");

            migrationBuilder.DropColumn(
                name: "TongTienMuc",
                table: "ChiTietPNK");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "PhieuNhapKho",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
