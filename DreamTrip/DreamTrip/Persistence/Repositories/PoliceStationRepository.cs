using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.DreamTrip.Persistence.Repositories;

public class PoliceStationRepository : BaseRepository, IPoliceStationRepository
{
    public PoliceStationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PoliceStation>> ListAsync()
    {
        return await _context.PoliceStations.ToListAsync();
    }

    public async Task AddAsync(PoliceStation policeStation)
    {
        await _context.PoliceStations.AddAsync(policeStation);
    }

    public async Task<PoliceStation> FindByIdAsync(int id)
    {
        return await _context.PoliceStations.FindAsync(id);
    }

    public void Update(PoliceStation policeStation)
    {
        _context.PoliceStations.Update(policeStation);
    }

    public void Remove(PoliceStation policeStation)
    {
        _context.PoliceStations.Remove(policeStation);
    }
}
