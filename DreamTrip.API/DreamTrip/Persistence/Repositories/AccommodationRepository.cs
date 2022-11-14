using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class AccommodationRepository : BaseRepository, IAccommodationRepository
{
    public AccommodationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Accommodation>> ListAsync()
    {
        return await _context.Accommodations.ToListAsync();
    }
    
    public async Task<Accommodation> FindByIdAsync(int id)
    {
        return await _context.Accommodations.FindAsync(id);
    }

    public async Task<Accommodation> FindByPackageId(int packageId)
    {
        return await  _context.Accommodations.FirstOrDefaultAsync(x => x.PackageId == packageId);
    }

    public async Task<IEnumerable<Accommodation>> FindByFilters(int priceMin, int priceMax)
    {
        return await _context.Accommodations
            .Where(x => x.Price >= priceMin && x.Price <= priceMax).ToListAsync();
    }

    public async Task AddAsync(Accommodation accommodation)
    {
        await _context.Accommodations.AddAsync(accommodation);
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
