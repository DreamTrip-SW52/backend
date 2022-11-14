using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class EconomicFollowingRepository : BaseRepository, IEconomicFollowingRepository
{
    public EconomicFollowingRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<EconomicFollowing>> ListAsync()
    {
        return await _context.EconomicFollowings.ToListAsync();
    }
    
    public async Task<EconomicFollowing> FindByIdAsync(int id)
    {
        return await _context.EconomicFollowings.FindAsync(id);
    }
    public async Task AddAsync(EconomicFollowing economicFollowings)
    {
        await _context.EconomicFollowings.AddAsync(economicFollowings);
    }

    public void Update(EconomicFollowing economicFollowings)
    {
        _context.EconomicFollowings.Update(economicFollowings);
    }

    public void Remove(EconomicFollowing economicFollowings)
    {
        _context.EconomicFollowings.Remove(economicFollowings);
    }
}
