using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IEconomicFollowingService
{
    Task<IEnumerable<EconomicFollowing>> ListAsync();
    Task<IEnumerable<EconomicFollowing>> FindByTravelerIdAsync(int travelerId);
    Task<EconomicFollowingResponse> SaveAsync(EconomicFollowing economicFollowing);
    Task<EconomicFollowingResponse> UpdateAsync(int economicFollowingId, EconomicFollowing economicFollowing);
    Task<EconomicFollowingResponse> DeleteAsync(int economicFollowingId);
}