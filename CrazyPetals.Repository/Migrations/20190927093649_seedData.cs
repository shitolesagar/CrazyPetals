using CrazyPetals.Entities.Constant;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyPetals.Repository.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`AppTheme` (`PrimaryColor`, `SecondryColor`, `StatusBarColor`, `TextColor`, `CurrencySymbols`, `AppName`, `AppLogo`, `AppId`) VALUES ('#FFFFFF', '#005389', '#123456', '#000000', 'r', '" + StringConstants.AppId + "', 'http://114.143.198.154:9001/AppLogo/f4a5e224-0231-45df-8d53-cb34375cf28a.png', 'CrazyPetals');");

            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`DeliveryCharges` (`AppId`, `Min`, `Max`, `Charge`) VALUES ('" + StringConstants.AppId + "', '1', '100', '30');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`DeliveryCharges` (`AppId`, `Min`, `Max`, `Charge`) VALUES ('" + StringConstants.AppId + "', '101', '300', '20');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`DeliveryCharges` (`AppId`, `Min`, `Max`, `Charge`) VALUES ('" + StringConstants.AppId + "', '301', '0', '0');");

            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Role` (`Name`, `AppId`) VALUES ('Admin', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Role` (`Name`, `AppId`) VALUES ('Customer', '" + StringConstants.AppId + "');");

            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`SmtpMail` (`FromMail`, `SmtpPassword`, `Host`, `Port`, `DisplayName`, `Description`, `AppId`) VALUES ('CrazypetalsHelp@gmail.com', 'Mrunalini@1234$', 'smtp.gmail.com', '587', 'gmail', 'This is CrazyPetals', '" + StringConstants.AppId + "');");

            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Black', '#000000', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Brown', '#A52A2A', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Blue', '#0000FF', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Green', '#008000', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Purple', '#800080', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Red', '#FF0000', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Yellow', '#FFFF00', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('White', '#FFFFFF', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Pink', '#FFC0CB', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Orange', '#FFA500', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Colors` (`Name`, `HashCode`, `AppId`) VALUES ('Gray', '#808080', '" + StringConstants.AppId + "');");

            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Size` (`ProductSize`, `Unit`, `AppId`) VALUES ('S', 'S', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Size` (`ProductSize`, `Unit`, `AppId`) VALUES ('M', 'M', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Size` (`ProductSize`, `Unit`, `AppId`) VALUES ('L', 'L', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Size` (`ProductSize`, `Unit`, `AppId`) VALUES ('XL', 'XL', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`Size` (`ProductSize`, `Unit`, `AppId`) VALUES ('XXL', 'XXL', '" + StringConstants.AppId + "');");

            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`OrderDeliveryStatus` (`Status`) VALUES ('Awaiting Processing');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`OrderDeliveryStatus` (`Status`) VALUES ('Processing');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`OrderDeliveryStatus` (`Status`) VALUES ('Shipped');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`OrderDeliveryStatus` (`Status`) VALUES ('Delivered');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`OrderDeliveryStatus` (`Status`) VALUES ('Will Not Deliver');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`OrderDeliveryStatus` (`Status`) VALUES ('Returned');");

            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`OrderPaymentStatus` (`Status`) VALUES ('Awaiting Payment');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`OrderPaymentStatus` (`Status`) VALUES ('Paid');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`OrderPaymentStatus` (`Status`) VALUES ('Cancelled');");
            migrationBuilder.Sql("INSERT INTO `" + EnvironmentConstants.DatabaseName + "`.`OrderPaymentStatus` (`Status`) VALUES ('Refunded');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
