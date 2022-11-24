using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class ServiceRepository : BaseRepository, IServiceRepository
{
    public ServiceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Service>> ListAsync()
    {
        return await _context.Services.ToListAsync();
    }

    public async Task AddAsync(Service service)
    {
        await _context.Services.AddAsync(service);
    }

    public async Task<Service> FindByIdAsync(int id)
    {
        return await _context.Services.FindAsync(id);
    }

    public void Update(Service service)
    {
        _context.Services.Update(service);
    }

    public void Remove(Service service)
    {
        _context.Services.Remove(service);
    }
}
