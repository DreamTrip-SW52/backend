using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface ITripGoRepository
{
    Task<IEnumerable<TripGo>> ListAsync();
    Task AddAsync(TripGo tripGo);
    Task<TripGo> FindByIdAsync(int id);
    void Update(TripGo tripGo);
    void Remove(TripGo tripGo);
}