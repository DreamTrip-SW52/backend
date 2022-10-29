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
        // Validate Title

        // var existingTutorialWithTitle = await _travelerRepository.FindByTitleAsync(traveler.Title);

        // if (existingTutorialWithTitle != null)
        //     return new TravelerResponse("Tutorial title already exists.");

        // try
        // {
        //     // Add Tutorial
        //     await _travelerRepository.AddAsync(tutorial);
            
        //     // Complete Transaction
        //     await _unitOfWork.CompleteAsync();
            
        //     // Return response
        //     return new TutorialResponse(tutorial);

        // }
        // catch (Exception e)
        // {
        //     // Error Handling
        //     return new TutorialResponse($"An error occurred while saving the tutorial: {e.Message}");
        // }
        return null;
        
    }

    public async Task<TravelerResponse> UpdateAsync(int travelerId, Traveler traveler)
    {
        var existingTraveler = await _travelerRepository.FindByIdAsync(travelerId);
        
        // Validate Traveler

        if (existingTraveler == null)
            return new TravelerResponse("Traveler not found.");

        // Validate Title

        // var existingTutorialWithTitle = await _travelerRepository.FindByTitleAsync(tutorial.Title);

        // if (existingTutorialWithTitle != null && existingTutorialWithTitle.Id != existingTutorial.Id)
        //     return new TutorialResponse("Tutorial title already exists.");
        
        // Modify Fields
        // existingTutorial.Title = tutorial.Title;
        // existingTutorial.Description = tutorial.Description;

        try
        {
            _travelerRepository.Update(existingTraveler);
            await _unitOfWork.CompleteAsync();

            return new TravelerResponse(existingTraveler);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new TravelerResponse($"An error occurred while updating the traveler: {e.Message}");
        }

    }

    public async Task<TravelerResponse> DeleteAsync(int travelerId)
    {
        var existingTraveler = await _travelerRepository.FindByIdAsync(travelerId);
        
        // Validate Traveler

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