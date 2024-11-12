using System.Reflection;
using cinema.Data.Configuration;
using cinema.Data.Entities;
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

            Guid idHall1 = Guid.NewGuid();
            Guid idHall2 = Guid.NewGuid();
            // добавление первоначальных данных в бд
            modelBuilder.Entity<Hall>()
                .HasData(
                    new Hall { id = idHall1, name = "Малый зал" },
                    new Hall { id = idHall2, name = "Большой зал" }
                );

            Guid idRow1 = Guid.NewGuid();
            Guid idRow2 = Guid.NewGuid();

            modelBuilder.Entity<Row>()
                .HasData(
                    new Row { id = idRow1, number = 1, hall_id = idHall1 },
                    new Row { id = idRow2, number = 2, hall_id = idHall1 }
                );

            Guid idSeat1 = Guid.NewGuid();
            Guid idSeat2 = Guid.NewGuid();
            Guid idSeat3 = Guid.NewGuid();
            Guid idSeat4 = Guid.NewGuid();
            Guid idSeat5 = Guid.NewGuid();
            Guid idSeat6 = Guid.NewGuid();
            Guid idSeat7 = Guid.NewGuid();

            modelBuilder.Entity<Seat>()
                .HasData(
                    new Seat { id = idSeat1, row_id = idRow1, number = 1, status = true },
                    new Seat { id = idSeat2, row_id = idRow1, number = 1, status = true },
                    new Seat { id = idSeat3, row_id = idRow1, number = 2, status = true },
                    new Seat { id = idSeat4, row_id = idRow1, number = 3, status = true },
                    new Seat { id = idSeat5, row_id = idRow2, number = 1, status = true },
                    new Seat { id = idSeat6, row_id = idRow2, number = 2, status = false },
                    new Seat { id = idSeat7, row_id = idRow2, number = 3, status = false }
                );

            Guid guidUser1 = Guid.NewGuid();
            Guid guidUser2 = Guid.NewGuid();

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        id = guidUser1,
                        chat_id = "89123453423",
                        phone_number = "89962963698"
                    },
                    new User
                    {
                        id = guidUser2,
                        chat_id = "891245653423",
                        phone_number = "89967351259",
                    }
                    );

            Guid idMovie1 = Guid.NewGuid();
            Guid idMovie2 = Guid.NewGuid();

            modelBuilder.Entity<Movie>()
                .HasData(
                    new Movie
                    {
                        id = idMovie1,
                        title = "Фильм 1",
                        description = "Тут некоторое описание для фильма 1",
                        duration = 104
                    },
                    new Movie
                    {
                        id = idMovie2,
                        title = "Фильм 2",
                        description = "Тут некоторое описание для фильма 2",
                        duration = 98
                    });

            Guid idSession1 = Guid.NewGuid();

            modelBuilder.Entity<Session>()
                .HasData(
                    new Session
                    {
                        id = idSession1,
                        price = 250,
                        start_time = DateTime.SpecifyKind(new DateTime(2024, 10, 28, 18, 30, 0), DateTimeKind.Utc),
                        end_time = DateTime.SpecifyKind(new DateTime(2024, 10, 28, 20, 15, 0), DateTimeKind.Utc),
                        hall_id = idHall1,
                        movie_id = idMovie1,
                    });

            Guid idTicket1 = Guid.NewGuid();
            Guid idTicket2 = Guid.NewGuid();
            Guid idTicket3 = Guid.NewGuid();
            Guid idTicket4 = Guid.NewGuid();
            Guid idTicket5 = Guid.NewGuid();

            modelBuilder.Entity<Ticket>()
                .HasData(
                    new Ticket { id = idTicket1, seat_id = idSeat1, session_id = idSession1, user_id = guidUser1 },
                    new Ticket { id = idTicket2, seat_id = idSeat2, session_id = idSession1, user_id = guidUser1 },
                    new Ticket { id = idTicket3, seat_id = idSeat3, session_id = idSession1, user_id = guidUser2 },
                    new Ticket { id = idTicket4, seat_id = idSeat4, session_id = idSession1, user_id = guidUser2 },
                    new Ticket { id = idTicket5, seat_id = idSeat5, session_id = idSession1, user_id = guidUser2 }
                );
        }
    }
}
