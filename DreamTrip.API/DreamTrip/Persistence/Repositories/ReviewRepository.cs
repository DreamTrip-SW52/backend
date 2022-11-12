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

    public async Task AddAsync(Review reviews)
    {
        await _context.Reviews.AddAsync(reviews);
    }

    public async Task<Review> FindByIdAsync(int id)
    {
        return await _context.Reviews.FindAsync(id);
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
