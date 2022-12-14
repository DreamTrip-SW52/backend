using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

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
