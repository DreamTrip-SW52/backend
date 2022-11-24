using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface ITripBackRepository
{
    Task<IEnumerable<TripBack>> ListAsync();
    Task AddAsync(TripBack tripBack);
    Task<TripBack> FindByIdAsync(int id);
    void Update(TripBack tripBack);
    void Remove(TripBack tripBack);
}