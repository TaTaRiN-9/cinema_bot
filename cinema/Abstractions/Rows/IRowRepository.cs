using cinema.Data.Entities;

namespace cinema.Abstractions.Rows
{
    public interface IRowRepository
    {
        Task<Row> Create(Row row);
        Task<bool> Delete(Guid id);
        Task<List<Row>> GetByHallId(Guid hall_id);
        Task<Row?> GetByNumber(int number);
    }
}