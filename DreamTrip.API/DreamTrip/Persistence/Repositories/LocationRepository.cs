using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class LocationRepository : BaseRepository, ILocationRepository
{
    public LocationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Location>> ListAsync()
    {
        return await _context.Locations.ToListAsync();
    }

    public async Task AddAsync(Location location)
    {
        await _context.Locations.AddAsync(location);
    }

    public async Task<Location> FindByIdAsync(int id)
    {
        return await _context.Locations.FindAsync(id);
    }

    public void Update(Location location)
    {
        _context.Locations.Update(location);
    }

    public void Remove(Location location)
    {
        _context.Locations.Remove(location);
    }
}
