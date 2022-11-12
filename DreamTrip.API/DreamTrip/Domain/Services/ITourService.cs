using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface ITourService
{
    Task<IEnumerable<Tour>> ListAsync();
    Task<TourResponse> SaveAsync(Tour tour);
    Task<TourResponse> UpdateAsync(int tourId, Tour tour);
    Task<TourResponse> DeleteAsync(int tourId);
}