using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Refactor.PaymentGate.Api.Datas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentOrganization",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SchoolCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    SchoolLevelCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime2(2)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DateTime2(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOrganization", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentOrganization");
        }
    }
}
