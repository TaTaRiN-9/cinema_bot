using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "tbl_hall",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_hall", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_movie",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    duration = table.Column<int>(type: "integer", nullable: false),
                    photo_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_movie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    chat_id = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_row",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    hall_id = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "tbl_session",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    hall_id = table.Column<Guid>(type: "uuid", nullable: false),
                    movie_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_session", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_session_tbl_hall_hall_id",
                        column: x => x.hall_id,
                        principalTable: "tbl_hall",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_session_tbl_movie_movie_id",
                        column: x => x.movie_id,
                        principalTable: "tbl_movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_seat",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    row_id = table.Column<Guid>(type: "uuid", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_seat", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_seat_tbl_row_row_id",
                        column: x => x.row_id,
                        principalTable: "tbl_row",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ticket",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    seat_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    session_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ticket", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_ticket_tbl_seat_seat_id",
                        column: x => x.seat_id,
                        principalTable: "tbl_seat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "tbl_hall",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("5199fcb4-f999-4916-a095-f623692c948c"), "Малый зал" },
                    { new Guid("87f0763f-f20f-47f4-a0f0-fbe50f6f452d"), "Большой зал" }
                });

            migrationBuilder.InsertData(
                table: "tbl_movie",
                columns: new[] { "id", "description", "duration", "photo_url", "title" },
                values: new object[,]
                {
                    { new Guid("11b607ee-7f27-4714-bf1e-39e3904e6cdb"), "Тут некоторое описание для фильма 2", 98, null, "Фильм 2" },
                    { new Guid("90725026-a9a9-4a70-9d77-88521956e2af"), "Тут некоторое описание для фильма 1", 104, null, "Фильм 1" }
                });

            migrationBuilder.InsertData(
                table: "tbl_user",
                columns: new[] { "id", "chat_id", "phone_number" },
                values: new object[,]
                {
                    { new Guid("3e703db7-ae2d-4aad-babf-2e37339950d4"), "89123453423", "89962963698" },
                    { new Guid("8080451e-69a7-4929-a804-10b38ff050c7"), "891245653423", "89967351259" }
                });

            migrationBuilder.InsertData(
                table: "tbl_row",
                columns: new[] { "id", "hall_id", "number" },
                values: new object[,]
                {
                    { new Guid("d11132cc-89b1-4245-b9e7-fbb1ac1715a1"), new Guid("5199fcb4-f999-4916-a095-f623692c948c"), 1 },
                    { new Guid("f98a4a5f-b415-4f49-bb91-1ede3c73274b"), new Guid("5199fcb4-f999-4916-a095-f623692c948c"), 2 }
                });

            migrationBuilder.InsertData(
                table: "tbl_session",
                columns: new[] { "id", "end_time", "hall_id", "movie_id", "price", "start_time" },
                values: new object[] { new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"), new DateTime(2024, 10, 28, 20, 15, 0, 0, DateTimeKind.Utc), new Guid("5199fcb4-f999-4916-a095-f623692c948c"), new Guid("90725026-a9a9-4a70-9d77-88521956e2af"), 250m, new DateTime(2024, 10, 28, 18, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "tbl_seat",
                columns: new[] { "id", "number", "row_id", "status" },
                values: new object[,]
                {
                    { new Guid("1c53a0bd-9bcf-4db3-bc5f-3f64373a9245"), 2, new Guid("d11132cc-89b1-4245-b9e7-fbb1ac1715a1"), true },
                    { new Guid("65d8d5d2-69f2-4853-a094-847cbd4a2ba3"), 2, new Guid("f98a4a5f-b415-4f49-bb91-1ede3c73274b"), false },
                    { new Guid("7e62a9a4-8b95-4009-b94c-35ad3e0d0052"), 1, new Guid("f98a4a5f-b415-4f49-bb91-1ede3c73274b"), true },
                    { new Guid("91e7247d-f736-4545-92a5-dd8a2c864ed0"), 1, new Guid("d11132cc-89b1-4245-b9e7-fbb1ac1715a1"), true },
                    { new Guid("b1de6b6c-5563-465b-9a13-037053e7ba6b"), 3, new Guid("f98a4a5f-b415-4f49-bb91-1ede3c73274b"), false },
                    { new Guid("e32eebcb-dde8-45f7-9445-9734943d28df"), 3, new Guid("d11132cc-89b1-4245-b9e7-fbb1ac1715a1"), true },
                    { new Guid("faef26b5-c373-4a53-96a9-5973ef34c1ff"), 1, new Guid("d11132cc-89b1-4245-b9e7-fbb1ac1715a1"), true }
                });

            migrationBuilder.InsertData(
                table: "tbl_ticket",
                columns: new[] { "id", "seat_id", "session_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("06c0e549-c9d2-4c60-84a0-01e1200beef1"), new Guid("e32eebcb-dde8-45f7-9445-9734943d28df"), new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"), new Guid("8080451e-69a7-4929-a804-10b38ff050c7") },
                    { new Guid("12fa832d-ecea-432b-9a3a-87fb5dd73b01"), new Guid("1c53a0bd-9bcf-4db3-bc5f-3f64373a9245"), new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"), new Guid("8080451e-69a7-4929-a804-10b38ff050c7") },
                    { new Guid("247bf6f9-5da8-4a0c-acad-51397c74607e"), new Guid("91e7247d-f736-4545-92a5-dd8a2c864ed0"), new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"), new Guid("3e703db7-ae2d-4aad-babf-2e37339950d4") },
                    { new Guid("8b037017-bf6b-44e4-8e3f-92f411071d51"), new Guid("faef26b5-c373-4a53-96a9-5973ef34c1ff"), new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"), new Guid("3e703db7-ae2d-4aad-babf-2e37339950d4") },
                    { new Guid("f6688833-dc70-422e-aedc-cd9d9aad5563"), new Guid("7e62a9a4-8b95-4009-b94c-35ad3e0d0052"), new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"), new Guid("8080451e-69a7-4929-a804-10b38ff050c7") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hall_name",
                table: "tbl_hall",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_movie_title",
                table: "tbl_movie",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_row_hall_id",
                table: "tbl_row",
                column: "hall_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_seat_row_id",
                table: "tbl_seat",
                column: "row_id");

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
                name: "IX_tbl_ticket_seat_id",
                table: "tbl_ticket",
                column: "seat_id",
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
                name: "tbl_seat");

            migrationBuilder.DropTable(
                name: "tbl_session");

            migrationBuilder.DropTable(
                name: "tbl_user");

            migrationBuilder.DropTable(
                name: "tbl_row");

            migrationBuilder.DropTable(
                name: "tbl_movie");

            migrationBuilder.DropTable(
                name: "tbl_hall");
        }
    }
}
