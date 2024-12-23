using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class newsessionforexample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_hall",
                keyColumn: "id",
                keyValue: new Guid("78be86b9-49eb-4eea-8bfa-11fdcc4786c0"));

            migrationBuilder.DeleteData(
                table: "tbl_movie",
                keyColumn: "id",
                keyValue: new Guid("496a1060-f32f-4c94-bf6f-60258b1b8e14"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("04307b99-eb3e-4eda-89cf-ac437f19bc16"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("38b89d78-01d7-4cb8-9b1b-549c4740cc29"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("7c9e5e59-e447-4bf0-82d5-81b96efed85d"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("82babe00-0f46-4e08-9930-e2d3479e38d8"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("c26c0ae8-8131-42e4-91be-92ea52f51708"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("e78cdfa3-7d0c-4dc0-8e05-94c187251293"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("ee3d4334-e56f-4b21-bca9-7bf434aee1ce"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("674dad84-83ea-4210-a543-71df30f0154c"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("7b3497c5-49f5-46c1-9618-2e3455af6b58"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("bb74c7cc-606b-4ade-bff3-d893b7d40a16"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("d34df66b-f33e-4d99-aae5-7ab8ac7fdb71"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("fa23004c-4427-4ee4-9e31-5f6bf08f14f9"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("0b8487fc-e894-4db1-8473-43e9b8dca2de"));

            migrationBuilder.DeleteData(
                table: "tbl_user",
                keyColumn: "id",
                keyValue: new Guid("9e82caac-a642-4184-ae2f-19d592b7c667"));

            migrationBuilder.DeleteData(
                table: "tbl_user",
                keyColumn: "id",
                keyValue: new Guid("cffeaec1-b144-41d4-b573-5f623272d2c0"));

            migrationBuilder.DeleteData(
                table: "tbl_movie",
                keyColumn: "id",
                keyValue: new Guid("b91f69c2-1547-4736-b84b-d4a73d6e8664"));

            migrationBuilder.DeleteData(
                table: "tbl_row",
                keyColumn: "id",
                keyValue: new Guid("59ff6c4f-bd1f-44dd-bf5c-c943f4bcc6fb"));

            migrationBuilder.DeleteData(
                table: "tbl_row",
                keyColumn: "id",
                keyValue: new Guid("9e5d95d9-ea83-47c0-9b2b-7e76f1ca9a56"));

            migrationBuilder.DeleteData(
                table: "tbl_hall",
                keyColumn: "id",
                keyValue: new Guid("0b19381e-7fb3-4184-99ad-889eb18d280e"));

            migrationBuilder.InsertData(
                table: "tbl_hall",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"), "Малый зал" },
                    { new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"), "Большой зал" }
                });

            migrationBuilder.InsertData(
                table: "tbl_movie",
                columns: new[] { "id", "description", "duration", "photo_url", "title" },
                values: new object[,]
                {
                    { new Guid("237b02ea-fc54-452b-8892-a27de9be1486"), "Тут некоторое описание для фильма 2", 98, null, "Фильм 2" },
                    { new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"), "Тут некоторое описание для фильма 1", 104, null, "Фильм 1" }
                });

            migrationBuilder.InsertData(
                table: "tbl_user",
                columns: new[] { "id", "chat_id", "phone_number" },
                values: new object[,]
                {
                    { new Guid("b4840ff3-6ccf-496c-baee-9422052a2413"), 8912345L, "89962963698" },
                    { new Guid("b7218838-84c1-4b1c-9df5-e287809a6aa7"), 8912456L, "89967351259" }
                });

            migrationBuilder.InsertData(
                table: "tbl_row",
                columns: new[] { "id", "hall_id", "number" },
                values: new object[,]
                {
                    { new Guid("372c580d-8c50-4fdd-b30d-15cc0f979aec"), new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"), 1 },
                    { new Guid("c8c94a35-407b-4f9d-a9e3-bd0741e30f45"), new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"), 2 }
                });

            migrationBuilder.InsertData(
                table: "tbl_session",
                columns: new[] { "id", "end_time", "hall_id", "movie_id", "price", "start_time" },
                values: new object[,]
                {
                    { new Guid("10bc8ed3-d387-4f75-b389-d4fdb9b6bf56"), new DateTime(2025, 1, 10, 23, 55, 0, 0, DateTimeKind.Utc), new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"), new Guid("237b02ea-fc54-452b-8892-a27de9be1486"), 230m, new DateTime(2025, 1, 10, 23, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"), new DateTime(2025, 1, 10, 12, 20, 0, 0, DateTimeKind.Utc), new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"), new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"), 250m, new DateTime(2025, 1, 10, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("20b92c39-e8ed-49e6-99dd-fa420f1516eb"), new DateTime(2025, 1, 10, 12, 20, 0, 0, DateTimeKind.Utc), new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"), new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"), 200m, new DateTime(2025, 1, 10, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("28f5e9de-7780-4a72-95d6-8b2bbd66e714"), new DateTime(2025, 1, 10, 16, 30, 0, 0, DateTimeKind.Utc), new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"), new Guid("237b02ea-fc54-452b-8892-a27de9be1486"), 222m, new DateTime(2025, 1, 10, 14, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5b080204-7512-45e3-a0d3-2fabcaf58f5b"), new DateTime(2025, 1, 10, 19, 25, 0, 0, DateTimeKind.Utc), new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"), new Guid("237b02ea-fc54-452b-8892-a27de9be1486"), 320m, new DateTime(2025, 1, 10, 17, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("6c026b8e-4df4-40ca-bac2-26120dffed35"), new DateTime(2025, 1, 10, 23, 0, 0, 0, DateTimeKind.Utc), new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"), new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"), 195m, new DateTime(2025, 1, 10, 21, 10, 0, 0, DateTimeKind.Utc) },
                    { new Guid("7087bbcc-f73e-4f4b-9337-0b0f83510c1c"), new DateTime(2025, 1, 10, 16, 30, 0, 0, DateTimeKind.Utc), new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"), new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"), 175m, new DateTime(2025, 1, 10, 14, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("719c5845-2674-431c-90cb-be9fc1bdd4fb"), new DateTime(2025, 1, 10, 14, 10, 0, 0, DateTimeKind.Utc), new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"), new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"), 150m, new DateTime(2025, 1, 10, 12, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("9c86b428-e2e0-4ab3-9042-71e88f6e88df"), new DateTime(2025, 1, 10, 23, 50, 0, 0, DateTimeKind.Utc), new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"), new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"), 200m, new DateTime(2025, 1, 10, 22, 10, 0, 0, DateTimeKind.Utc) },
                    { new Guid("bc6be794-62cb-48ba-b1f6-b363d850f970"), new DateTime(2025, 1, 10, 22, 0, 0, 0, DateTimeKind.Utc), new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"), new Guid("237b02ea-fc54-452b-8892-a27de9be1486"), 300m, new DateTime(2025, 1, 10, 19, 40, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c517617b-7cc3-4fd9-8e34-21198045adc6"), new DateTime(2025, 1, 10, 14, 10, 0, 0, DateTimeKind.Utc), new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"), new Guid("237b02ea-fc54-452b-8892-a27de9be1486"), 150m, new DateTime(2025, 1, 10, 12, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("d14daa4b-b8fc-4dc5-96ec-a08e9677d4ff"), new DateTime(2025, 1, 10, 21, 5, 0, 0, DateTimeKind.Utc), new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"), new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"), 280m, new DateTime(2025, 1, 10, 19, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("e7816854-eef6-4917-a8e7-7c9db44a80ee"), new DateTime(2025, 1, 10, 19, 15, 0, 0, DateTimeKind.Utc), new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"), new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"), 275m, new DateTime(2025, 1, 10, 16, 45, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "tbl_seat",
                columns: new[] { "id", "number", "row_id", "status" },
                values: new object[,]
                {
                    { new Guid("2b6ba0a0-a8ea-455b-b566-a031f6767ffa"), 3, new Guid("372c580d-8c50-4fdd-b30d-15cc0f979aec"), true },
                    { new Guid("4007391c-fdee-46c1-a56b-cbb350bf2bba"), 2, new Guid("372c580d-8c50-4fdd-b30d-15cc0f979aec"), true },
                    { new Guid("7a0dd1ac-e715-42e8-aa16-6ecac45dd5a1"), 2, new Guid("c8c94a35-407b-4f9d-a9e3-bd0741e30f45"), false },
                    { new Guid("80f41097-094f-4042-8468-a727371fb0c8"), 1, new Guid("372c580d-8c50-4fdd-b30d-15cc0f979aec"), true },
                    { new Guid("86995802-7df4-4f75-927c-c8b81cb98dfd"), 3, new Guid("c8c94a35-407b-4f9d-a9e3-bd0741e30f45"), false },
                    { new Guid("b7d06651-f93a-4520-ac81-89bd1e7972b7"), 1, new Guid("c8c94a35-407b-4f9d-a9e3-bd0741e30f45"), true },
                    { new Guid("f646710a-1ecf-4d9a-81e1-02afa0d65b92"), 4, new Guid("372c580d-8c50-4fdd-b30d-15cc0f979aec"), true }
                });

            migrationBuilder.InsertData(
                table: "tbl_ticket",
                columns: new[] { "id", "seat_id", "session_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("2e34ffbc-6559-4655-84ca-1269c2d6dcfd"), new Guid("f646710a-1ecf-4d9a-81e1-02afa0d65b92"), new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"), new Guid("b7218838-84c1-4b1c-9df5-e287809a6aa7") },
                    { new Guid("3a7b419f-6bb9-4ad6-af84-f8d7cefdca94"), new Guid("b7d06651-f93a-4520-ac81-89bd1e7972b7"), new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"), new Guid("b7218838-84c1-4b1c-9df5-e287809a6aa7") },
                    { new Guid("961741d7-57e1-43b3-9ce3-5caeb8901475"), new Guid("80f41097-094f-4042-8468-a727371fb0c8"), new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"), new Guid("b4840ff3-6ccf-496c-baee-9422052a2413") },
                    { new Guid("bfd1e2fc-da13-498d-9c2e-9a5e00fff4bf"), new Guid("2b6ba0a0-a8ea-455b-b566-a031f6767ffa"), new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"), new Guid("b7218838-84c1-4b1c-9df5-e287809a6aa7") },
                    { new Guid("f9b7c59b-f25f-4550-bf32-f9925de63bec"), new Guid("4007391c-fdee-46c1-a56b-cbb350bf2bba"), new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"), new Guid("b4840ff3-6ccf-496c-baee-9422052a2413") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("7a0dd1ac-e715-42e8-aa16-6ecac45dd5a1"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("86995802-7df4-4f75-927c-c8b81cb98dfd"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("10bc8ed3-d387-4f75-b389-d4fdb9b6bf56"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("20b92c39-e8ed-49e6-99dd-fa420f1516eb"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("28f5e9de-7780-4a72-95d6-8b2bbd66e714"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("5b080204-7512-45e3-a0d3-2fabcaf58f5b"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("6c026b8e-4df4-40ca-bac2-26120dffed35"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("7087bbcc-f73e-4f4b-9337-0b0f83510c1c"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("719c5845-2674-431c-90cb-be9fc1bdd4fb"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("9c86b428-e2e0-4ab3-9042-71e88f6e88df"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("bc6be794-62cb-48ba-b1f6-b363d850f970"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("c517617b-7cc3-4fd9-8e34-21198045adc6"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("d14daa4b-b8fc-4dc5-96ec-a08e9677d4ff"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("e7816854-eef6-4917-a8e7-7c9db44a80ee"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("2e34ffbc-6559-4655-84ca-1269c2d6dcfd"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("3a7b419f-6bb9-4ad6-af84-f8d7cefdca94"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("961741d7-57e1-43b3-9ce3-5caeb8901475"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("bfd1e2fc-da13-498d-9c2e-9a5e00fff4bf"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("f9b7c59b-f25f-4550-bf32-f9925de63bec"));

            migrationBuilder.DeleteData(
                table: "tbl_hall",
                keyColumn: "id",
                keyValue: new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"));

            migrationBuilder.DeleteData(
                table: "tbl_movie",
                keyColumn: "id",
                keyValue: new Guid("237b02ea-fc54-452b-8892-a27de9be1486"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("2b6ba0a0-a8ea-455b-b566-a031f6767ffa"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("4007391c-fdee-46c1-a56b-cbb350bf2bba"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("80f41097-094f-4042-8468-a727371fb0c8"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("b7d06651-f93a-4520-ac81-89bd1e7972b7"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("f646710a-1ecf-4d9a-81e1-02afa0d65b92"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"));

            migrationBuilder.DeleteData(
                table: "tbl_user",
                keyColumn: "id",
                keyValue: new Guid("b4840ff3-6ccf-496c-baee-9422052a2413"));

            migrationBuilder.DeleteData(
                table: "tbl_user",
                keyColumn: "id",
                keyValue: new Guid("b7218838-84c1-4b1c-9df5-e287809a6aa7"));

            migrationBuilder.DeleteData(
                table: "tbl_movie",
                keyColumn: "id",
                keyValue: new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"));

            migrationBuilder.DeleteData(
                table: "tbl_row",
                keyColumn: "id",
                keyValue: new Guid("372c580d-8c50-4fdd-b30d-15cc0f979aec"));

            migrationBuilder.DeleteData(
                table: "tbl_row",
                keyColumn: "id",
                keyValue: new Guid("c8c94a35-407b-4f9d-a9e3-bd0741e30f45"));

            migrationBuilder.DeleteData(
                table: "tbl_hall",
                keyColumn: "id",
                keyValue: new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"));

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
        }
    }
}
