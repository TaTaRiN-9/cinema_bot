using cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data.Repository
{
    public class MovieRepository
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

        public async Task<bool> Update(Movie movie)
        {
            Movie? movie_updated = await _context.movies.FirstOrDefaultAsync(m => m.id == movie.id);

            if (movie_updated == null) return false;

            movie_updated.title = movie.title;
            movie_updated.description = movie.description;
            movie_updated.duration = movie.duration;
            movie_updated.photo_url = movie.photo_url;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            Movie? movie = await _context.movies.FirstOrDefaultAsync(m => m.id == id);
            if (movie == null) return false;

            _context.movies.Remove(movie);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
