using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> ListAsync();
    Task AddAsync(Service service);
    Task<Service> FindByIdAsync(int id);
    void Update(Service service);
    void Remove(Service service);
}