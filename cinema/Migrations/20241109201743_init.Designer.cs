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
    [Migration("20241109201743_init")]
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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

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
                            id = 1,
                            name = "Малый зал"
                        },
                        new
                        {
                            id = 2,
                            name = "Большой зал"
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.Movie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

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
                            id = 1,
                            description = "Тут некоторое описание для фильма 1",
                            duration = 104,
                            title = "Фильм 1"
                        },
                        new
                        {
                            id = 2,
                            description = "Тут некоторое описание для фильма 2",
                            duration = 98,
                            title = "Фильм 2"
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.Row", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("hall_id")
                        .HasColumnType("integer");

                    b.Property<int>("number")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("hall_id");

                    b.ToTable("tbl_row");

                    b.HasData(
                        new
                        {
                            id = 1,
                            hall_id = 1,
                            number = 1
                        },
                        new
                        {
                            id = 2,
                            hall_id = 1,
                            number = 2
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.Seat", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("number")
                        .HasColumnType("integer");

                    b.Property<int>("row_id")
                        .HasColumnType("integer");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.HasIndex("row_id");

                    b.ToTable("tbl_seat");

                    b.HasData(
                        new
                        {
                            id = 1,
                            number = 1,
                            row_id = 1,
                            status = true
                        },
                        new
                        {
                            id = 2,
                            number = 1,
                            row_id = 1,
                            status = true
                        },
                        new
                        {
                            id = 3,
                            number = 2,
                            row_id = 1,
                            status = true
                        },
                        new
                        {
                            id = 4,
                            number = 3,
                            row_id = 1,
                            status = true
                        },
                        new
                        {
                            id = 5,
                            number = 1,
                            row_id = 2,
                            status = true
                        },
                        new
                        {
                            id = 6,
                            number = 2,
                            row_id = 2,
                            status = false
                        },
                        new
                        {
                            id = 7,
                            number = 3,
                            row_id = 2,
                            status = false
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.Session", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("end_time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("hall_id")
                        .HasColumnType("integer");

                    b.Property<int>("movie_id")
                        .HasColumnType("integer");

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
                            id = 1,
                            end_time = new DateTime(2024, 10, 28, 20, 15, 0, 0, DateTimeKind.Utc),
                            hall_id = 1,
                            movie_id = 1,
                            price = 250m,
                            start_time = new DateTime(2024, 10, 28, 18, 30, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("cinema.Data.Entities.Ticket", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("seat_id")
                        .HasColumnType("integer");

                    b.Property<int>("session_id")
                        .HasColumnType("integer");

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
                            id = 1,
                            seat_id = 1,
                            session_id = 1,
                            user_id = new Guid("04e35a41-d0f4-423a-a264-48af8da26f30")
                        },
                        new
                        {
                            id = 2,
                            seat_id = 2,
                            session_id = 1,
                            user_id = new Guid("04e35a41-d0f4-423a-a264-48af8da26f30")
                        },
                        new
                        {
                            id = 3,
                            seat_id = 3,
                            session_id = 1,
                            user_id = new Guid("7ecc95e9-d57d-42f4-b346-703f97e6b1bd")
                        },
                        new
                        {
                            id = 4,
                            seat_id = 4,
                            session_id = 1,
                            user_id = new Guid("7ecc95e9-d57d-42f4-b346-703f97e6b1bd")
                        },
                        new
                        {
                            id = 5,
                            seat_id = 5,
                            session_id = 1,
                            user_id = new Guid("7ecc95e9-d57d-42f4-b346-703f97e6b1bd")
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
                            id = new Guid("04e35a41-d0f4-423a-a264-48af8da26f30"),
                            chat_id = "89123453423",
                            phone_number = "89962963698"
                        },
                        new
                        {
                            id = new Guid("7ecc95e9-d57d-42f4-b346-703f97e6b1bd"),
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