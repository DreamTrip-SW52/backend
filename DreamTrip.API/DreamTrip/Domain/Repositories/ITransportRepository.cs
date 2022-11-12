using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface ITransportRepository
{
    Task<IEnumerable<Transport>> ListAsync();
    Task AddAsync(Transport transport);
    Task<Transport> FindByIdAsync(int id);
    void Update(Transport transport);
    void Remove(Transport transport);
}