using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IServicesPerAccommodationRepository
{
    Task<IEnumerable<ServicesPerAccommodation>> ListAsync();
    Task AddAsync(ServicesPerAccommodation servicesPerAccommodation);
    Task<ServicesPerAccommodation> FindByIdAsync(int id);
    Task<IEnumerable<ServicesPerAccommodation>> FindByAccommodationId(int accommodationId);
    void Update(ServicesPerAccommodation servicesPerAccommodationRepository);
    void Remove(ServicesPerAccommodation servicesPerAccommodationRepository);
}