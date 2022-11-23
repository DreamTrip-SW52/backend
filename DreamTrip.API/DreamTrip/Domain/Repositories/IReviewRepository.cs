using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> ListAsync();
    Task<Review> FindByIdAsync(int id);
    Task<Review> FindByTravelerId(int travelerId);
    Task<IEnumerable<Review>> FindByPackageId(int packageId);
    Task<Review> FindByPackageIdAndTravelerId(int packageId, int travelerId);
    Task AddAsync(Review review);
    void Update(Review review);
    void Remove(Review review);
}