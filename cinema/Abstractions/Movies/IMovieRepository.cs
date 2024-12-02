using cinema.Data.Entities;

namespace cinema.Abstractions.Movies
{
    public interface IMovieRepository
    {
        Task<Movie> Add(Movie movie);
        Task Delete(Movie movie);
        Task<List<Movie>> GetAllMovies();
        Task<Movie?> GetById(Guid id);
        Task<Movie?> GetByTitle(string title);
        Task<bool> Update(string title, string description,
                int duration, string photo_url, Movie movie_updated);
    }
}