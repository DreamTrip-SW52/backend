using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.DreamTrip.Persistence.Repositories;

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
