using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyPetals.Repository.Migrations
{
    public partial class tablenamechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_FullfillmentStatuses_FullfillmentStatusId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Payment_Status",
                table: "PaymentStatuses",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "FullfillmentStatusId",
                table: "Order",
                newName: "DeliveryStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_FullfillmentStatusId",
                table: "Order",
                newName: "IX_Order_DeliveryStatusId");

            migrationBuilder.RenameColumn(
                name: "Fullfillment_Status",
                table: "FullfillmentStatuses",
                newName: "Status");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_FullfillmentStatuses_DeliveryStatusId",
                table: "Order",
                column: "DeliveryStatusId",
                principalTable: "FullfillmentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_FullfillmentStatuses_DeliveryStatusId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PaymentStatuses",
                newName: "Payment_Status");

            migrationBuilder.RenameColumn(
                name: "DeliveryStatusId",
                table: "Order",
                newName: "FullfillmentStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DeliveryStatusId",
                table: "Order",
                newName: "IX_Order_FullfillmentStatusId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "FullfillmentStatuses",
                newName: "Fullfillment_Status");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_FullfillmentStatuses_FullfillmentStatusId",
                table: "Order",
                column: "FullfillmentStatusId",
                principalTable: "FullfillmentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
