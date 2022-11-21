using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class RentCarRepository : BaseRepository, IRentCarRepository
{
    public RentCarRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<RentCar>> ListAsync()
    {
        return await _context.RentCars.ToListAsync();
    }

    public async Task<RentCar> FindByIdAsync(int id)
    {
        return await _context.RentCars.FindAsync(id);
    }

    public async Task<IEnumerable<RentCar>> FindByFilters(int locationId, int priceMin, int priceMax,
        int capacityMin, int capacityMax, string brand)
    {
        return await _context.RentCars.
            Where(x => x.Package.LocationId == locationId &&
                       x.Price >= priceMin && x.Price <= priceMax &&
                       x.Capacity >= capacityMin && x.Capacity <= capacityMax &&
                       x.Brand == brand).ToListAsync();
    }

    public async Task AddAsync(RentCar rentCar)
    {
        await _context.RentCars.AddAsync(rentCar);
    }

    public void Update(RentCar rentCar)
    {
        _context.RentCars.Update(rentCar);
    }

    public void Remove(RentCar rentCar)
    {
        _context.RentCars.Remove(rentCar);
    }
}
