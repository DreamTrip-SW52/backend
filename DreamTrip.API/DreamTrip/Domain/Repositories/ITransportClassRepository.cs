using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface ITransportClassRepository
{
    Task<IEnumerable<TransportClass>> ListAsync();
    Task AddAsync(TransportClass transportClass);
    Task<TransportClass> FindByIdAsync(int id);
    void Update(TransportClass transportClass);
    void Remove(TransportClass transportClass);
}