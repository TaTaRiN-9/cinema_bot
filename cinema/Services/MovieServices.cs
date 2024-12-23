using cinema.Abstractions.Movies;
using cinema.Data.Entities;
using cinema.Dtos;
using cinema.Helpers;

namespace cinema.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository _movieRepository;
        public MovieServices(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Result<List<Movie>>> GetAllMovies()
        {
            // Получаем все фильмы из репозитория
            var movies = await _movieRepository.GetAllMovies();

            if (movies == null || !movies.Any())
                return Result<List<Movie>>.Failure("Фильмы не найдены.");

            return Result<List<Movie>>.Success(movies);
        }

        public async Task<Result<Guid>> AddMovie(AddMovieRequest addMovieRequest)
        {
            var movie = Movie.Create(addMovieRequest.Title, addMovieRequest.Description,
                addMovieRequest.Duration, addMovieRequest.PhotoUrl ?? "");

            await _movieRepository.Add(movie);
            return Result<Guid>.Success(movie.id);
        }

        public async Task<Result<Guid>> UpdateMovie(UpdateMovieRequest request)
        {
            var movie = await _movieRepository.GetById(request.Id);
            if (movie == null)
                return Result<Guid>.Failure("Фильм не найден");

            await _movieRepository.Update(request.Title, request.Description,
                request.Duration, request.PhotoUrl ?? "", movie);

            return Result<Guid>.Success(movie.id);
        }

        public async Task<Result<bool>> DeleteMovie(Guid id)
        {
            var movie = await _movieRepository.GetById(id);
            if (movie == null)
                return Result<bool>.Failure("Фильм не найден");

            await _movieRepository.Delete(movie);
            return Result<bool>.Success(true);
        }
    }
}
