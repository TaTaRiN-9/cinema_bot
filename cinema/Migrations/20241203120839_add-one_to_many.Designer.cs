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
    [Migration("20241203120839_add-one_to_many")]
    partial class addone_to_many
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
                            id = new Guid("ab2bbfde-b06a-4af0-9c31-d08c7d09da71"),
                            name = "Малый зал"
                        },
                        new
                        {
                            id = new Guid("ae28f2d7-18c8-430c-bf29-b84192e3e5c3"),
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
                            id = new Guid("f164e8e7-ae7f-4d13-8435-07aa24c6ff2e"),
                            description = "Тут некоторое описание для фильма 1",
                            duration = 104,
                            title = "Фильм 1"
                        },
                        new
                        {
                            id = new Guid("e89892ee-7eda-410f-be2e-e57b4ef39275"),
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
                            id = new Guid("111a4d68-ca80-4778-bfa0-57f9c73f35d7"),
                            hall_id = new Guid("ab2bbfde-b06a-4af0-9c31-d08c7d09da71"),
                            number = 1
                        },
                        new
                        {
                            id = new Guid("95443536-9544-4f24-8d99-85db845bb789"),
                            hall_id = new Guid("ab2bbfde-b06a-4af0-9c31-d08c7d09da71"),
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
                            id = new Guid("e117f571-bc42-43b9-8238-b713548d9f5f"),
                            number = 1,
                            row_id = new Guid("111a4d68-ca80-4778-bfa0-57f9c73f35d7"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("250f240c-0d2d-416f-8b81-cd6dc00e2cd0"),
                            number = 2,
                            row_id = new Guid("111a4d68-ca80-4778-bfa0-57f9c73f35d7"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("dcd6db05-5890-431e-b330-c4db4e3e6026"),
                            number = 3,
                            row_id = new Guid("111a4d68-ca80-4778-bfa0-57f9c73f35d7"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("74999076-d875-4513-a1d3-ab322db09ccf"),
                            number = 4,
                            row_id = new Guid("111a4d68-ca80-4778-bfa0-57f9c73f35d7"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("7fc7e373-febb-408f-b226-e21dc1430f2b"),
                            number = 1,
                            row_id = new Guid("95443536-9544-4f24-8d99-85db845bb789"),
                            status = true
                        },
                        new
                        {
                            id = new Guid("376dc811-beeb-4332-bc10-5e8957e39146"),
                            number = 2,
                            row_id = new Guid("95443536-9544-4f24-8d99-85db845bb789"),
                            status = false
                        },
                        new
                        {
                            id = new Guid("008caf23-42de-417f-8bfe-8ad2d9d131c4"),
                            number = 3,
                            row_id = new Guid("95443536-9544-4f24-8d99-85db845bb789"),
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
                            id = new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"),
                            end_time = new DateTime(2024, 10, 28, 20, 15, 0, 0, DateTimeKind.Utc),
                            hall_id = new Guid("ab2bbfde-b06a-4af0-9c31-d08c7d09da71"),
                            movie_id = new Guid("f164e8e7-ae7f-4d13-8435-07aa24c6ff2e"),
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
                            id = new Guid("16bee7b5-7586-494b-a70b-f83f9460e0fc"),
                            seat_id = new Guid("e117f571-bc42-43b9-8238-b713548d9f5f"),
                            session_id = new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"),
                            user_id = new Guid("64b31a8e-4a35-43d9-a1c6-58c6331cf516")
                        },
                        new
                        {
                            id = new Guid("53299b61-7a14-4d88-ba5d-a03acbd62ea3"),
                            seat_id = new Guid("250f240c-0d2d-416f-8b81-cd6dc00e2cd0"),
                            session_id = new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"),
                            user_id = new Guid("64b31a8e-4a35-43d9-a1c6-58c6331cf516")
                        },
                        new
                        {
                            id = new Guid("d92845b6-62cc-47d6-8406-e4aab8893272"),
                            seat_id = new Guid("dcd6db05-5890-431e-b330-c4db4e3e6026"),
                            session_id = new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"),
                            user_id = new Guid("819c8d2d-5a69-4fcf-ad6d-fffbe1f44b37")
                        },
                        new
                        {
                            id = new Guid("54119c01-57be-4426-82f6-907bad263f8f"),
                            seat_id = new Guid("74999076-d875-4513-a1d3-ab322db09ccf"),
                            session_id = new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"),
                            user_id = new Guid("819c8d2d-5a69-4fcf-ad6d-fffbe1f44b37")
                        },
                        new
                        {
                            id = new Guid("595848fd-50c3-4e80-a0de-467837ccdee9"),
                            seat_id = new Guid("7fc7e373-febb-408f-b226-e21dc1430f2b"),
                            session_id = new Guid("4cff6804-98e8-4cdf-bd76-bcecf1cb2c81"),
                            user_id = new Guid("819c8d2d-5a69-4fcf-ad6d-fffbe1f44b37")
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
                            id = new Guid("64b31a8e-4a35-43d9-a1c6-58c6331cf516"),
                            chat_id = "89123453423",
                            phone_number = "89962963698"
                        },
                        new
                        {
                            id = new Guid("819c8d2d-5a69-4fcf-ad6d-fffbe1f44b37"),
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