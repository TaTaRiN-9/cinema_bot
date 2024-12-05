using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class addone_to_many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_session_hall_id",
                table: "tbl_session");

            migrationBuilder.DropIndex(
                name: "IX_tbl_session_movie_id",
                table: "tbl_session");

            migrationBuilder.DeleteData(
                table: "tbl_hall",
                keyColumn: "id",
                keyValue: new Guid("87f0763f-f20f-47f4-a0f0-fbe50f6f452d"));

            migrationBuilder.DeleteData(
                table: "tbl_movie",
                keyColumn: "id",
                keyValue: new Guid("11b607ee-7f27-4714-bf1e-39e3904e6cdb"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("65d8d5d2-69f2-4853-a094-847cbd4a2ba3"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("b1de6b6c-5563-465b-9a13-037053e7ba6b"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("06c0e549-c9d2-4c60-84a0-01e1200beef1"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("12fa832d-ecea-432b-9a3a-87fb5dd73b01"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("247bf6f9-5da8-4a0c-acad-51397c74607e"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("8b037017-bf6b-44e4-8e3f-92f411071d51"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("f6688833-dc70-422e-aedc-cd9d9aad5563"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("1c53a0bd-9bcf-4db3-bc5f-3f64373a9245"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("7e62a9a4-8b95-4009-b94c-35ad3e0d0052"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("91e7247d-f736-4545-92a5-dd8a2c864ed0"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("e32eebcb-dde8-45f7-9445-9734943d28df"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("faef26b5-c373-4a53-96a9-5973ef34c1ff"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"));

            migrationBuilder.DeleteData(
                table: "tbl_user",
                keyColumn: "id",
                keyValue: new Guid("3e703db7-ae2d-4aad-babf-2e37339950d4"));

            migrationBuilder.DeleteData(
                table: "tbl_user",
                keyColumn: "id",
                keyValue: new Guid("8080451e-69a7-4929-a804-10b38ff050c7"));

            migrationBuilder.DeleteData(
                table: "tbl_movie",
                keyColumn: "id",
                keyValue: new Guid("90725026-a9a9-4a70-9d77-88521956e2af"));

            migrationBuilder.DeleteData(
                table: "tbl_row",
                keyColumn: "id",
                keyValue: new Guid("d11132cc-89b1-4245-b9e7-fbb1ac1715a1"));

            migrationBuilder.DeleteData(
                table: "tbl_row",
                keyColumn: "id",
                keyValue: new Guid("f98a4a5f-b415-4f49-bb91-1ede3c73274b"));

            migrationBuilder.DeleteData(
                table: "tbl_hall",
                keyColumn: "id",
                keyValue: new Guid("5199fcb4-f999-4916-a095-f623692c948c"));

            migrationBuilder.InsertData(
                table: "tbl_hall",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("ab2bbfde-b06a-4af0-9c31-d08c7d09da71"), "Малый зал" },
                    { new Guid("ae28f2d7-18c8-430c-bf29-b84192e3e5c3"), "Большой зал" }
                });

            migrationBuilder.InsertData(
                table: "tbl_movie",
                columns: new[] { "id", "description", "duration", "photo_url", "title" },
                values: new object[,]
                {
                    { new Guid("e89892ee-7eda-410f-be2e-e57b4ef39275"), "Тут некоторое описание для фильма 2", 98, null, "Фильм 2" },
                    { new Guid("f164e8e7-ae7f-4d13-8435-07aa24c6ff2e"), "Тут некоторое описание для фильма 1", 104, null, "Фильм 1" }
                });

            migrationBuilder.InsertData(
                table: "tbl_user",
                columns: new[] { "id", "chat_id", "phone_number" },
                values: new object[,]
                {
                    { new Guid("64b31a8e-4a35-43d9-a1c6-58c6331cf516"), "89123453423", "89962963698" },
                    { new Guid("819c8d2d-5a69-4fcf-ad6d-fffbe1f44b37"), "891245653423", "89967351259" }
                });

            migrationBuilder.InsertData(
                table: "tbl_row",
                columns: new[] { "id", "hall_id", "number" },
                values: new object[,]
                {
                    { new Guid("111a4d68-ca80-4778-bfa0-57f9c73f35d7"), new Guid("ab2bbfde-b06a-4af0-9c31-d08c7d09da71"), 1 },
                    { new Guid("95443536-9544-4f24-8d99-85db845bb789"), new Guid("ab2bbfde-b06a-4af0-9c31-d08c7d09da71"), 2 }
                });

            migrationBuilder.InsertData(
                table: "tbl_session",
                columns: new[] { "id", "end_time", "hall_id", "movie_id", "price", "start_time" },
                values: new object[] { new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"), new DateTime(2024, 10, 28, 20, 15, 0, 0, DateTimeKind.Utc), new Guid("ab2bbfde-b06a-4af0-9c31-d08c7d09da71"), new Guid("f164e8e7-ae7f-4d13-8435-07aa24c6ff2e"), 250m, new DateTime(2024, 10, 28, 18, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "tbl_seat",
                columns: new[] { "id", "number", "row_id", "status" },
                values: new object[,]
                {
                    { new Guid("008caf23-42de-417f-8bfe-8ad2d9d131c4"), 3, new Guid("95443536-9544-4f24-8d99-85db845bb789"), false },
                    { new Guid("250f240c-0d2d-416f-8b81-cd6dc00e2cd0"), 2, new Guid("111a4d68-ca80-4778-bfa0-57f9c73f35d7"), true },
                    { new Guid("376dc811-beeb-4332-bc10-5e8957e39146"), 2, new Guid("95443536-9544-4f24-8d99-85db845bb789"), false },
                    { new Guid("74999076-d875-4513-a1d3-ab322db09ccf"), 4, new Guid("111a4d68-ca80-4778-bfa0-57f9c73f35d7"), true },
                    { new Guid("7fc7e373-febb-408f-b226-e21dc1430f2b"), 1, new Guid("95443536-9544-4f24-8d99-85db845bb789"), true },
                    { new Guid("dcd6db05-5890-431e-b330-c4db4e3e6026"), 3, new Guid("111a4d68-ca80-4778-bfa0-57f9c73f35d7"), true },
                    { new Guid("e117f571-bc42-43b9-8238-b713548d9f5f"), 1, new Guid("111a4d68-ca80-4778-bfa0-57f9c73f35d7"), true }
                });

            migrationBuilder.InsertData(
                table: "tbl_ticket",
                columns: new[] { "id", "seat_id", "session_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("16bee7b5-7586-494b-a70b-f83f9460e0fc"), new Guid("e117f571-bc42-43b9-8238-b713548d9f5f"), new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"), new Guid("64b31a8e-4a35-43d9-a1c6-58c6331cf516") },
                    { new Guid("53299b61-7a14-4d88-ba5d-a03acbd62ea3"), new Guid("250f240c-0d2d-416f-8b81-cd6dc00e2cd0"), new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"), new Guid("64b31a8e-4a35-43d9-a1c6-58c6331cf516") },
                    { new Guid("54119c01-57be-4426-82f6-907bad263f8f"), new Guid("74999076-d875-4513-a1d3-ab322db09ccf"), new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"), new Guid("819c8d2d-5a69-4fcf-ad6d-fffbe1f44b37") },
                    { new Guid("595848fd-50c3-4e80-a0de-467837ccdee9"), new Guid("7fc7e373-febb-408f-b226-e21dc1430f2b"), new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"), new Guid("819c8d2d-5a69-4fcf-ad6d-fffbe1f44b37") },
                    { new Guid("d92845b6-62cc-47d6-8406-e4aab8893272"), new Guid("dcd6db05-5890-431e-b330-c4db4e3e6026"), new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"), new Guid("819c8d2d-5a69-4fcf-ad6d-fffbe1f44b37") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_session_hall_id",
                table: "tbl_session",
                column: "hall_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_session_movie_id",
                table: "tbl_session",
                column: "movie_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_session_hall_id",
                table: "tbl_session");

            migrationBuilder.DropIndex(
                name: "IX_tbl_session_movie_id",
                table: "tbl_session");

            migrationBuilder.DeleteData(
                table: "tbl_hall",
                keyColumn: "id",
                keyValue: new Guid("ae28f2d7-18c8-430c-bf29-b84192e3e5c3"));

            migrationBuilder.DeleteData(
                table: "tbl_movie",
                keyColumn: "id",
                keyValue: new Guid("e89892ee-7eda-410f-be2e-e57b4ef39275"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("008caf23-42de-417f-8bfe-8ad2d9d131c4"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("376dc811-beeb-4332-bc10-5e8957e39146"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("16bee7b5-7586-494b-a70b-f83f9460e0fc"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("53299b61-7a14-4d88-ba5d-a03acbd62ea3"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("54119c01-57be-4426-82f6-907bad263f8f"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("595848fd-50c3-4e80-a0de-467837ccdee9"));

            migrationBuilder.DeleteData(
                table: "tbl_ticket",
                keyColumn: "id",
                keyValue: new Guid("d92845b6-62cc-47d6-8406-e4aab8893272"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("250f240c-0d2d-416f-8b81-cd6dc00e2cd0"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("74999076-d875-4513-a1d3-ab322db09ccf"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("7fc7e373-febb-408f-b226-e21dc1430f2b"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("dcd6db05-5890-431e-b330-c4db4e3e6026"));

            migrationBuilder.DeleteData(
                table: "tbl_seat",
                keyColumn: "id",
                keyValue: new Guid("e117f571-bc42-43b9-8238-b713548d9f5f"));

            migrationBuilder.DeleteData(
                table: "tbl_session",
                keyColumn: "id",
                keyValue: new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"));

            migrationBuilder.DeleteData(
                table: "tbl_user",
                keyColumn: "id",
                keyValue: new Guid("64b31a8e-4a35-43d9-a1c6-58c6331cf516"));

            migrationBuilder.DeleteData(
                table: "tbl_user",
                keyColumn: "id",
                keyValue: new Guid("819c8d2d-5a69-4fcf-ad6d-fffbe1f44b37"));

            migrationBuilder.DeleteData(
                table: "tbl_movie",
                keyColumn: "id",
                keyValue: new Guid("f164e8e7-ae7f-4d13-8435-07aa24c6ff2e"));

            migrationBuilder.DeleteData(
                table: "tbl_row",
                keyColumn: "id",
                keyValue: new Guid("111a4d68-ca80-4778-bfa0-57f9c73f35d7"));

            migrationBuilder.DeleteData(
                table: "tbl_row",
                keyColumn: "id",
                keyValue: new Guid("95443536-9544-4f24-8d99-85db845bb789"));

            migrationBuilder.DeleteData(
                table: "tbl_hall",
                keyColumn: "id",
                keyValue: new Guid("ab2bbfde-b06a-4af0-9c31-d08c7d09da71"));

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
                name: "IX_tbl_session_hall_id",
                table: "tbl_session",
                column: "hall_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_session_movie_id",
                table: "tbl_session",
                column: "movie_id",
                unique: true);
        }
    }
}
