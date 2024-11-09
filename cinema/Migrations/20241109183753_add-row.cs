using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class addrow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_hall",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_hall", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_row",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    hall_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_row", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_row_tbl_hall_hall_id",
                        column: x => x.hall_id,
                        principalTable: "tbl_hall",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbl_hall",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Малый зал" },
                    { 2, "Большой зал" }
                });

            migrationBuilder.InsertData(
                table: "tbl_row",
                columns: new[] { "id", "hall_id", "number" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_session_hall_id",
                table: "tbl_session",
                column: "hall_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_session_movie_id",
                table: "tbl_session",
                column: "movie_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_seat_row_id",
                table: "tbl_seat",
                column: "row_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hall_name",
                table: "tbl_hall",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_row_hall_id",
                table: "tbl_row",
                column: "hall_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_seat_tbl_row_row_id",
                table: "tbl_seat",
                column: "row_id",
                principalTable: "tbl_row",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_session_tbl_hall_hall_id",
                table: "tbl_session",
                column: "hall_id",
                principalTable: "tbl_hall",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_session_tbl_movie_movie_id",
                table: "tbl_session",
                column: "movie_id",
                principalTable: "tbl_movie",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_seat_tbl_row_row_id",
                table: "tbl_seat");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_session_tbl_hall_hall_id",
                table: "tbl_session");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_session_tbl_movie_movie_id",
                table: "tbl_session");

            migrationBuilder.DropTable(
                name: "tbl_row");

            migrationBuilder.DropTable(
                name: "tbl_hall");

            migrationBuilder.DropIndex(
                name: "IX_tbl_session_hall_id",
                table: "tbl_session");

            migrationBuilder.DropIndex(
                name: "IX_tbl_session_movie_id",
                table: "tbl_session");

            migrationBuilder.DropIndex(
                name: "IX_tbl_seat_row_id",
                table: "tbl_seat");
        }
    }
}
