using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyPetals.Repository.Migrations
{
    public partial class productcolunmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Product",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "Dimension",
                table: "Product",
                newName: "Length");

            migrationBuilder.AlterColumn<string>(
                name: "StockKeepingUnit",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "OriginalPrice",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountedPrice",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Product",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Product",
                newName: "Dimension");

            migrationBuilder.AlterColumn<int>(
                name: "StockKeepingUnit",
                table: "Product",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OriginalPrice",
                table: "Product",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountedPrice",
                table: "Product",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
