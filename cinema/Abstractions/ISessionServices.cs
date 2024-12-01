using cinema.Dtos;

namespace cinema.Abstractions
{
    public interface ISessionServices
    {
        Task<List<AvailableMovieDto>> GetAvailableMovies(DateTime currentDateTime);
    }
}