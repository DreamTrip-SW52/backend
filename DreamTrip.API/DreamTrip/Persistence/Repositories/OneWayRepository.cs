using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class OneWayRepository : BaseRepository, IOneWayRepository
{
    public OneWayRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<OneWay>> ListAsync()
    {
        return await _context.OneWays.ToListAsync();
    }

    public async Task<OneWay> FindByIdAsync(int id)
    {
        return await _context.OneWays.FindAsync(id);
    }

    public async Task<OneWay> FindByPackageId(int packageId)
    {
        return await _context.OneWays.FirstOrDefaultAsync(ow => ow.PackageId == packageId);
    }
    
    public async Task<IEnumerable<OneWay>> FindByFilters(string to, 
        DateTime departureDate, DateTime returnDate, string transportClass, string transportType)
    {
        return await _context.OneWays.
            Where(ow => ow.TripGo.Location.Department == to &&
                        (ow.DepartureDate.Date.CompareTo(departureDate.Date) <= 0) &&
                        (ow.ReturnDate.Date.CompareTo(returnDate.Date) >= 0) &&
                        ow.TransportClass.Name == transportClass &&
                        ow.Transport.Type == transportType).ToListAsync();
    }
    
    public async Task AddAsync(OneWay oneWay)
    {
        await _context.OneWays.AddAsync(oneWay);
    }

    public void Update(OneWay oneWay)
    {
        _context.OneWays.Update(oneWay);
    }

    public void Remove(OneWay oneWay)
    {
        _context.OneWays.Remove(oneWay);
    }
}
