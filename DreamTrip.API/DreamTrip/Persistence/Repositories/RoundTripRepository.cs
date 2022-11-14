using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class RoundTripRepository : BaseRepository, IRoundTripRepository
{
    public RoundTripRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<RoundTrip>> ListAsync()
    {
        return await _context.RoundTrips.ToListAsync();
    }
    
    public async Task<RoundTrip> FindByIdAsync(int id)
    {
        return await _context.RoundTrips.FindAsync(id);
    }

    public async Task<RoundTrip> FindByPackageId(int packageId)
    {
        return await _context.RoundTrips.FirstOrDefaultAsync(x => x.PackageId == packageId);
    }

    public async Task<IEnumerable<RoundTrip>> FindByFilters(string from, string to, 
        DateTime departureDate, DateTime returnDate, string transportClass, string transportType)
    {
        return await _context.RoundTrips.
            Where(rt => rt.TripBack.Location.Department == from &&
                        rt.TripGo.Location.Department == to &&
                        (rt.DepartureDate.Date.CompareTo(departureDate.Date) <= 0) &&
                        (rt.ReturnDate.Date.CompareTo(returnDate.Date) <= 0) &&
                        rt.TransportClass.Name == transportClass &&
                        rt.Transport.Type == transportType).ToListAsync();
    }

    public async Task AddAsync(RoundTrip roundTrip)
    {
        await _context.RoundTrips.AddAsync(roundTrip);
    }

    public void Update(RoundTrip roundTrip)
    {
        _context.RoundTrips.Update(roundTrip);
    }

    public void Remove(RoundTrip roundTrip)
    {
        _context.RoundTrips.Remove(roundTrip);
    }
}
