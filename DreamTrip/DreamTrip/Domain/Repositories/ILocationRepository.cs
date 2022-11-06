using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> ListAsync();
    Task AddAsync(Location location);
    Task<Location> FindByIdAsync(int id);
    void Update(Location location);
    void Remove(Location location);
}