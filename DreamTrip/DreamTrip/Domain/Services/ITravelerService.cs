using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface ITravelerService
{
    Task<IEnumerable<Traveler>> ListAsync();
    Task<TravelerResponse> SaveAsync(Traveler traveler);
    Task<TravelerResponse> UpdateAsync(int travelerId, Traveler traveler);
    Task<TravelerResponse> DeleteAsync(int travelerId);
}