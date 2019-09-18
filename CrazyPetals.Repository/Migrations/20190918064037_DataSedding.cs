using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyPetals.Repository.Migrations
{
    public partial class DataSedding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`AppTheme` (`PrimaryColor`, `SecondryColor`, `StatusBarColor`, `TextColor`, `CurrencySymbols`, `AppName`, `AppLogo`, `AppId`) VALUES ('#FFFFFF', '#005389', '#123456', '#000000', 'r', 'CrazyPetals', 'http://114.143.198.154:9001/AppLogo/f4a5e224-0231-45df-8d53-cb34375cf28a.png', 'CrazyPetals');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`delivery_Charges` (`AppId`, `Min`, `Max`, `DeliveryCharge`) VALUES ('CrazyPetals', '1', '100', '30');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`delivery_Charges` (`AppId`, `Min`, `Max`, `DeliveryCharge`) VALUES ('CrazyPetals', '101', '300', '20');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`delivery_Charges` (`AppId`, `Min`, `Max`, `DeliveryCharge`) VALUES ('CrazyPetals', '301', '0', '0');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`Role` (`Name`, `AppId`) VALUES ('Admin', 'CrazyPetals');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`Role` (`Name`, `AppId`) VALUES ('User', 'CrazyPetals');");
            migrationBuilder.Sql("INSERT INTO `CrazyPetalsDB_test`.`SmtpMail` (`FromMail`, `SmtpPassword`, `Host`, `Port`, `DisplayName`, `Description`, `AppId`) VALUES ('CrazypetalsHelp@gmail.com', 'Mrunalini@1234$', 'smtp.gmail.com', '587', 'gmail', 'This is CrazyPetals', 'CrazyPetals');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
