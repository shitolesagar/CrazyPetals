using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyPetals.Repository.Migrations
{
    public partial class PaymentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FullfillmentStatusId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatusId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FullfillmentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fullfillment_Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullfillmentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Payment_Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_FullfillmentStatusId",
                table: "Order",
                column: "FullfillmentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentStatusId",
                table: "Order",
                column: "PaymentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_FullfillmentStatuses_FullfillmentStatusId",
                table: "Order",
                column: "FullfillmentStatusId",
                principalTable: "FullfillmentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PaymentStatuses_PaymentStatusId",
                table: "Order",
                column: "PaymentStatusId",
                principalTable: "PaymentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_FullfillmentStatuses_FullfillmentStatusId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_PaymentStatuses_PaymentStatusId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "FullfillmentStatuses");

            migrationBuilder.DropTable(
                name: "PaymentStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Order_FullfillmentStatusId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentStatusId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "FullfillmentStatusId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentStatusId",
                table: "Order");
        }
    }
}
