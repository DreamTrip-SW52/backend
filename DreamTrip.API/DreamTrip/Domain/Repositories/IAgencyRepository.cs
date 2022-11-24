using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IAgencyRepository
{
    Task<IEnumerable<Agency>> ListAsync();
    Task<Agency> FindByIdAsync(int id);
    Task<Agency> FindByEmailAndPassword(string email, string password);
    Task AddAsync(Agency agency);
    void Update(Agency agency);
    void Remove(Agency agency);
}