using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.DreamTrip.Persistence.Repositories;

public class TourRepository : BaseRepository, ITourRepository
{
    public TourRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Tour>> ListAsync()
    {
        return await _context.Tours.ToListAsync();
    }

    public async Task AddAsync(Tour tour)
    {
        await _context.Tours.AddAsync(tour);
    }

    public async Task<Tour> FindByIdAsync(int id)
    {
        return await _context.Tours.FindAsync(id);
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
