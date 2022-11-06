using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface ITripGoService
{
    Task<IEnumerable<TripGo>> ListAsync();
    Task<TripGoResponse> SaveAsync(TripGo tripGo);
    Task<TripGoResponse> UpdateAsync(int tripGoId, TripGo tripGo);
    Task<TripGoResponse> DeleteAsync(int tripGoId);
}