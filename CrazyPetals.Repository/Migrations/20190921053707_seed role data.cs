using CrazyPetals.Entities.Constant;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyPetals.Repository.Migrations
{
    public partial class seedroledata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `crazypetalsdb_test`.`role` (`Name`, `AppId`) VALUES ('Admin', '" + StringConstants.AppId + "');");
            migrationBuilder.Sql("INSERT INTO `crazypetalsdb_test`.`role` (`Name`, `AppId`) VALUES ('Customer', '" + StringConstants.AppId + "');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
