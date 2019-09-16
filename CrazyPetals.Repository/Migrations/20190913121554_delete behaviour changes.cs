using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyPetals.Repository.Migrations
{
    public partial class deletebehaviourchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Filter_FilterId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "FilterId",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Filter_FilterId",
                table: "Product",
                column: "FilterId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Filter_FilterId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "FilterId",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Filter_FilterId",
                table: "Product",
                column: "FilterId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
