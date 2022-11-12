using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class OneWayRepository : BaseRepository, IOneWayRepository
{
    public OneWayRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<OneWay>> ListAsync()
    {
        return await _context.OneWays.ToListAsync();
    }

    public async Task AddAsync(OneWay oneWay)
    {
        await _context.OneWays.AddAsync(oneWay);
    }

    public async Task<OneWay> FindByIdAsync(int id)
    {
        return await _context.OneWays.FindAsync(id);
    }

    public void Update(OneWay oneWay)
    {
        _context.OneWays.Update(oneWay);
    }

    public void Remove(OneWay oneWay)
    {
        _context.OneWays.Remove(oneWay);
    }
}
