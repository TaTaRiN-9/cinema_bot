using System.Reflection;
using cinema.Data.Configuration;
using cinema.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) 
            : base(options) 
        { }

        public DbSet<User> users { get; set; } = null!;
        public DbSet<Ticket> tickets { get; set; } = null!;
        public DbSet<Session> sessions { get; set; } = null!;
        public DbSet<Movie> movies { get; set; } = null!;
        public DbSet<Seat> seats { get; set; } = null!;
        public DbSet<Hall> halls { get; set; } = null!;
        public DbSet<Row> rows { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // добавление первоначальных данных в бд
            modelBuilder.Entity<Hall>()
                .HasData(
                    new Hall { id = 1, name = "Малый зал" },
                    new Hall { id = 2, name = "Большой зал" }
                );

            modelBuilder.Entity<Row>()
                .HasData(
                    new Row { id = 1, number = 1, hall_id = 1 },
                    new Row { id = 2, number = 2, hall_id = 1 }
                );

            modelBuilder.Entity<Seat>()
                .HasData(
                    new Seat { id = 1, row_id = 1, number = 1, status = true },
                    new Seat { id = 2, row_id = 1, number = 1, status = true },
                    new Seat { id = 3, row_id = 1, number = 2, status = true },
                    new Seat { id = 4, row_id = 1, number = 3, status = true },
                    new Seat { id = 5, row_id = 2, number = 1, status = true },
                    new Seat { id = 6, row_id = 2, number = 2, status = false },
                    new Seat { id = 7, row_id = 2, number = 3, status = false }
                );

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        id = 1,
                        chat_id = "89123453423",
                        phone_number = "89962963698"
                    },
                    new User
                    {
                        id = 2,
                        chat_id = "891245653423",
                        phone_number = "89967351259",
                    }
                    );

            modelBuilder.Entity<Movie>()
                .HasData(
                    new Movie
                    {
                        id = 1,
                        title = "Фильм 1",
                        description = "Тут некоторое описание для фильма 1",
                        duration = 104
                    },
                    new Movie
                    {
                        id = 2,
                        title = "Фильм 2",
                        description = "Тут некоторое описание для фильма 2",
                        duration = 98
                    });

            modelBuilder.Entity<Session>()
                .HasData(
                    new Session
                    {
                        id = 1,
                        price = 250,
                        start_time = DateTime.SpecifyKind(new DateTime(2024, 10, 28, 18, 30, 0), DateTimeKind.Utc),
                        end_time = DateTime.SpecifyKind(new DateTime(2024, 10, 28, 20, 15, 0), DateTimeKind.Utc),
                        hall_id = 1,
                        movie_id = 1,
                    });

            modelBuilder.Entity<Ticket>()
                .HasData(
                    new Ticket { id = 1, seat_id = 1, session_id = 1, user_id = 1 },
                    new Ticket { id = 2, seat_id = 2, session_id = 1, user_id = 1 },
                    new Ticket { id = 3, seat_id = 3, session_id = 1, user_id = 2 },
                    new Ticket { id = 4, seat_id = 4, session_id = 1, user_id = 2 },
                    new Ticket { id = 5, seat_id = 5, session_id = 1, user_id = 2 }
                );
        }
    }
}
