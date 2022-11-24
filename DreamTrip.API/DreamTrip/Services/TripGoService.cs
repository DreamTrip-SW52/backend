using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class TripGoService : ITripGoService
{
    private readonly ITripGoRepository _tripGoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TripGoService(ITripGoRepository tripGoRepository, IUnitOfWork unitOfWork)
    {
        _tripGoRepository = tripGoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TripGo>> ListAsync()
    {
        return await _tripGoRepository.ListAsync();
    }

    public async Task<TripGo> FindByIdAsync(int tripGoId)
    {
        return await _tripGoRepository.FindByIdAsync(tripGoId);
    }

    public async Task<TripGoResponse> SaveAsync(TripGo tripGo)
    {
        try
        {
            await _tripGoRepository.AddAsync(tripGo);
            await _unitOfWork.CompleteAsync();
            return new TripGoResponse(tripGo);
        }
        catch (Exception e)
        {
            return new TripGoResponse($"An error occurred while saving the tripGo: {e.Message}");
        }
    }

    public async Task<TripGoResponse> UpdateAsync(int tripGoId, TripGo tripGo)
    {
        var existingTripGo = await _tripGoRepository.FindByIdAsync(tripGoId);

        if (existingTripGo == null)
            return new TripGoResponse("TripGo not found.");

        existingTripGo.LocationId = tripGo.LocationId;

        try
        {
            _tripGoRepository.Update(existingTripGo);
            await _unitOfWork.CompleteAsync();

            return new TripGoResponse(existingTripGo);
        }
        catch (Exception e)
        {
            return new TripGoResponse($"An error occurred while updating the tripGo: {e.Message}");
        }
    }

    public async Task<TripGoResponse> DeleteAsync(int tripGoId)
    {
        var existingTripGo = await _tripGoRepository.FindByIdAsync(tripGoId);

        if (existingTripGo == null)
            return new TripGoResponse("TripGo not found.");

        try
        {
            _tripGoRepository.Remove(existingTripGo);
            await _unitOfWork.CompleteAsync();

            return new TripGoResponse(existingTripGo);

        }
        catch (Exception e)
        {
            // Error Handling
            return new TripGoResponse($"An error occurred while deleting the tripGo: {e.Message}");
        }

    }
}