using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Domain.Services;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Services;

public class TravelerService : ITravelerService
{
    private readonly ITravelerRepository _travelerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TravelerService(ITravelerRepository travelerRepository, IUnitOfWork unitOfWork)
    {
        _travelerRepository = travelerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Traveler>> ListAsync()
    {
        return await _travelerRepository.ListAsync();
    }

    public async Task<Traveler> ListByTravelerIdAsync(int travelerId)
    {
        return await _travelerRepository.FindByIdAsync(travelerId);
    }

    public async Task<TravelerResponse> SaveAsync(Traveler traveler)
    {
        try
        {
            await _travelerRepository.AddAsync(traveler);
            await _unitOfWork.CompleteAsync();
            return new TravelerResponse(traveler);
        }
        catch (Exception e)
        {
            return new TravelerResponse($"An error occurred while saving the traveler: {e.Message}");
        }
    }

    public async Task<TravelerResponse> UpdateAsync(int travelerId, Traveler traveler)
    {
        var existingTraveler = await _travelerRepository.FindByIdAsync(travelerId);

        if (existingTraveler == null)
            return new TravelerResponse("Traveler not found.");

        // create a new reference of the traveler to update
        existingTraveler.Name = traveler.Name;    
        existingTraveler.Lastname = traveler.Lastname;    
        existingTraveler.Email = traveler.Email;    
        existingTraveler.Password = traveler.Password;    
        existingTraveler.Phone = traveler.Phone;
        existingTraveler.Photo = traveler.Photo;
        existingTraveler.Dni = traveler.Dni;

        try
        {
            _travelerRepository.Update(existingTraveler);
            await _unitOfWork.CompleteAsync();
            
            return new TravelerResponse(existingTraveler);
        }
        catch (Exception e)
        {
            return new TravelerResponse($"An error occurred while updating the traveler: {e.Message}");
        }
    }

    public async Task<TravelerResponse> DeleteAsync(int travelerId)
    {
        var existingTraveler = await _travelerRepository.FindByIdAsync(travelerId);
        
        if (existingTraveler == null)
            return new TravelerResponse("Traveler not found.");
        
        try
        {
            _travelerRepository.Remove(existingTraveler);
            await _unitOfWork.CompleteAsync();

            return new TravelerResponse(existingTraveler);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new TravelerResponse($"An error occurred while deleting the traveler: {e.Message}");
        }

    }
}