using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class TransportRepository : BaseRepository, ITransportRepository
{
    public TransportRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Transport>> ListAsync()
    {
        return await _context.Transports.ToListAsync();
    }

    public async Task AddAsync(Transport transport)
    {
        await _context.Transports.AddAsync(transport);
    }

    public async Task<Transport> FindByIdAsync(int id)
    {
        return await _context.Transports.FindAsync(id);
    }

    public void Update(Transport transport)
    {
        _context.Transports.Update(transport);
    }

    public void Remove(Transport transport)
    {
        _context.Transports.Remove(transport);
    }
}
