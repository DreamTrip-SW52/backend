using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Domain.Services;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Services;

public class AgencyCardService : IAgencyCardService
{
    private readonly IAgencyCardRepository _agencyCardRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AgencyCardService(IAgencyCardRepository agencyCardRepository, IUnitOfWork unitOfWork)
    {
        _agencyCardRepository = agencyCardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<AgencyCard>> ListAsync()
    {
        return await _agencyCardRepository.ListAsync();
    }

    public async Task<AgencyCard> ListByAgencyCardIdAsync(int agencyCardId)
    {
        return await _agencyCardRepository.FindByIdAsync(agencyCardId);
    }

    public async Task<AgencyCardResponse> SaveAsync(AgencyCard agencyCard)
    {
        try
        {
            await _agencyCardRepository.AddAsync(agencyCard);
            await _unitOfWork.CompleteAsync();
            return new AgencyCardResponse(agencyCard);
        }
        catch (Exception e)
        {
            return new AgencyCardResponse($"An error occurred while saving the agencyCard: {e.Message}");
        }
    }

    public async Task<AgencyCardResponse> UpdateAsync(int agencyCardId, AgencyCard agencyCard)
    {
        var existingAgencyCard = await _agencyCardRepository.FindByIdAsync(agencyCardId);

        if (existingAgencyCard == null)
            return new AgencyCardResponse("AgencyCard not found.");

        existingAgencyCard.HolderName = agencyCard.HolderName;
				existingAgencyCard.CardNumber = agencyCard.CardNumber;
				existingAgencyCard.ExpirationDate = agencyCard.ExpirationDate;
				existingAgencyCard.AgencyId = agencyCard.AgencyId;

        try
        {
            _agencyCardRepository.Update(existingAgencyCard);
            await _unitOfWork.CompleteAsync();

            return new AgencyCardResponse(existingAgencyCard);
        }
        catch (Exception e)
        {
            return new AgencyCardResponse($"An error occurred while updating the agencyCard: {e.Message}");
        }
    }

    public async Task<AgencyCardResponse> DeleteAsync(int agencyCardId)
    {
        var existingAgencyCard = await _agencyCardRepository.FindByIdAsync(agencyCardId);

        if (existingAgencyCard == null)
            return new AgencyCardResponse("AgencyCard not found.");

        try
        {
            _agencyCardRepository.Remove(existingAgencyCard);
            await _unitOfWork.CompleteAsync();

            return new AgencyCardResponse(existingAgencyCard);

        }
        catch (Exception e)
        {
            // Error Handling
            return new AgencyCardResponse($"An error occurred while deleting the agencyCard: {e.Message}");
        }

    }
}