using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Domain.Services;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Services;

public class TravelerCardService : ITravelerCardService
{
    private readonly ITravelerCardRepository _travelerCardRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TravelerCardService(ITravelerCardRepository travelerCardRepository, IUnitOfWork unitOfWork)
    {
        _travelerCardRepository = travelerCardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TravelerCard>> ListAsync()
    {
        return await _travelerCardRepository.ListAsync();
    }

    public async Task<TravelerCard> ListByTravelerCardIdAsync(int travelerCardId)
    {
        return await _travelerCardRepository.FindByIdAsync(travelerCardId);
    }

    public async Task<TravelerCardResponse> SaveAsync(TravelerCard travelerCard)
    {
        try
        {
            await _travelerCardRepository.AddAsync(travelerCard);
            await _unitOfWork.CompleteAsync();
            return new TravelerCardResponse(travelerCard);
        }
        catch (Exception e)
        {
            return new TravelerCardResponse($"An error occurred while saving the travelerCard: {e.Message}");
        }
    }

    public async Task<TravelerCardResponse> UpdateAsync(int travelerCardId, TravelerCard travelerCard)
    {
        var existingTravelerCard = await _travelerCardRepository.FindByIdAsync(travelerCardId);

        if (existingTravelerCard == null)
            return new TravelerCardResponse("TravelerCard not found.");

        existingTravelerCard.HolderName = travelerCard.HolderName;
        existingTravelerCard.CardNumber = travelerCard.CardNumber;
        existingTravelerCard.ExpirationDate = travelerCard.ExpirationDate;
        existingTravelerCard.TravelerId = travelerCard.TravelerId;

        try
        {
            _travelerCardRepository.Update(existingTravelerCard);
            await _unitOfWork.CompleteAsync();

            return new TravelerCardResponse(existingTravelerCard);
        }
        catch (Exception e)
        {
            return new TravelerCardResponse($"An error occurred while updating the travelerCard: {e.Message}");
        }
    }

    public async Task<TravelerCardResponse> DeleteAsync(int travelerCardId)
    {
        var existingTravelerCard = await _travelerCardRepository.FindByIdAsync(travelerCardId);

        if (existingTravelerCard == null)
            return new TravelerCardResponse("TravelerCard not found.");

        try
        {
            _travelerCardRepository.Remove(existingTravelerCard);
            await _unitOfWork.CompleteAsync();

            return new TravelerCardResponse(existingTravelerCard);

        }
        catch (Exception e)
        {
            // Error Handling
            return new TravelerCardResponse($"An error occurred while deleting the travelerCard: {e.Message}");
        }

    }
}