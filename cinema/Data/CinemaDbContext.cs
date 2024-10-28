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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            // добавление первоначальных данных в бд
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
                    });

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
                    new Ticket { id = 1, row_number = 1, seat_number = 1, session_id = 1, user_id = 1 },
                    new Ticket { id = 2, row_number = 1, seat_number = 2, session_id = 1, user_id = 1 },
                    new Ticket { id = 3, row_number = 1, seat_number = 3, session_id = 1, user_id = 2 },
                    new Ticket { id = 4, row_number = 1, seat_number = 4, session_id = 1, user_id = 2 },
                    new Ticket { id = 5, row_number = 1, seat_number = 6, session_id = 1, user_id = 2 });
        }
    }
}
