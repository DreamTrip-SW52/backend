using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.DreamTrip.Persistence.Repositories;

public class TripGoRepository : BaseRepository, ITripGoRepository
{
    public TripGoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TripGo>> ListAsync()
    {
        return await _context.TripsGo.ToListAsync();
    }

    public async Task AddAsync(TripGo tripGo)
    {
        await _context.TripsGo.AddAsync(tripGo);
    }

    public async Task<TripGo> FindByIdAsync(int id)
    {
        return await _context.TripsGo.FindAsync(id);
    }

    public void Update(TripGo tripGo)
    {
        _context.TripsGo.Update(tripGo);
    }

    public void Remove(TripGo tripGo)
    {
        _context.TripsGo.Remove(tripGo);
    }
}
