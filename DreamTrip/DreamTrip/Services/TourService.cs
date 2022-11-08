using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Domain.Services;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Services;

public class TourService : ITourService
{
    private readonly ITourRepository _tourRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TourService(ITourRepository tourRepository, IUnitOfWork unitOfWork)
    {
        _tourRepository = tourRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Tour>> ListAsync()
    {
        return await _tourRepository.ListAsync();
    }

    public async Task<Tour> ListByTourIdAsync(int tourId)
    {
        return await _tourRepository.FindByIdAsync(tourId);
    }

    public async Task<TourResponse> SaveAsync(Tour tour)
    {
        try
        {
            await _tourRepository.AddAsync(tour);
            await _unitOfWork.CompleteAsync();
            return new TourResponse(tour);
        }
        catch (Exception e)
        {
            return new TourResponse($"An error occurred while saving the tour: {e.Message}");
        }
    }

    public async Task<TourResponse> UpdateAsync(int tourId, Tour tour)
    {
        var existingTour = await _tourRepository.FindByIdAsync(tourId);

        if (existingTour == null)
            return new TourResponse("Tour not found.");

        existingTour.Details = tour.Details;
        existingTour.Location = tour.Location;
        existingTour.MeetingPoint = tour.MeetingPoint;
        existingTour.Price = tour.Price;
        existingTour.PackageId = tour.PackageId;

        try
        {
            _tourRepository.Update(existingTour);
            await _unitOfWork.CompleteAsync();

            return new TourResponse(existingTour);
        }
        catch (Exception e)
        {
            return new TourResponse($"An error occurred while updating the tour: {e.Message}");
        }
    }

    public async Task<TourResponse> DeleteAsync(int tourId)
    {
        var existingTour = await _tourRepository.FindByIdAsync(tourId);

        if (existingTour == null)
            return new TourResponse("Tour not found.");

        try
        {
            _tourRepository.Remove(existingTour);
            await _unitOfWork.CompleteAsync();

            return new TourResponse(existingTour);

        }
        catch (Exception e)
        {
            // Error Handling
            return new TourResponse($"An error occurred while deleting the tour: {e.Message}");
        }

    }
}