using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface ITransportRepository
{
    Task<IEnumerable<Transport>> ListAsync();
    Task<Transport> FindByIdAsync(int id);
    Task AddAsync(Transport transport);
    void Update(Transport transport);
    void Remove(Transport transport);
}