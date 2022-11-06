using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface ILocationService
{
    Task<IEnumerable<Location>> ListAsync();
    Task<LocationResponse> SaveAsync(Location location);
    Task<LocationResponse> UpdateAsync(int locationId, Location location);
    Task<LocationResponse> DeleteAsync(int locationId);
}