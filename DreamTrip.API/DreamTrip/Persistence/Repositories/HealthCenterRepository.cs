using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class HealthCenterRepository : BaseRepository, IHealthCenterRepository
{
    public HealthCenterRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<HealthCenter>> ListAsync()
    {
        return await _context.HealthCenters.ToListAsync();
    }

    public async Task<HealthCenter> FindByIdAsync(int id)
    {
        return await _context.HealthCenters.FindAsync(id);
    }

    public async Task<IEnumerable<HealthCenter>> FindByTypeAndLocationId(string type, int locationId)
    {
        return await _context.HealthCenters.
            Where(hc => hc.Type == type && hc.LocationId == locationId).ToListAsync();
    }

    public async Task AddAsync(HealthCenter healthCenter)
    {
        await _context.HealthCenters.AddAsync(healthCenter);
    }

    public void Update(HealthCenter healthCenter)
    {
        _context.HealthCenters.Update(healthCenter);
    }

    public void Remove(HealthCenter healthCenter)
    {
        _context.HealthCenters.Remove(healthCenter);
    }
}
