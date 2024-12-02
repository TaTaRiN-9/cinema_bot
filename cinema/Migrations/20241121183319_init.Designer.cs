﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cinema.Data;

#nullable disable

namespace cinema.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20241121183319_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            id = new Guid("5199fcb4-f999-4916-a095-f623692c948c"),
                            name = "Малый зал"
                        },
                        new
                        {
                            id = new Guid("87f0763f-f20f-47f4-a0f0-fbe50f6f452d"),
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
                            id = new Guid("90725026-a9a9-4a70-9d77-88521956e2af"),
                            description = "Тут некоторое описание для фильма 1",
                            duration = 104,
                            title = "Фильм 1"
                        },
                        new
                        {
                            id = new Guid("11b607ee-7f27-4714-bf1e-39e3904e6cdb"),
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
                            id = new Guid("d11132cc-89b1-4245-b9e7-fbb1ac1715a1"),
                            hall_id = new Guid("5199fcb4-f999-4916-a095-f623692c948c"),
                            number = 1
                        },
                        new
                        {
                            id = new Guid("f98a4a5f-b415-4f49-bb91-1ede3c73274b"),
                            hall_id = new Guid("5199fcb4-f999-4916-a095-f623692c948c"),
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
                            id = new Guid("91e7247d-f736-4545-92a5-dd8a2c864ed0"),
                            number = 1,
                            row_id = new Guid("d11132cc-89b1-4245-b9e7-fbb1ac1715a1"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("faef26b5-c373-4a53-96a9-5973ef34c1ff"),
                            number = 1,
                            row_id = new Guid("d11132cc-89b1-4245-b9e7-fbb1ac1715a1"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("1c53a0bd-9bcf-4db3-bc5f-3f64373a9245"),
                            number = 2,
                            row_id = new Guid("d11132cc-89b1-4245-b9e7-fbb1ac1715a1"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("e32eebcb-dde8-45f7-9445-9734943d28df"),
                            number = 3,
                            row_id = new Guid("d11132cc-89b1-4245-b9e7-fbb1ac1715a1"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("7e62a9a4-8b95-4009-b94c-35ad3e0d0052"),
                            number = 1,
                            row_id = new Guid("f98a4a5f-b415-4f49-bb91-1ede3c73274b"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("65d8d5d2-69f2-4853-a094-847cbd4a2ba3"),
                            number = 2,
                            row_id = new Guid("f98a4a5f-b415-4f49-bb91-1ede3c73274b"),
                            status = false
                        },
                        new
                        {
                            id = new Guid("b1de6b6c-5563-465b-9a13-037053e7ba6b"),
                            number = 3,
                            row_id = new Guid("f98a4a5f-b415-4f49-bb91-1ede3c73274b"),
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

                    b.HasIndex("hall_id")
                        .IsUnique();

                    b.HasIndex("movie_id")
                        .IsUnique();

                    b.ToTable("tbl_session");

                    b.HasData(
                        new
                        {
                            id = new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"),
                            end_time = new DateTime(2024, 10, 28, 20, 15, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("5199fcb4-f999-4916-a095-f623692c948c"),
                            movie_id = new Guid("90725026-a9a9-4a70-9d77-88521956e2af"),
                            price = 250m,
                            start_time = new DateTime(2024, 10, 28, 18, 30, 0, 0, DateTimeKind.Utc)
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
                            id = new Guid("247bf6f9-5da8-4a0c-acad-51397c74607e"),
                            seat_id = new Guid("91e7247d-f736-4545-92a5-dd8a2c864ed0"),
                            session_id = new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"),
                            user_id = new Guid("3e703db7-ae2d-4aad-babf-2e37339950d4")
                        },
                        new
                        {
                            id = new Guid("8b037017-bf6b-44e4-8e3f-92f411071d51"),
                            seat_id = new Guid("faef26b5-c373-4a53-96a9-5973ef34c1ff"),
                            session_id = new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"),
                            user_id = new Guid("3e703db7-ae2d-4aad-babf-2e37339950d4")
                        },
                        new
                        {
                            id = new Guid("12fa832d-ecea-432b-9a3a-87fb5dd73b01"),
                            seat_id = new Guid("1c53a0bd-9bcf-4db3-bc5f-3f64373a9245"),
                            session_id = new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"),
                            user_id = new Guid("8080451e-69a7-4929-a804-10b38ff050c7")
                        },
                        new
                        {
                            id = new Guid("06c0e549-c9d2-4c60-84a0-01e1200beef1"),
                            seat_id = new Guid("e32eebcb-dde8-45f7-9445-9734943d28df"),
                            session_id = new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"),
                            user_id = new Guid("8080451e-69a7-4929-a804-10b38ff050c7")
                        },
                        new
                        {
                            id = new Guid("f6688833-dc70-422e-aedc-cd9d9aad5563"),
                            seat_id = new Guid("7e62a9a4-8b95-4009-b94c-35ad3e0d0052"),
                            session_id = new Guid("20b5e137-053a-41d4-9a52-2cb2cc33da6d"),
                            user_id = new Guid("8080451e-69a7-4929-a804-10b38ff050c7")
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("chat_id")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.HasKey("id");

                    b.HasIndex("chat_id")
                        .IsUnique();

                    b.ToTable("tbl_user");

                    b.HasData(
                        new
                        {
                            id = new Guid("3e703db7-ae2d-4aad-babf-2e37339950d4"),
                            chat_id = "89123453423",
                            phone_number = "89962963698"
                        },
                        new
                        {
                            id = new Guid("8080451e-69a7-4929-a804-10b38ff050c7"),
                            chat_id = "891245653423",
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
                        .WithOne("session")
                        .HasForeignKey("cinema.Data.Entities.Session", "hall_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinema.Data.Entities.Movie", "movie")
                        .WithOne("session")
                        .HasForeignKey("cinema.Data.Entities.Session", "movie_id")
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

                    b.Navigation("session");
                });

            modelBuilder.Entity("cinema.Data.Entities.Movie", b =>
                {
                    b.Navigation("session");
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