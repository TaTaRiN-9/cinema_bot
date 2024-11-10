﻿using System;
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
                name: "tbl_movie",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    row_id = table.Column<int>(type: "integer", nullable: false),
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
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    seat_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    session_id = table.Column<int>(type: "integer", nullable: false)
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
                    { 1, "Малый зал" },
                    { 2, "Большой зал" }
                });

            migrationBuilder.InsertData(
                table: "tbl_movie",
                columns: new[] { "id", "description", "duration", "photo_url", "title" },
                values: new object[,]
                {
                    { 1, "Тут некоторое описание для фильма 1", 104, null, "Фильм 1" },
                    { 2, "Тут некоторое описание для фильма 2", 98, null, "Фильм 2" }
                });

            migrationBuilder.InsertData(
                table: "tbl_user",
                columns: new[] { "id", "chat_id", "phone_number" },
                values: new object[,]
                {
                    { new Guid("04e35a41-d0f4-423a-a264-48af8da26f30"), "89123453423", "89962963698" },
                    { new Guid("7ecc95e9-d57d-42f4-b346-703f97e6b1bd"), "891245653423", "89967351259" }
                });

            migrationBuilder.InsertData(
                table: "tbl_row",
                columns: new[] { "id", "hall_id", "number" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "tbl_session",
                columns: new[] { "id", "end_time", "hall_id", "movie_id", "price", "start_time" },
                values: new object[] { 1, new DateTime(2024, 10, 28, 20, 15, 0, 0, DateTimeKind.Utc), 1, 1, 250m, new DateTime(2024, 10, 28, 18, 30, 0, 0, DateTimeKind.Utc) });

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

            migrationBuilder.InsertData(
                table: "tbl_ticket",
                columns: new[] { "id", "seat_id", "session_id", "user_id" },
                values: new object[,]
                {
                    { 1, 1, 1, new Guid("04e35a41-d0f4-423a-a264-48af8da26f30") },
                    { 2, 2, 1, new Guid("04e35a41-d0f4-423a-a264-48af8da26f30") },
                    { 3, 3, 1, new Guid("7ecc95e9-d57d-42f4-b346-703f97e6b1bd") },
                    { 4, 4, 1, new Guid("7ecc95e9-d57d-42f4-b346-703f97e6b1bd") },
                    { 5, 5, 1, new Guid("7ecc95e9-d57d-42f4-b346-703f97e6b1bd") }
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