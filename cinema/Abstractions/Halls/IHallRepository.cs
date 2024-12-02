using cinema.Data.Entities;

namespace cinema.Abstractions.Halls
{
    public interface IHallRepository
    {
        Task<Hall> Add(Hall hall);
        Task<bool> Delete(Guid id);
        Task<Hall?> GetById(Guid id);
        Task<Hall?> GetByName(string name);
        Task<bool> Update(Hall hall);
        Task<Hall?> GetHallWithDetails(Guid id);
        Task<List<Hall>> GetAllWithDetails();
    }
}