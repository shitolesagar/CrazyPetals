using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyPetals.Repository.Migrations
{
    public partial class DataSeddingTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Black', '1111', 'CrazyPetals');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Green', '2222', 'CrazyPetals');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`Size` (`ProductSize`, `Unit`, `AppId`) VALUES ('Small', 'XL', 'CrazyPetals');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`Size` (`ProductSize`, `Unit`, `AppId`) VALUES ('Large', 'XXL', 'CrazyPetals');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`OrderDeliveryStatus` (`Status`) VALUES ('Awaiting Processing');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`OrderDeliveryStatus` (`Status`) VALUES ('Processing');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`OrderDeliveryStatus` (`Status`) VALUES ('Shipped');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`OrderDeliveryStatus` (`Status`) VALUES ('Delivered');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`OrderDeliveryStatus` (`Status`) VALUES ('Will Not Deliver');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`OrderDeliveryStatus` (`Status`) VALUES ('Returned');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`OrderPaymentStatus` (`Status`) VALUES ('Awaiting Payment');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`OrderPaymentStatus` (`Status`) VALUES ('Paid');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`OrderPaymentStatus` (`Status`) VALUES ('Cancelled');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`OrderPaymentStatus` (`Status`) VALUES ('Refunded');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
