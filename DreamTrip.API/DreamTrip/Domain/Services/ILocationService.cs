using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface ILocationService
{
    Task<IEnumerable<Location>> ListAsync();
    Task<Location> FindByDepartmentAsync(string department);
    Task<Location> FindByIdAsync(int id);
    Task<LocationResponse> SaveAsync(Location location);
    Task<LocationResponse> UpdateAsync(int locationId, Location location);
    Task<LocationResponse> DeleteAsync(int locationId);
}