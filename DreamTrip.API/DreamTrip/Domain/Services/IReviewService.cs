using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IReviewService
{
    Task<IEnumerable<Review>> ListAsync();
    Task<Review> FindByPackageIdAndTravelerIdAsync(int packageId, int travelerId);
    Task<IEnumerable<Review>> FindByPackageIdAsync(int id);
    Task<ReviewResponse> SaveAsync(Review review);
    Task<ReviewResponse> UpdateAsync(int reviewId, Review review);
    Task<ReviewResponse> DeleteAsync(int reviewId);
}