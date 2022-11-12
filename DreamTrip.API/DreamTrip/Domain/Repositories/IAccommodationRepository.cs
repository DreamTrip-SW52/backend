using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IAccommodationRepository
{
    Task<IEnumerable<Accommodation>> ListAsync();
    Task AddAsync(Accommodation accommodation);
    Task<Accommodation> FindByIdAsync(int id);
    void Update(Accommodation accommodation);
    void Remove(Accommodation accommodation);
}
