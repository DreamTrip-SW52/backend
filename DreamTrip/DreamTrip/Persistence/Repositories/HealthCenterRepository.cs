using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.DreamTrip.Persistence.Repositories;

public class HealthCenterRepository : BaseRepository, IHealthCenterRepository
{
    public HealthCenterRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<HealthCenter>> ListAsync()
    {
        return await _context.HealthCenters.ToListAsync();
    }

    public async Task AddAsync(HealthCenter healthCenter)
    {
        await _context.HealthCenters.AddAsync(healthCenter);
    }

    public async Task<HealthCenter> FindByIdAsync(int id)
    {
        return await _context.HealthCenters.FindAsync(id);
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
