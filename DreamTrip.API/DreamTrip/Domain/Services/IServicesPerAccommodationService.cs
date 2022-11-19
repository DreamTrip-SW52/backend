using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IServicesPerAccommodationService
{
    Task<IEnumerable<ServicesPerAccommodation>> ListAsync();
    Task<IEnumerable<ServicesPerAccommodation>> FindByAccommodationIdAsync(int accommodationId);
    Task<ServicesPerAccommodationResponse> SaveAsync(ServicesPerAccommodation servicesPerAccommodation);
    Task<ServicesPerAccommodationResponse> UpdateAsync(int servicesPerAccommodationId, ServicesPerAccommodation servicesPerAccommodation);
    Task<ServicesPerAccommodationResponse> DeleteAsync(int servicesPerAccommodationId);
}