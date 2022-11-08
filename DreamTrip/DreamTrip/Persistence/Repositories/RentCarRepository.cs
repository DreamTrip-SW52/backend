using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.DreamTrip.Persistence.Repositories;

public class RentCarRepository : BaseRepository, IRentCarRepository
{
    public RentCarRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<RentCar>> ListAsync()
    {
        return await _context.RentCars.ToListAsync();
    }

    public async Task AddAsync(RentCar rentCar)
    {
        await _context.RentCars.AddAsync(rentCar);
    }

    public async Task<RentCar> FindByIdAsync(int id)
    {
        return await _context.RentCars.FindAsync(id);
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
