using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IServicesPerAccommodationService
{
    Task<IEnumerable<ServicesPerAccommodation>> ListAsync();
    Task<ServicesPerAccommodationResponse> SaveAsync(ServicesPerAccommodation servicesPerAccommodation);
    Task<ServicesPerAccommodationResponse> UpdateAsync(int servicesPerAccommodationId, ServicesPerAccommodation servicesPerAccommodation);
    Task<ServicesPerAccommodationResponse> DeleteAsync(int servicesPerAccommodationId);
}