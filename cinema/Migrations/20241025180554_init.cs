using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_session",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    hall_id = table.Column<int>(type: "integer", nullable: false),
                    movie_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_session", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chat_id = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ticket",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    row_number = table.Column<int>(type: "integer", nullable: false),
                    seat_number = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    session_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ticket", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_ticket_tbl_session_session_id",
                        column: x => x.session_id,
                        principalTable: "tbl_session",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_ticket_tbl_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbl_session",
                columns: new[] { "id", "end_time", "hall_id", "movie_id", "price", "start_time" },
                values: new object[] { 1, new DateTime(2024, 10, 28, 20, 15, 0, 0, DateTimeKind.Utc), 1, 1, 250m, new DateTime(2024, 10, 28, 18, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "tbl_user",
                columns: new[] { "id", "chat_id", "phone_number" },
                values: new object[,]
                {
                    { 1, "89123453423", "89962963698" },
                    { 2, "891245653423", "89967351259" }
                });

            migrationBuilder.InsertData(
                table: "tbl_ticket",
                columns: new[] { "id", "row_number", "seat_number", "session_id", "user_id" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 1, 2, 1, 1 },
                    { 3, 1, 3, 1, 2 },
                    { 4, 1, 4, 1, 2 },
                    { 5, 1, 6, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ticket_row_number_seat_number",
                table: "tbl_ticket",
                columns: new[] { "row_number", "seat_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ticket_session_id",
                table: "tbl_ticket",
                column: "session_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ticket_user_id",
                table: "tbl_ticket",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_chat_id",
                table: "tbl_user",
                column: "chat_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_ticket");

            migrationBuilder.DropTable(
                name: "tbl_session");

            migrationBuilder.DropTable(
                name: "tbl_user");
        }
    }
}
