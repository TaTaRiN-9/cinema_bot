using cinema.Data.Entities;

namespace cinema.Abstractions
{
    public interface ISeatRepository
    {
        Task<Seat> Create(Seat seat);
        Task<bool> Delete(Guid id);
        Task Update(Seat seat);
        Task<Seat?> GetById(Guid id);
        Task<List<Seat>> GetByRowIdAndFree(Guid row_id);
        Task<List<Seat>> GetSeatsByRowId(Guid row_id);
    }
}