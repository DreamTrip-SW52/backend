using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.DreamTrip.Persistence.Repositories;

public class AccommodationRepository : BaseRepository, IAccommodationRepository
{
    public AccommodationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Accommodation>> ListAsync()
    {
        return await _context.Accommodations.ToListAsync();
    }

    public async Task AddAsync(Accommodation accommodation)
    {
        await _context.Accommodations.AddAsync(accommodation);
    }

    public async Task<Accommodation> FindByIdAsync(int id)
    {
        return await _context.Accommodations.FindAsync(id);
    }

    public void Update(Accommodation accommodation)
    {
        _context.Accommodations.Update(accommodation);
    }

    public void Remove(Accommodation accommodation)
    {
        _context.Accommodations.Remove(accommodation);
    }
}
