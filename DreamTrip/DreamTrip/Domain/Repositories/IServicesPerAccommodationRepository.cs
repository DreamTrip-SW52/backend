using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface IServicesPerAccommodationRepository
{
    Task<IEnumerable<ServicesPerAccommodation>> ListAsync();
    Task AddAsync(ServicesPerAccommodation servicesPerAccommodation);
    Task<ServicesPerAccommodation> FindByIdAsync(int id);
    void Update(ServicesPerAccommodation servicesPerAccommodationRepository);
    void Remove(ServicesPerAccommodation servicesPerAccommodationRepository);
}