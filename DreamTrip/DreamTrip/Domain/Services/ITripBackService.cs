using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface ITripBackService
{
    Task<IEnumerable<TripBack>> ListAsync();
    Task<TripBackResponse> SaveAsync(TripBack tripBack);
    Task<TripBackResponse> UpdateAsync(int tripBackId, TripBack tripBack);
    Task<TripBackResponse> DeleteAsync(int tripBackId);
}