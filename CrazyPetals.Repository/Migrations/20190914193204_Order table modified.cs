using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyPetals.Repository.Migrations
{
    public partial class Ordertablemodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderSummary_OrderSummaryId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderSummary");

            migrationBuilder.DropColumn(
                name: "AppId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderSummaryId",
                table: "OrderDetails",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderSummaryId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SubTotalPrice = table.Column<decimal>(nullable: false),
                    DiscountPrice = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    GSTPrice = table.Column<decimal>(nullable: false),
                    DeliveryCharges = table.Column<decimal>(nullable: false),
                    OrderNumber = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    UserAddressId = table.Column<int>(nullable: false),
                    MRP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_UserAddress_UserAddressId",
                        column: x => x.UserAddressId,
                        principalTable: "UserAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ApplicationUserId",
                table: "Order",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserAddressId",
                table: "Order",
                column: "UserAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderDetails",
                newName: "OrderSummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderSummaryId");

            migrationBuilder.AddColumn<string>(
                name: "AppId",
                table: "OrderDetails",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderSummary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<string>(maxLength: 30, nullable: true),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeliveryCharges = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    GST = table.Column<int>(nullable: false),
                    MRP = table.Column<int>(nullable: false),
                    SubTotal = table.Column<int>(nullable: false),
                    UserAddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderSummary_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSummary_UserAddress_UserAddressId",
                        column: x => x.UserAddressId,
                        principalTable: "UserAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderSummary_ApplicationUserId",
                table: "OrderSummary",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSummary_UserAddressId",
                table: "OrderSummary",
                column: "UserAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderSummary_OrderSummaryId",
                table: "OrderDetails",
                column: "OrderSummaryId",
                principalTable: "OrderSummary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
