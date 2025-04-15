using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Whitelagon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class datavillanumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villanumbers",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "int", nullable: false),
                    Villa_Id = table.Column<int>(type: "int", nullable: false),
                    PublicDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villanumbers", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_Villanumbers_Villas_Villa_Id",
                        column: x => x.Villa_Id,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villanumbers",
                columns: new[] { "Villa_Number", "PublicDetails", "Villa_Id" },
                values: new object[,]
                {
                    { 101, null, 1 },
                    { 103, null, 1 },
                    { 104, null, 1 },
                    { 105, null, 1 },
                    { 201, null, 2 },
                    { 202, null, 2 },
                    { 203, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Villanumbers_Villa_Id",
                table: "Villanumbers",
                column: "Villa_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Villanumbers");
        }
    }
}
