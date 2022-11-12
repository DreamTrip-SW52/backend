using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class AgencyRepository : BaseRepository, IAgencyRepository
{
    public AgencyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Agency>> ListAsync()
    {
        return await _context.Agencies.ToListAsync();
    }

    public async Task AddAsync(Agency agency)
    {
        await _context.Agencies.AddAsync(agency);
    }

    public async Task<Agency> FindByIdAsync(int id)
    {
        return await _context.Agencies.FindAsync(id);
    }

    public void Update(Agency agency)
    {
        _context.Agencies.Update(agency);
    }

    public void Remove(Agency agency)
    {
        _context.Agencies.Remove(agency);
    }
}
