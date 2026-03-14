using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bsol.Business.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class transactionEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Transaction",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 3, 14, 3, 38, 16, 606, DateTimeKind.Utc).AddTicks(4462));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Transaction",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 3, 14, 3, 38, 16, 606, DateTimeKind.Utc).AddTicks(4462),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
