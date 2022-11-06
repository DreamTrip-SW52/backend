using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface ITripGoRepository
{
    Task<IEnumerable<TripGo>> ListAsync();
    Task AddAsync(TripGo tripGo);
    Task<TripGo> FindByIdAsync(int id);
    void Update(TripGo tripGo);
    void Remove(TripGo tripGo);
}