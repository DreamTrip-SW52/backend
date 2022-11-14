using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IEconomicFollowingRepository
{
    Task<IEnumerable<EconomicFollowing>> ListAsync();
    Task<EconomicFollowing> FindByIdAsync(int id);
    Task AddAsync(EconomicFollowing economicFollowing);
    void Update(EconomicFollowing economicFollowing);
    void Remove(EconomicFollowing economicFollowing);
}
