using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IAccommodationRepository
{
    Task<IEnumerable<Accommodation>> ListAsync();
    Task<Accommodation> FindByIdAsync(int id);
    Task<Accommodation> FindByPackageId(int id);
    Task<IEnumerable<Accommodation>> FindByFilters(int priceMin, int priceMax);
    Task AddAsync(Accommodation accommodation);
    void Update(Accommodation accommodation);
    void Remove(Accommodation accommodation);
}
