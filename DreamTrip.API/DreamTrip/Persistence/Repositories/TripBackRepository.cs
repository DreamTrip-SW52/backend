using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class TripBackRepository : BaseRepository, ITripBackRepository
{
    public TripBackRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TripBack>> ListAsync()
    {
        return await _context.TripsBack.ToListAsync();
    }

    public async Task AddAsync(TripBack tripBack)
    {
        await _context.TripsBack.AddAsync(tripBack);
    }

    public async Task<TripBack> FindByIdAsync(int id)
    {
        return await _context.TripsBack.FindAsync(id);
    }

    public void Update(TripBack tripBack)
    {
        _context.TripsBack.Update(tripBack);
    }

    public void Remove(TripBack tripBack)
    {
        _context.TripsBack.Remove(tripBack);
    }
}
