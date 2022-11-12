using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class TravelerCardRepository : BaseRepository, ITravelerCardRepository
{
    public TravelerCardRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TravelerCard>> ListAsync()
    {
        return await _context.TravelerCards.ToListAsync();
    }

    public async Task AddAsync(TravelerCard travelerCard)
    {
        await _context.TravelerCards.AddAsync(travelerCard);
    }

    public async Task<TravelerCard> FindByIdAsync(int id)
    {
        return await _context.TravelerCards.FindAsync(id);
    }

    public void Update(TravelerCard travelerCard)
    {
        _context.TravelerCards.Update(travelerCard);
    }

    public void Remove(TravelerCard travelerCard)
    {
        _context.TravelerCards.Remove(travelerCard);
    }
}
