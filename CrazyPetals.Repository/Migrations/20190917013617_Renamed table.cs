using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyPetals.Repository.Migrations
{
    public partial class Renamedtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_FullfillmentStatuses_DeliveryStatusId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_PaymentStatuses_PaymentStatusId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentStatuses",
                table: "PaymentStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FullfillmentStatuses",
                table: "FullfillmentStatuses");

            migrationBuilder.RenameTable(
                name: "PaymentStatuses",
                newName: "OrderPaymentStatus");

            migrationBuilder.RenameTable(
                name: "FullfillmentStatuses",
                newName: "OrderDeliveryStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPaymentStatus",
                table: "OrderPaymentStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDeliveryStatus",
                table: "OrderDeliveryStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderDeliveryStatus_DeliveryStatusId",
                table: "Order",
                column: "DeliveryStatusId",
                principalTable: "OrderDeliveryStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderPaymentStatus_PaymentStatusId",
                table: "Order",
                column: "PaymentStatusId",
                principalTable: "OrderPaymentStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderDeliveryStatus_DeliveryStatusId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderPaymentStatus_PaymentStatusId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPaymentStatus",
                table: "OrderPaymentStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDeliveryStatus",
                table: "OrderDeliveryStatus");

            migrationBuilder.RenameTable(
                name: "OrderPaymentStatus",
                newName: "PaymentStatuses");

            migrationBuilder.RenameTable(
                name: "OrderDeliveryStatus",
                newName: "FullfillmentStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentStatuses",
                table: "PaymentStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FullfillmentStatuses",
                table: "FullfillmentStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_FullfillmentStatuses_DeliveryStatusId",
                table: "Order",
                column: "DeliveryStatusId",
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
    }
}
