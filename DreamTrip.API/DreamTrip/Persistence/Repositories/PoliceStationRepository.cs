using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class PoliceStationRepository : BaseRepository, IPoliceStationRepository
{
    public PoliceStationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PoliceStation>> ListAsync()
    {
        return await _context.PoliceStations.ToListAsync();
    }

    public async Task<PoliceStation> FindByIdAsync(int id)
    {
        return await _context.PoliceStations.FindAsync(id);
    }

    public async Task<IEnumerable<PoliceStation>> FindByLocationId(int locationId)
    {
        return await _context.PoliceStations.Where(ps => ps.LocationId == locationId).ToListAsync();
    }
    
    public async Task AddAsync(PoliceStation policeStation)
    {
        await _context.PoliceStations.AddAsync(policeStation);
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
