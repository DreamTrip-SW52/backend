using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface ITravelerService
{
    Task<IEnumerable<Traveler>> ListAsync();
    Task<Traveler> FindByIdAsync(int id);
    Task<Traveler> FindByEmailAndPasswordAsync(string email, string password);
    Task<TravelerResponse> SaveAsync(Traveler traveler);
    Task<TravelerResponse> UpdateAsync(int travelerId, Traveler traveler);
    Task<TravelerResponse> DeleteAsync(int travelerId);
}