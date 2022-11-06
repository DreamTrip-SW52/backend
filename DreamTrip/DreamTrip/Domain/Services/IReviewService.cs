using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IReviewService
{
    Task<IEnumerable<Review>> ListAsync();
    Task<ReviewResponse> SaveAsync(Review review);
    Task<ReviewResponse> UpdateAsync(int reviewId, Review review);
    Task<ReviewResponse> DeleteAsync(int reviewId);
}