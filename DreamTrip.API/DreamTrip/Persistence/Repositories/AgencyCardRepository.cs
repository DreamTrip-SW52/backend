using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class AgencyCardRepository : BaseRepository, IAgencyCardRepository
{
    public AgencyCardRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<AgencyCard>> ListAsync()
    {
        return await _context.AgencyCards.ToListAsync();
    }

    public async Task AddAsync(AgencyCard agencyCard)
    {
        await _context.AgencyCards.AddAsync(agencyCard);
    }

    public async Task<AgencyCard> FindByIdAsync(int id)
    {
        return await _context.AgencyCards.FindAsync(id);
    }

    public void Update(AgencyCard agencyCard)
    {
        _context.AgencyCards.Update(agencyCard);
    }

    public void Remove(AgencyCard agencyCard)
    {
        _context.AgencyCards.Remove(agencyCard);
    }
}
