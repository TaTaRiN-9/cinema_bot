using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class userreplacestringtolong : Migration
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
                    chat_id = table.Column<long>(type: "bigint", nullable: false),
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
                    { new Guid("0b19381e-7fb3-4184-99ad-889eb18d280e"), "Малый зал" },
                    { new Guid("78be86b9-49eb-4eea-8bfa-11fdcc4786c0"), "Большой зал" }
                });

            migrationBuilder.InsertData(
                table: "tbl_movie",
                columns: new[] { "id", "description", "duration", "photo_url", "title" },
                values: new object[,]
                {
                    { new Guid("496a1060-f32f-4c94-bf6f-60258b1b8e14"), "Тут некоторое описание для фильма 2", 98, null, "Фильм 2" },
                    { new Guid("b91f69c2-1547-4736-b84b-d4a73d6e8664"), "Тут некоторое описание для фильма 1", 104, null, "Фильм 1" }
                });

            migrationBuilder.InsertData(
                table: "tbl_user",
                columns: new[] { "id", "chat_id", "phone_number" },
                values: new object[,]
                {
                    { new Guid("9e82caac-a642-4184-ae2f-19d592b7c667"), 8912456L, "89967351259" },
                    { new Guid("cffeaec1-b144-41d4-b573-5f623272d2c0"), 8912345L, "89962963698" }
                });

            migrationBuilder.InsertData(
                table: "tbl_row",
                columns: new[] { "id", "hall_id", "number" },
                values: new object[,]
                {
                    { new Guid("59ff6c4f-bd1f-44dd-bf5c-c943f4bcc6fb"), new Guid("0b19381e-7fb3-4184-99ad-889eb18d280e"), 1 },
                    { new Guid("9e5d95d9-ea83-47c0-9b2b-7e76f1ca9a56"), new Guid("0b19381e-7fb3-4184-99ad-889eb18d280e"), 2 }
                });

            migrationBuilder.InsertData(
                table: "tbl_session",
                columns: new[] { "id", "end_time", "hall_id", "movie_id", "price", "start_time" },
                values: new object[] { new Guid("0b8487fc-e894-4db1-8473-43e9b8dca2de"), new DateTime(2024, 10, 28, 20, 15, 0, 0, DateTimeKind.Utc), new Guid("0b19381e-7fb3-4184-99ad-889eb18d280e"), new Guid("b91f69c2-1547-4736-b84b-d4a73d6e8664"), 250m, new DateTime(2024, 10, 28, 18, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "tbl_seat",
                columns: new[] { "id", "number", "row_id", "status" },
                values: new object[,]
                {
                    { new Guid("04307b99-eb3e-4eda-89cf-ac437f19bc16"), 2, new Guid("9e5d95d9-ea83-47c0-9b2b-7e76f1ca9a56"), false },
                    { new Guid("38b89d78-01d7-4cb8-9b1b-549c4740cc29"), 3, new Guid("9e5d95d9-ea83-47c0-9b2b-7e76f1ca9a56"), false },
                    { new Guid("674dad84-83ea-4210-a543-71df30f0154c"), 4, new Guid("59ff6c4f-bd1f-44dd-bf5c-c943f4bcc6fb"), true },
                    { new Guid("7b3497c5-49f5-46c1-9618-2e3455af6b58"), 1, new Guid("9e5d95d9-ea83-47c0-9b2b-7e76f1ca9a56"), true },
                    { new Guid("bb74c7cc-606b-4ade-bff3-d893b7d40a16"), 3, new Guid("59ff6c4f-bd1f-44dd-bf5c-c943f4bcc6fb"), true },
                    { new Guid("d34df66b-f33e-4d99-aae5-7ab8ac7fdb71"), 2, new Guid("59ff6c4f-bd1f-44dd-bf5c-c943f4bcc6fb"), true },
                    { new Guid("fa23004c-4427-4ee4-9e31-5f6bf08f14f9"), 1, new Guid("59ff6c4f-bd1f-44dd-bf5c-c943f4bcc6fb"), true }
                });

            migrationBuilder.InsertData(
                table: "tbl_ticket",
                columns: new[] { "id", "seat_id", "session_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("7c9e5e59-e447-4bf0-82d5-81b96efed85d"), new Guid("fa23004c-4427-4ee4-9e31-5f6bf08f14f9"), new Guid("0b8487fc-e894-4db1-8473-43e9b8dca2de"), new Guid("cffeaec1-b144-41d4-b573-5f623272d2c0") },
                    { new Guid("82babe00-0f46-4e08-9930-e2d3479e38d8"), new Guid("7b3497c5-49f5-46c1-9618-2e3455af6b58"), new Guid("0b8487fc-e894-4db1-8473-43e9b8dca2de"), new Guid("9e82caac-a642-4184-ae2f-19d592b7c667") },
                    { new Guid("c26c0ae8-8131-42e4-91be-92ea52f51708"), new Guid("bb74c7cc-606b-4ade-bff3-d893b7d40a16"), new Guid("0b8487fc-e894-4db1-8473-43e9b8dca2de"), new Guid("9e82caac-a642-4184-ae2f-19d592b7c667") },
                    { new Guid("e78cdfa3-7d0c-4dc0-8e05-94c187251293"), new Guid("674dad84-83ea-4210-a543-71df30f0154c"), new Guid("0b8487fc-e894-4db1-8473-43e9b8dca2de"), new Guid("9e82caac-a642-4184-ae2f-19d592b7c667") },
                    { new Guid("ee3d4334-e56f-4b21-bca9-7bf434aee1ce"), new Guid("d34df66b-f33e-4d99-aae5-7ab8ac7fdb71"), new Guid("0b8487fc-e894-4db1-8473-43e9b8dca2de"), new Guid("cffeaec1-b144-41d4-b573-5f623272d2c0") }
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
                column: "hall_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_session_movie_id",
                table: "tbl_session",
                column: "movie_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_phone_number",
                table: "tbl_user",
                column: "phone_number",
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
