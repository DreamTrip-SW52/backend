using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class TourRepository : BaseRepository, ITourRepository
{
    public TourRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Tour>> ListAsync()
    {
        return await _context.Tours.ToListAsync();
    }

    public async Task<Tour> FindByIdAsync(int id)
    {
        return await _context.Tours.FindAsync(id);
    }

    public async Task<Tour> FindByPackageId(int packageId)
    {
        return await _context.Tours.FirstOrDefaultAsync(t => t.PackageId == packageId);
    }

    public async Task<IEnumerable<Tour>> FindByLocationId(int locationId)
    {
        return await _context.Tours.Where(t => t.Package.LocationId == locationId).ToListAsync();
    }

    public async Task AddAsync(Tour tour)
    {
        await _context.Tours.AddAsync(tour);
    }

    public void Update(Tour tour)
    {
        _context.Tours.Update(tour);
    }

    public void Remove(Tour tour)
    {
        _context.Tours.Remove(tour);
    }
}
