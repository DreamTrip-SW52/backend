using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.DreamTrip.Persistence.Repositories;

public class TravelerRepository : BaseRepository, ITravelerRepository
{
    public TravelerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Traveler>> ListAsync()
    {
        return await _context.Travelers.ToListAsync();
    }

    public async Task AddAsync(Traveler traveler)
    {
        await _context.Travelers.AddAsync(traveler);
    }

    public async Task<Traveler> FindByIdAsync(int id)
    {
        return await _context.Travelers.FindAsync(id);
    }

    public void Update(Traveler traveler)
    {
        _context.Travelers.Update(traveler);
    }

    public void Remove(Traveler traveler)
    {
        _context.Travelers.Remove(traveler);
    }
}
