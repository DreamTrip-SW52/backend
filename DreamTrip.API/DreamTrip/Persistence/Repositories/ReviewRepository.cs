using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class ReviewRepository : BaseRepository, IReviewRepository
{
    public ReviewRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Review>> ListAsync()
    {
        return await _context.Reviews.ToListAsync();
    }
    
    public async Task<Review> FindByIdAsync(int id)
    {
        return await _context.Reviews.FindAsync(id);
    }
    
    public async Task<Review> FindByPackageIdAndTravelerId(int packageId, int travelerId)
    {
        return await _context.Reviews.FirstOrDefaultAsync(
            r => r.TravelerId == travelerId && r.PackageId == packageId);
    }

    public async Task<IEnumerable<Review>> FindByPackageId(int packageId)
    {
        return await _context.Reviews.Where(r => r.PackageId == packageId).ToListAsync();
    }

    public async Task AddAsync(Review reviews)
    {
        await _context.Reviews.AddAsync(reviews);
    }

    public void Update(Review reviews)
    {
        _context.Reviews.Update(reviews);
    }

    public void Remove(Review reviews)
    {
        _context.Reviews.Remove(reviews);
    }
}
