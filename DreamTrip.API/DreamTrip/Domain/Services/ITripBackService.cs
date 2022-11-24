using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface ITripBackService
{
    Task<IEnumerable<TripBack>> ListAsync();
    Task<TripBack> FindByIdAsync(int id);
    Task<TripBackResponse> SaveAsync(TripBack tripBack);
    Task<TripBackResponse> UpdateAsync(int tripBackId, TripBack tripBack);
    Task<TripBackResponse> DeleteAsync(int tripBackId);
}