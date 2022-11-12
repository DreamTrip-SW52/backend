using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class TransportClassRepository : BaseRepository, ITransportClassRepository
{
    public TransportClassRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TransportClass>> ListAsync()
    {
        return await _context.TransportClasses.ToListAsync();
    }

    public async Task AddAsync(TransportClass transportClass)
    {
        await _context.TransportClasses.AddAsync(transportClass);
    }

    public async Task<TransportClass> FindByIdAsync(int id)
    {
        return await _context.TransportClasses.FindAsync(id);
    }

    public void Update(TransportClass transportClass)
    {
        _context.TransportClasses.Update(transportClass);
    }

    public void Remove(TransportClass transportClass)
    {
        _context.TransportClasses.Remove(transportClass);
    }
}
