using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface IAgencyRepository
{
    Task<IEnumerable<Agency>> ListAsync();
    Task AddAsync(Agency agency);
    Task<Agency> FindByIdAsync(int id);
    void Update(Agency agency);
    void Remove(Agency agency);
}