using cinema.Data.Entities;
using cinema.Dtos;
using cinema.Helpers;

namespace cinema.Abstractions.Movies
{
    public interface IMovieServices
    {
        Task<Result<Guid>> AddMovie(AddMovieRequest addMovieRequest);
        Task<Result<List<Movie>>> GetAllMovies();
        Task<Result<bool>> DeleteMovie(Guid id);
        Task<Result<Guid>> UpdateMovie(UpdateMovieRequest request);
    }
}