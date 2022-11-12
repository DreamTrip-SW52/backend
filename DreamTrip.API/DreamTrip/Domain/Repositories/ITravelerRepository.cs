using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface ITravelerRepository
{
    Task<IEnumerable<Traveler>> ListAsync();
    Task AddAsync(Traveler traveler);
    Task<Traveler> FindByIdAsync(int id);
    void Update(Traveler traveler);
    void Remove(Traveler traveler);
}