using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bsol.Business.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UniqueContrainsAdds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transaction_VoucherCode",
                table: "Transaction",
                column: "VoucherCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountNumber",
                table: "Account",
                column: "AccountNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transaction_VoucherCode",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Account_AccountNumber",
                table: "Account");
        }
    }
}
