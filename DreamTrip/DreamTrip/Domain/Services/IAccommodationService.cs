using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IAccommodationService
{
    Task<IEnumerable<Accommodation>> ListAsync();
    Task<AccommodationResponse> SaveAsync(Accommodation accommodation);
    Task<AccommodationResponse> UpdateAsync(int accommodationId, Accommodation accommodation);
    Task<AccommodationResponse> DeleteAsync(int accommodationId);
}