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
    [Migration("20241028202516_add_movie")]
    partial class add_movie
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("cinema.Data.Models.Movie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("duration")
                        .HasColumnType("integer");

                    b.Property<string>("photo_url")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

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

            modelBuilder.Entity("cinema.Data.Models.Session", b =>
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

            modelBuilder.Entity("cinema.Data.Models.Ticket", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("row_number")
                        .HasColumnType("integer");

                    b.Property<int>("seat_number")
                        .HasColumnType("integer");

                    b.Property<int>("session_id")
                        .HasColumnType("integer");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("session_id");

                    b.HasIndex("user_id");

                    b.HasIndex("row_number", "seat_number")
                        .IsUnique();

                    b.ToTable("tbl_ticket");

                    b.HasData(
                        new
                        {
                            id = 1,
                            row_number = 1,
                            seat_number = 1,
                            session_id = 1,
                            user_id = 1
                        },
                        new
                        {
                            id = 2,
                            row_number = 1,
                            seat_number = 2,
                            session_id = 1,
                            user_id = 1
                        },
                        new
                        {
                            id = 3,
                            row_number = 1,
                            seat_number = 3,
                            session_id = 1,
                            user_id = 2
                        },
                        new
                        {
                            id = 4,
                            row_number = 1,
                            seat_number = 4,
                            session_id = 1,
                            user_id = 2
                        },
                        new
                        {
                            id = 5,
                            row_number = 1,
                            seat_number = 6,
                            session_id = 1,
                            user_id = 2
                        });
                });

            modelBuilder.Entity("cinema.Data.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

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
                            id = 1,
                            chat_id = "89123453423",
                            phone_number = "89962963698"
                        },
                        new
                        {
                            id = 2,
                            chat_id = "891245653423",
                            phone_number = "89967351259"
                        });
                });

            modelBuilder.Entity("cinema.Data.Models.Ticket", b =>
                {
                    b.HasOne("cinema.Data.Models.Session", "session")
                        .WithMany("tickets")
                        .HasForeignKey("session_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinema.Data.Models.User", "user")
                        .WithMany("tickets")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("session");

                    b.Navigation("user");
                });

            modelBuilder.Entity("cinema.Data.Models.Session", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("cinema.Data.Models.User", b =>
                {
                    b.Navigation("tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
