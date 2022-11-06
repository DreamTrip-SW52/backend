using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> ListAsync();
    Task AddAsync(Review review);
    Task<Review> FindByIdAsync(int id);
    void Update(Review review);
    void Remove(Review review);
}