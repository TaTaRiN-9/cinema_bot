using cinema.Abstractions.Movies;
using cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext _context;
        public MovieRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> Add(Movie movie)
        {
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _context.movies.ToListAsync();
        }

        public async Task<Movie?> GetById(Guid id)
        {
            return await _context.movies.FirstOrDefaultAsync(m => m.id == id);
        }

        public async Task<Movie?> GetByTitle(string title)
        {
            return await _context.movies.FirstOrDefaultAsync(m => m.title == title);
        }

        public async Task<bool> Update(string title, string description,
                int duration, string photo_url, Movie movie_updated)
        {
            movie_updated.title = title;
            movie_updated.description = description;
            movie_updated.duration = duration;
            movie_updated.photo_url = photo_url;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task Delete(Movie movie)
        {
            _context.movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
