using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.DreamTrip.Persistence.Repositories;

public class RoundTripRepository : BaseRepository, IRoundTripRepository
{
    public RoundTripRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<RoundTrip>> ListAsync()
    {
        return await _context.RoundTrips.ToListAsync();
    }

    public async Task AddAsync(RoundTrip roundTrip)
    {
        await _context.RoundTrips.AddAsync(roundTrip);
    }

    public async Task<RoundTrip> FindByIdAsync(int id)
    {
        return await _context.RoundTrips.FindAsync(id);
    }

    public void Update(RoundTrip roundTrip)
    {
        _context.RoundTrips.Update(roundTrip);
    }

    public void Remove(RoundTrip roundTrip)
    {
        _context.RoundTrips.Remove(roundTrip);
    }
}
