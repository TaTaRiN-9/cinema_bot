﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cinema.Data;

#nullable disable

namespace cinema.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    partial class CinemaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("cinema.Data.Entities.Hall", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("name")
                        .IsUnique();

                    b.ToTable("tbl_hall");

                    b.HasData(
                        new
                        {
                            id = new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"),
                            name = "Малый зал"
                        },
                        new
                        {
                            id = new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"),
                            name = "Большой зал"
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.Movie", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("duration")
                        .HasColumnType("integer");

                    b.Property<string>("photo_url")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("id");

                    b.HasIndex("title")
                        .IsUnique();

                    b.ToTable("tbl_movie");

                    b.HasData(
                        new
                        {
                            id = new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"),
                            description = "Тут некоторое описание для фильма 1",
                            duration = 104,
                            title = "Фильм 1"
                        },
                        new
                        {
                            id = new Guid("237b02ea-fc54-452b-8892-a27de9be1486"),
                            description = "Тут некоторое описание для фильма 2",
                            duration = 98,
                            title = "Фильм 2"
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.Row", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("hall_id")
                        .HasColumnType("uuid");

                    b.Property<int>("number")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("hall_id");

                    b.ToTable("tbl_row");

                    b.HasData(
                        new
                        {
                            id = new Guid("372c580d-8c50-4fdd-b30d-15cc0f979aec"),
                            hall_id = new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"),
                            number = 1
                        },
                        new
                        {
                            id = new Guid("c8c94a35-407b-4f9d-a9e3-bd0741e30f45"),
                            hall_id = new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"),
                            number = 2
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.Seat", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("number")
                        .HasColumnType("integer");

                    b.Property<Guid>("row_id")
                        .HasColumnType("uuid");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.HasIndex("row_id");

                    b.ToTable("tbl_seat");

                    b.HasData(
                        new
                        {
                            id = new Guid("80f41097-094f-4042-8468-a727371fb0c8"),
                            number = 1,
                            row_id = new Guid("372c580d-8c50-4fdd-b30d-15cc0f979aec"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("4007391c-fdee-46c1-a56b-cbb350bf2bba"),
                            number = 2,
                            row_id = new Guid("372c580d-8c50-4fdd-b30d-15cc0f979aec"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("2b6ba0a0-a8ea-455b-b566-a031f6767ffa"),
                            number = 3,
                            row_id = new Guid("372c580d-8c50-4fdd-b30d-15cc0f979aec"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("f646710a-1ecf-4d9a-81e1-02afa0d65b92"),
                            number = 4,
                            row_id = new Guid("372c580d-8c50-4fdd-b30d-15cc0f979aec"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("b7d06651-f93a-4520-ac81-89bd1e7972b7"),
                            number = 1,
                            row_id = new Guid("c8c94a35-407b-4f9d-a9e3-bd0741e30f45"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("7a0dd1ac-e715-42e8-aa16-6ecac45dd5a1"),
                            number = 2,
                            row_id = new Guid("c8c94a35-407b-4f9d-a9e3-bd0741e30f45"),
                            status = false
                        },
                        new
                        {
                            id = new Guid("86995802-7df4-4f75-927c-c8b81cb98dfd"),
                            number = 3,
                            row_id = new Guid("c8c94a35-407b-4f9d-a9e3-bd0741e30f45"),
                            status = false
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.Session", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("end_time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("hall_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("movie_id")
                        .HasColumnType("uuid");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("start_time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.HasIndex("hall_id");

                    b.HasIndex("movie_id");

                    b.ToTable("tbl_session");

                    b.HasData(
                        new
                        {
                            id = new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"),
                            end_time = new DateTime(2025, 1, 10, 12, 20, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"),
                            movie_id = new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"),
                            price = 250m,
                            start_time = new DateTime(2025, 1, 10, 10, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            id = new Guid("20b92c39-e8ed-49e6-99dd-fa420f1516eb"),
                            end_time = new DateTime(2025, 1, 10, 12, 20, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"),
                            movie_id = new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"),
                            price = 200m,
                            start_time = new DateTime(2025, 1, 10, 10, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            id = new Guid("c517617b-7cc3-4fd9-8e34-21198045adc6"),
                            end_time = new DateTime(2025, 1, 10, 14, 10, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"),
                            movie_id = new Guid("237b02ea-fc54-452b-8892-a27de9be1486"),
                            price = 150m,
                            start_time = new DateTime(2025, 1, 10, 12, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            id = new Guid("719c5845-2674-431c-90cb-be9fc1bdd4fb"),
                            end_time = new DateTime(2025, 1, 10, 14, 10, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"),
                            movie_id = new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"),
                            price = 150m,
                            start_time = new DateTime(2025, 1, 10, 12, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            id = new Guid("7087bbcc-f73e-4f4b-9337-0b0f83510c1c"),
                            end_time = new DateTime(2025, 1, 10, 16, 30, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"),
                            movie_id = new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"),
                            price = 175m,
                            start_time = new DateTime(2025, 1, 10, 14, 20, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            id = new Guid("28f5e9de-7780-4a72-95d6-8b2bbd66e714"),
                            end_time = new DateTime(2025, 1, 10, 16, 30, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"),
                            movie_id = new Guid("237b02ea-fc54-452b-8892-a27de9be1486"),
                            price = 222m,
                            start_time = new DateTime(2025, 1, 10, 14, 20, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            id = new Guid("e7816854-eef6-4917-a8e7-7c9db44a80ee"),
                            end_time = new DateTime(2025, 1, 10, 19, 15, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"),
                            movie_id = new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"),
                            price = 275m,
                            start_time = new DateTime(2025, 1, 10, 16, 45, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            id = new Guid("5b080204-7512-45e3-a0d3-2fabcaf58f5b"),
                            end_time = new DateTime(2025, 1, 10, 19, 25, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"),
                            movie_id = new Guid("237b02ea-fc54-452b-8892-a27de9be1486"),
                            price = 320m,
                            start_time = new DateTime(2025, 1, 10, 17, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            id = new Guid("d14daa4b-b8fc-4dc5-96ec-a08e9677d4ff"),
                            end_time = new DateTime(2025, 1, 10, 21, 5, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"),
                            movie_id = new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"),
                            price = 280m,
                            start_time = new DateTime(2025, 1, 10, 19, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            id = new Guid("bc6be794-62cb-48ba-b1f6-b363d850f970"),
                            end_time = new DateTime(2025, 1, 10, 22, 0, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"),
                            movie_id = new Guid("237b02ea-fc54-452b-8892-a27de9be1486"),
                            price = 300m,
                            start_time = new DateTime(2025, 1, 10, 19, 40, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            id = new Guid("9c86b428-e2e0-4ab3-9042-71e88f6e88df"),
                            end_time = new DateTime(2025, 1, 10, 23, 50, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("0373ba50-086f-49b4-88d0-7f24d1857626"),
                            movie_id = new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"),
                            price = 200m,
                            start_time = new DateTime(2025, 1, 10, 22, 10, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            id = new Guid("6c026b8e-4df4-40ca-bac2-26120dffed35"),
                            end_time = new DateTime(2025, 1, 10, 23, 0, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"),
                            movie_id = new Guid("72e1e00e-8ef0-4b9a-a1ec-18d15b361b6d"),
                            price = 195m,
                            start_time = new DateTime(2025, 1, 10, 21, 10, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            id = new Guid("10bc8ed3-d387-4f75-b389-d4fdb9b6bf56"),
                            end_time = new DateTime(2025, 1, 10, 23, 55, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("8facc6de-4ee7-4008-b772-0c854216ce7b"),
                            movie_id = new Guid("237b02ea-fc54-452b-8892-a27de9be1486"),
                            price = 230m,
                            start_time = new DateTime(2025, 1, 10, 23, 5, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.Ticket", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("seat_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("session_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("id");

                    b.HasIndex("seat_id")
                        .IsUnique();

                    b.HasIndex("session_id");

                    b.HasIndex("user_id");

                    b.ToTable("tbl_ticket");

                    b.HasData(
                        new
                        {
                            id = new Guid("961741d7-57e1-43b3-9ce3-5caeb8901475"),
                            seat_id = new Guid("80f41097-094f-4042-8468-a727371fb0c8"),
                            session_id = new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"),
                            user_id = new Guid("b4840ff3-6ccf-496c-baee-9422052a2413")
                        },
                        new
                        {
                            id = new Guid("f9b7c59b-f25f-4550-bf32-f9925de63bec"),
                            seat_id = new Guid("4007391c-fdee-46c1-a56b-cbb350bf2bba"),
                            session_id = new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"),
                            user_id = new Guid("b4840ff3-6ccf-496c-baee-9422052a2413")
                        },
                        new
                        {
                            id = new Guid("bfd1e2fc-da13-498d-9c2e-9a5e00fff4bf"),
                            seat_id = new Guid("2b6ba0a0-a8ea-455b-b566-a031f6767ffa"),
                            session_id = new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"),
                            user_id = new Guid("b7218838-84c1-4b1c-9df5-e287809a6aa7")
                        },
                        new
                        {
                            id = new Guid("2e34ffbc-6559-4655-84ca-1269c2d6dcfd"),
                            seat_id = new Guid("f646710a-1ecf-4d9a-81e1-02afa0d65b92"),
                            session_id = new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"),
                            user_id = new Guid("b7218838-84c1-4b1c-9df5-e287809a6aa7")
                        },
                        new
                        {
                            id = new Guid("3a7b419f-6bb9-4ad6-af84-f8d7cefdca94"),
                            seat_id = new Guid("b7d06651-f93a-4520-ac81-89bd1e7972b7"),
                            session_id = new Guid("1cfc4e70-13fc-42b0-a72a-e73cd3f65110"),
                            user_id = new Guid("b7218838-84c1-4b1c-9df5-e287809a6aa7")
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("chat_id")
                        .HasColumnType("bigint");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.HasKey("id");

                    b.HasIndex("chat_id")
                        .IsUnique();

                    b.HasIndex("phone_number")
                        .IsUnique();

                    b.ToTable("tbl_user");

                    b.HasData(
                        new
                        {
                            id = new Guid("b4840ff3-6ccf-496c-baee-9422052a2413"),
                            chat_id = 8912345L,
                            phone_number = "89962963698"
                        },
                        new
                        {
                            id = new Guid("b7218838-84c1-4b1c-9df5-e287809a6aa7"),
                            chat_id = 8912456L,
                            phone_number = "89967351259"
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.Row", b =>
                {
                    b.HasOne("cinema.Data.Entities.Hall", "hall")
                        .WithMany("rows")
                        .HasForeignKey("hall_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hall");
                });

            modelBuilder.Entity("cinema.Data.Entities.Seat", b =>
                {
                    b.HasOne("cinema.Data.Entities.Row", "row")
                        .WithMany("seats")
                        .HasForeignKey("row_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("row");
                });

            modelBuilder.Entity("cinema.Data.Entities.Session", b =>
                {
                    b.HasOne("cinema.Data.Entities.Hall", "hall")
                        .WithMany("sessions")
                        .HasForeignKey("hall_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinema.Data.Entities.Movie", "movie")
                        .WithMany("sessions")
                        .HasForeignKey("movie_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hall");

                    b.Navigation("movie");
                });

            modelBuilder.Entity("cinema.Data.Entities.Ticket", b =>
                {
                    b.HasOne("cinema.Data.Entities.Seat", "seat")
                        .WithOne("ticket")
                        .HasForeignKey("cinema.Data.Entities.Ticket", "seat_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinema.Data.Entities.Session", "session")
                        .WithMany("tickets")
                        .HasForeignKey("session_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinema.Data.Entities.User", "user")
                        .WithMany("tickets")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("seat");

                    b.Navigation("session");

                    b.Navigation("user");
                });

            modelBuilder.Entity("cinema.Data.Entities.Hall", b =>
                {
                    b.Navigation("rows");

                    b.Navigation("sessions");
                });

            modelBuilder.Entity("cinema.Data.Entities.Movie", b =>
                {
                    b.Navigation("sessions");
                });

            modelBuilder.Entity("cinema.Data.Entities.Row", b =>
                {
                    b.Navigation("seats");
                });

            modelBuilder.Entity("cinema.Data.Entities.Seat", b =>
                {
                    b.Navigation("ticket");
                });

            modelBuilder.Entity("cinema.Data.Entities.Session", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("cinema.Data.Entities.User", b =>
                {
                    b.Navigation("tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
