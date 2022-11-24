using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface ITravelerRepository
{
    Task<IEnumerable<Traveler>> ListAsync();
    Task<Traveler> FindByIdAsync(int id);
    Task<Traveler> FindByEmailAndPassword(string email, string password);
    Task AddAsync(Traveler traveler);
    void Update(Traveler traveler);
    void Remove(Traveler traveler);
}