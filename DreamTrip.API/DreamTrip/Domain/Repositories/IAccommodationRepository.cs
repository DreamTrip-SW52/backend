using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IAccommodationRepository
{
    Task<IEnumerable<Accommodation>> ListAsync();
    Task<Accommodation> FindByIdAsync(int id);
    Task<Accommodation> FindByPackageId(int id);    
    Task AddAsync(Accommodation accommodation);
    void Update(Accommodation accommodation);
    void Remove(Accommodation accommodation);
}
