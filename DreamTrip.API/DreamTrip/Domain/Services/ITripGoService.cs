using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface ITripGoService
{
    Task<IEnumerable<TripGo>> ListAsync();
    Task<TripGoResponse> SaveAsync(TripGo tripGo);
    Task<TripGoResponse> UpdateAsync(int tripGoId, TripGo tripGo);
    Task<TripGoResponse> DeleteAsync(int tripGoId);
}