using cinema.Data.Entities;
using cinema.Helpers;

namespace cinema.Abstractions.Seats
{
    public interface ISeatRepository
    {
        Task<Seat> Create(Seat seat);
        Task<bool> Delete(Guid id);
        Task Update(Seat seat);
        Task<Seat?> GetById(Guid id);
        Task<List<Seat>> GetByRowIdAndFree(Guid row_id);
        Task<List<Seat>> GetSeatsByRowId(Guid row_id);
        Task<List<Seat>> AreSeatsAvailable(List<Guid> seatIds);
        Task UpdateSeatStatus(List<Guid> seat_ids);
    }
}