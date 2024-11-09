using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class addseat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_ticket_row_number_seat_number",
                table: "tbl_ticket");

            migrationBuilder.DropColumn(
                name: "row_number",
                table: "tbl_ticket");

            migrationBuilder.RenameColumn(
                name: "seat_number",
                table: "tbl_ticket",
                newName: "seat_id");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "tbl_movie",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "tbl_movie",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "tbl_seat",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    row_id = table.Column<int>(type: "integer", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_seat", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "tbl_seat",
                columns: new[] { "id", "number", "row_id", "status" },
                values: new object[,]
                {
                    { 1, 1, 1, true },
                    { 2, 1, 1, true },
                    { 3, 2, 1, true },
                    { 4, 3, 1, true },
                    { 5, 1, 2, true },
                    { 6, 2, 2, false },
                    { 7, 3, 2, false }
                });

            migrationBuilder.UpdateData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: 5,
                column: "seat_id",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ticket_seat_id",
                table: "tbl_ticket",
                column: "seat_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_movie_title",
                table: "tbl_movie",
                column: "title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ticket_tbl_seat_seat_id",
                table: "tbl_ticket",
                column: "seat_id",
                principalTable: "tbl_seat",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ticket_tbl_seat_seat_id",
                table: "tbl_ticket");

            migrationBuilder.DropTable(
                name: "tbl_seat");

            migrationBuilder.DropIndex(
                name: "IX_tbl_ticket_seat_id",
                table: "tbl_ticket");

            migrationBuilder.DropIndex(
                name: "IX_tbl_movie_title",
                table: "tbl_movie");

            migrationBuilder.RenameColumn(
                name: "seat_id",
                table: "tbl_ticket",
                newName: "seat_number");

            migrationBuilder.AddColumn<int>(
                name: "row_number",
                table: "tbl_ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "tbl_movie",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "tbl_movie",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.UpdateData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: 1,
                column: "row_number",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: 2,
                column: "row_number",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: 3,
                column: "row_number",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: 4,
                column: "row_number",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "row_number", "seat_number" },
                values: new object[] { 1, 6 });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ticket_row_number_seat_number",
                table: "tbl_ticket",
                columns: new[] { "row_number", "seat_number" },
                unique: true);
        }
    }
}
