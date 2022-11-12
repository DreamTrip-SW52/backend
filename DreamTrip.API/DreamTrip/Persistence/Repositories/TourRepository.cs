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
