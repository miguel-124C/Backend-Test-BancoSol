using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bsol.Business.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class transactionEntityDateCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Transaction",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 3, 14, 7, 46, 45, 682, DateTimeKind.Utc).AddTicks(204),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Transaction",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 3, 14, 7, 46, 45, 682, DateTimeKind.Utc).AddTicks(204));
        }
    }
}
