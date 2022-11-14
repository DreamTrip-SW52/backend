using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> ListAsync();
    Task<Location> FindByIdAsync(int id);
    Task<Location> FindByDepartment(string department);
    Task AddAsync(Location location);
    void Update(Location location);
    void Remove(Location location);
}