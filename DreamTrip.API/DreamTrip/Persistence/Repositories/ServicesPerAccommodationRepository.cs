using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class ServicesPerAccommodationRepository : BaseRepository, IServicesPerAccommodationRepository
{
    public ServicesPerAccommodationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ServicesPerAccommodation>> ListAsync()
    {
        return await _context.ServicesPerAccommodations.ToListAsync();
    }

    public async Task AddAsync(ServicesPerAccommodation ServicesPerAccommodation)
    {
        await _context.ServicesPerAccommodations.AddAsync(ServicesPerAccommodation);
    }

    public async Task<ServicesPerAccommodation> FindByIdAsync(int id)
    {
        return await _context.ServicesPerAccommodations.FindAsync(id);
    }

    public void Update(ServicesPerAccommodation ServicesPerAccommodation)
    {
        _context.ServicesPerAccommodations.Update(ServicesPerAccommodation);
    }

    public void Remove(ServicesPerAccommodation ServicesPerAccommodation)
    {
        _context.ServicesPerAccommodations.Remove(ServicesPerAccommodation);
    }
}
