using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class ServicesPerAccommodationService : IServicesPerAccommodationService
{
    private readonly IServicesPerAccommodationRepository _servicesPerAccommodationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ServicesPerAccommodationService(IServicesPerAccommodationRepository servicesPerAccommodationRepository, IUnitOfWork unitOfWork)
    {
        _servicesPerAccommodationRepository = servicesPerAccommodationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ServicesPerAccommodation>> ListAsync()
    {
        return await _servicesPerAccommodationRepository.ListAsync();
    }
    
    public async Task<IEnumerable<ServicesPerAccommodation>> FindByAccommodationIdAsync(int accommodationId)
    {
        return await _servicesPerAccommodationRepository.FindByAccommodationId(accommodationId);
    }

    public async Task<ServicesPerAccommodation> ListByServicesPerAccommodationIdAsync(int servicesPerAccommodationId)
    {
        return await _servicesPerAccommodationRepository.FindByIdAsync(servicesPerAccommodationId);
    }

    public async Task<ServicesPerAccommodationResponse> SaveAsync(ServicesPerAccommodation servicesPerAccommodation)
    {
        try
        {
            await _servicesPerAccommodationRepository.AddAsync(servicesPerAccommodation);
            await _unitOfWork.CompleteAsync();
            return new ServicesPerAccommodationResponse(servicesPerAccommodation);
        }
        catch (Exception e)
        {
            return new ServicesPerAccommodationResponse($"An error occurred while saving the servicesPerAccommodation: {e.Message}");
        }
    }

    public async Task<ServicesPerAccommodationResponse> UpdateAsync(int servicesPerAccommodationId, ServicesPerAccommodation servicesPerAccommodation)
    {
        var existingServicesPerAccommodation = await _servicesPerAccommodationRepository.FindByIdAsync(servicesPerAccommodationId);

        if (existingServicesPerAccommodation == null)
            return new ServicesPerAccommodationResponse("ServicesPerAccommodation not found.");

        existingServicesPerAccommodation.ServiceId = servicesPerAccommodation.ServiceId;
        existingServicesPerAccommodation.AccommodationId = servicesPerAccommodation.AccommodationId;

        try
        {
            _servicesPerAccommodationRepository.Update(existingServicesPerAccommodation);
            await _unitOfWork.CompleteAsync();

            return new ServicesPerAccommodationResponse(existingServicesPerAccommodation);
        }
        catch (Exception e)
        {
            return new ServicesPerAccommodationResponse($"An error occurred while updating the servicesPerAccommodation: {e.Message}");
        }
    }

    public async Task<ServicesPerAccommodationResponse> DeleteAsync(int servicesPerAccommodationId)
    {
        var existingServicesPerAccommodation = await _servicesPerAccommodationRepository.FindByIdAsync(servicesPerAccommodationId);

        if (existingServicesPerAccommodation == null)
            return new ServicesPerAccommodationResponse("ServicesPerAccommodation not found.");

        try
        {
            _servicesPerAccommodationRepository.Remove(existingServicesPerAccommodation);
            await _unitOfWork.CompleteAsync();

            return new ServicesPerAccommodationResponse(existingServicesPerAccommodation);

        }
        catch (Exception e)
        {
            // Error Handling
            return new ServicesPerAccommodationResponse($"An error occurred while deleting the servicesPerAccommodation: {e.Message}");
        }

    }
}