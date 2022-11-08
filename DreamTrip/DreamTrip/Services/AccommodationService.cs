using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Domain.Services;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Services;

public class AccommodationService : IAccommodationService
{
    private readonly IAccommodationRepository _accommodationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AccommodationService(IAccommodationRepository accommodationRepository, IUnitOfWork unitOfWork)
    {
        _accommodationRepository = accommodationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Accommodation>> ListAsync()
    {
        return await _accommodationRepository.ListAsync();
    }

    public async Task<Accommodation> ListByAccommodationIdAsync(int accommodationId)
    {
        return await _accommodationRepository.FindByIdAsync(accommodationId);
    }

    public async Task<AccommodationResponse> SaveAsync(Accommodation accommodation)
    {
        try
        {
            await _accommodationRepository.AddAsync(accommodation);
            await _unitOfWork.CompleteAsync();
            return new AccommodationResponse(accommodation);
        }
        catch (Exception e)
        {
            return new AccommodationResponse($"An error occurred while saving the accommodation: {e.Message}");
        }
    }

    public async Task<AccommodationResponse> UpdateAsync(int accommodationId, Accommodation accommodation)
    {
        var existingAccommodation = await _accommodationRepository.FindByIdAsync(accommodationId);

        if (existingAccommodation == null)
            return new AccommodationResponse("Accommodation not found.");

        existingAccommodation.Details = accommodation.Details;
				existingAccommodation.CheckIn = accommodation.CheckIn;
				existingAccommodation.CheckOut = accommodation.CheckOut;
				existingAccommodation.Location = accommodation.Location;
				existingAccommodation.Price = accommodation.Price;
				existingAccommodation.PackageId = accommodation.PackageId;

        try
        {
            _accommodationRepository.Update(existingAccommodation);
            await _unitOfWork.CompleteAsync();

            return new AccommodationResponse(existingAccommodation);
        }
        catch (Exception e)
        {
            return new AccommodationResponse($"An error occurred while updating the accommodation: {e.Message}");
        }
    }

    public async Task<AccommodationResponse> DeleteAsync(int accommodationId)
    {
        var existingAccommodation = await _accommodationRepository.FindByIdAsync(accommodationId);

        if (existingAccommodation == null)
            return new AccommodationResponse("Accommodation not found.");

        try
        {
            _accommodationRepository.Remove(existingAccommodation);
            await _unitOfWork.CompleteAsync();

            return new AccommodationResponse(existingAccommodation);

        }
        catch (Exception e)
        {
            // Error Handling
            return new AccommodationResponse($"An error occurred while deleting the accommodation: {e.Message}");
        }

    }
}