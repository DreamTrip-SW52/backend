using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IAccommodationService
{
    Task<IEnumerable<Accommodation>> ListAsync();
    Task<AccommodationResponse> SaveAsync(Accommodation accommodation);
    Task<AccommodationResponse> UpdateAsync(int accommodationId, Accommodation accommodation);
    Task<AccommodationResponse> DeleteAsync(int accommodationId);
}