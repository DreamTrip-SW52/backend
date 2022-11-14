using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class EconomicFollowingService : IEconomicFollowingService
{
    private readonly IEconomicFollowingRepository _economicFollowingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EconomicFollowingService(IEconomicFollowingRepository economicFollowingRepository, IUnitOfWork unitOfWork)
    {
        _economicFollowingRepository = economicFollowingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<EconomicFollowing>> ListAsync()
    {
        return await _economicFollowingRepository.ListAsync();
    }
    
    public async Task<EconomicFollowingResponse> SaveAsync(EconomicFollowing economicFollowing)
    {
        try
        {
            await _economicFollowingRepository.AddAsync(economicFollowing);
            await _unitOfWork.CompleteAsync();
            return new EconomicFollowingResponse(economicFollowing);
        }
        catch (Exception e)
        {
            return new EconomicFollowingResponse($"An error occurred while saving the economicFollowing: {e.Message}");
        }
    }

    public async Task<EconomicFollowingResponse> UpdateAsync(int economicFollowingId, EconomicFollowing economicFollowing)
    {
        var existingEconomicFollowing = await _economicFollowingRepository.FindByIdAsync(economicFollowingId);

        if (existingEconomicFollowing == null)
            return new EconomicFollowingResponse("EconomicFollowing not found.");

        existingEconomicFollowing.Name = economicFollowing.Name;
		existingEconomicFollowing.Price = economicFollowing.Price;
		existingEconomicFollowing.TravelerId = economicFollowing.TravelerId;

        try
        {
            _economicFollowingRepository.Update(existingEconomicFollowing);
            await _unitOfWork.CompleteAsync();

            return new EconomicFollowingResponse(existingEconomicFollowing);
        }
        catch (Exception e)
        {
            return new EconomicFollowingResponse($"An error occurred while updating the economicFollowing: {e.Message}");
        }
    }

    public async Task<EconomicFollowingResponse> DeleteAsync(int economicFollowingId)
    {
        var existingEconomicFollowing = await _economicFollowingRepository.FindByIdAsync(economicFollowingId);

        if (existingEconomicFollowing == null)
            return new EconomicFollowingResponse("EconomicFollowing not found.");

        try
        {
            _economicFollowingRepository.Remove(existingEconomicFollowing);
            await _unitOfWork.CompleteAsync();

            return new EconomicFollowingResponse(existingEconomicFollowing);

        }
        catch (Exception e)
        {
            // Error Handling
            return new EconomicFollowingResponse($"An error occurred while deleting the economicFollowing: {e.Message}");
        }

    }
}