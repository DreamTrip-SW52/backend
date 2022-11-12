using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class TripBackService : ITripBackService
{
    private readonly ITripBackRepository _tripBackRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TripBackService(ITripBackRepository tripBackRepository, IUnitOfWork unitOfWork)
    {
        _tripBackRepository = tripBackRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TripBack>> ListAsync()
    {
        return await _tripBackRepository.ListAsync();
    }

    public async Task<TripBack> ListByTripBackIdAsync(int tripBackId)
    {
        return await _tripBackRepository.FindByIdAsync(tripBackId);
    }

    public async Task<TripBackResponse> SaveAsync(TripBack tripBack)
    {
        try
        {
            await _tripBackRepository.AddAsync(tripBack);
            await _unitOfWork.CompleteAsync();
            return new TripBackResponse(tripBack);
        }
        catch (Exception e)
        {
            return new TripBackResponse($"An error occurred while saving the tripBack: {e.Message}");
        }
    }

    public async Task<TripBackResponse> UpdateAsync(int tripBackId, TripBack tripBack)
    {
        var existingTripBack = await _tripBackRepository.FindByIdAsync(tripBackId);

        if (existingTripBack == null)
            return new TripBackResponse("TripBack not found.");

        existingTripBack.LocationId = tripBack.LocationId;

        try
        {
            _tripBackRepository.Update(existingTripBack);
            await _unitOfWork.CompleteAsync();

            return new TripBackResponse(existingTripBack);
        }
        catch (Exception e)
        {
            return new TripBackResponse($"An error occurred while updating the tripBack: {e.Message}");
        }
    }

    public async Task<TripBackResponse> DeleteAsync(int tripBackId)
    {
        var existingTripBack = await _tripBackRepository.FindByIdAsync(tripBackId);

        if (existingTripBack == null)
            return new TripBackResponse("TripBack not found.");

        try
        {
            _tripBackRepository.Remove(existingTripBack);
            await _unitOfWork.CompleteAsync();

            return new TripBackResponse(existingTripBack);

        }
        catch (Exception e)
        {
            // Error Handling
            return new TripBackResponse($"An error occurred while deleting the tripBack: {e.Message}");
        }

    }
}