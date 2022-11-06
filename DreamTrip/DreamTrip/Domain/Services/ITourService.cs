using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface ITourService
{
    Task<IEnumerable<Tour>> ListAsync();
    Task<TourResponse> SaveAsync(Tour tour);
    Task<TourResponse> UpdateAsync(int tourId, Tour tour);
    Task<TourResponse> DeleteAsync(int tourId);
}