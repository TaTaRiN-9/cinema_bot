using cinema.Dtos;
using cinema.Helpers;

namespace cinema.Abstractions.Halls
{
    public interface IHallServices
    {
        Task<Result<List<HallWithDetailsResponse>>> GetAllWithDetails();
        Task<Result<Guid>> AddHall(AddHallRequest addHallRequest);
        Task<Result<Guid>> UpdateHall(UpdateHallRequest request);
        Task<Result<Guid>> DeleteHall(Guid id);
    }
}