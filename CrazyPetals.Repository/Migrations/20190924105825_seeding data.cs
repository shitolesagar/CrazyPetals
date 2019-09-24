using CrazyPetals.Entities.Constant;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyPetals.Repository.Migrations
{
    public partial class seedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`AppTheme` (`PrimaryColor`, `SecondryColor`, `StatusBarColor`, `TextColor`, `CurrencySymbols`, `AppName`, `AppLogo`, `AppId`) VALUES ('#FFFFFF', '#005389', '#123456', '#000000', 'r', '" + StringConstants.AppId+"', 'http://114.143.198.154:9001/AppLogo/f4a5e224-0231-45df-8d53-cb34375cf28a.png', 'CrazyPetals');");

            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`delivery_Charges` (`AppId`, `Min`, `Max`, `DeliveryCharge`) VALUES ('" + StringConstants.AppId + "', '1', '100', '30');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`delivery_Charges` (`AppId`, `Min`, `Max`, `DeliveryCharge`) VALUES ('" + StringConstants.AppId + "', '101', '300', '20');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`delivery_Charges` (`AppId`, `Min`, `Max`, `DeliveryCharge`) VALUES ('" + StringConstants.AppId + "', '301', '0', '0');");

            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`Role` (`Name`, `AppId`) VALUES ('Admin', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`Role` (`Name`, `AppId`) VALUES ('Customer', '" + StringConstants.AppId + "');");

            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`SmtpMail` (`FromMail`, `SmtpPassword`, `Host`, `Port`, `DisplayName`, `Description`, `AppId`) VALUES ('CrazypetalsHelp@gmail.com', 'Mrunalini@1234$', 'smtp.gmail.com', '587', 'gmail', 'This is CrazyPetals', '" + StringConstants.AppId + "');");
            
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Black', '1111', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Green', '2222', '" + StringConstants.AppId + "');");

            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`Size` (`ProductSize`, `Unit`, `AppId`) VALUES ('Small', 'XL', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`Size` (`ProductSize`, `Unit`, `AppId`) VALUES ('Large', 'XXL', '" + StringConstants.AppId + "');");

            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`OrderDeliveryStatus` (`Status`) VALUES ('Awaiting Processing');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`OrderDeliveryStatus` (`Status`) VALUES ('Processing');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`OrderDeliveryStatus` (`Status`) VALUES ('Shipped');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`OrderDeliveryStatus` (`Status`) VALUES ('Delivered');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`OrderDeliveryStatus` (`Status`) VALUES ('Will Not Deliver');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`OrderDeliveryStatus` (`Status`) VALUES ('Returned');");

            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`OrderPaymentStatus` (`Status`) VALUES ('Awaiting Payment');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`OrderPaymentStatus` (`Status`) VALUES ('Paid');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`OrderPaymentStatus` (`Status`) VALUES ('Cancelled');");
            migrationBuilder.Sql("INSERT INTO `" + StringConstants.DatabaseName + "`.`OrderPaymentStatus` (`Status`) VALUES ('Refunded');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
