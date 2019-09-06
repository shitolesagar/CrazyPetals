using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyPetals.Repository.Migrations
{
    public partial class ForgotPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "ForgotPassword",
                newName: "ExpireDate");

            migrationBuilder.AlterColumn<string>(
                name: "OTP",
                table: "ForgotPassword",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "ForgotPassword",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ForgotPassword_ApplicationUserId",
                table: "ForgotPassword",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForgotPassword_ApplicationUser_ApplicationUserId",
                table: "ForgotPassword",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForgotPassword_ApplicationUser_ApplicationUserId",
                table: "ForgotPassword");

            migrationBuilder.DropIndex(
                name: "IX_ForgotPassword_ApplicationUserId",
                table: "ForgotPassword");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ForgotPassword");

            migrationBuilder.RenameColumn(
                name: "ExpireDate",
                table: "ForgotPassword",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<int>(
                name: "OTP",
                table: "ForgotPassword",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
