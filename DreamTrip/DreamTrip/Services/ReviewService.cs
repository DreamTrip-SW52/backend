﻿using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Domain.Services;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Review>> ListAsync()
    {
        return await _reviewRepository.ListAsync();
    }

    public async Task<Review> ListByReviewIdAsync(int reviewId)
    {
        return await _reviewRepository.FindByIdAsync(reviewId);
    }

    public async Task<ReviewResponse> SaveAsync(Review review)
    {
        try
        {
            await _reviewRepository.AddAsync(review);
            await _unitOfWork.CompleteAsync();
            return new ReviewResponse(review);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while saving the review: {e.Message}");
        }
    }

    public async Task<ReviewResponse> UpdateAsync(int reviewId, Review review)
    {
        var existingReview = await _reviewRepository.FindByIdAsync(reviewId);

        if (existingReview == null)
            return new ReviewResponse("Review not found.");

        existingReview.Comment = review.Comment;
				existingReview.Stars = review.Stars;
				existingReview.PackageId = review.PackageId;
				existingReview.TravelerId = review.TravelerId;

        try
        {
            _reviewRepository.Update(existingReview);
            await _unitOfWork.CompleteAsync();

            return new ReviewResponse(existingReview);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while updating the review: {e.Message}");
        }
    }

    public async Task<ReviewResponse> DeleteAsync(int reviewId)
    {
        var existingReview = await _reviewRepository.FindByIdAsync(reviewId);

        if (existingReview == null)
            return new ReviewResponse("Review not found.");

        try
        {
            _reviewRepository.Remove(existingReview);
            await _unitOfWork.CompleteAsync();

            return new ReviewResponse(existingReview);

        }
        catch (Exception e)
        {
            // Error Handling
            return new ReviewResponse($"An error occurred while deleting the review: {e.Message}");
        }

    }
}