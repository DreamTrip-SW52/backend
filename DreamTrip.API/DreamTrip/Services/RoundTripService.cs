using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class RoundTripService : IRoundTripService
{
    private readonly IRoundTripRepository _roundTripRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoundTripService(IRoundTripRepository roundTripRepository, IUnitOfWork unitOfWork)
    {
        _roundTripRepository = roundTripRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RoundTrip>> ListAsync()
    {
        return await _roundTripRepository.ListAsync();
    }

    public async Task<RoundTrip> FindByPackageIdAsync(int packageId)
    {
        return await _roundTripRepository.FindByPackageId(packageId);
    }

    public async Task<RoundTripResponse> SaveAsync(RoundTrip roundTrip)
    {
        try
        {
            await _roundTripRepository.AddAsync(roundTrip);
            await _unitOfWork.CompleteAsync();
            return new RoundTripResponse(roundTrip);
        }
        catch (Exception e)
        {
            return new RoundTripResponse($"An error occurred while saving the roundTrip: {e.Message}");
        }
    }

    public async Task<RoundTripResponse> UpdateAsync(int roundTripId, RoundTrip roundTrip)
    {
        var existingRoundTrip = await _roundTripRepository.FindByIdAsync(roundTripId);

        if (existingRoundTrip == null)
            return new RoundTripResponse("RoundTrip not found.");

        existingRoundTrip.DepartureDate = roundTrip.DepartureDate;
        existingRoundTrip.ReturnDate = roundTrip.ReturnDate;
        existingRoundTrip.Price = roundTrip.Price;
        existingRoundTrip.TransportClassId = roundTrip.TransportClassId;
        existingRoundTrip.TripGoId = roundTrip.TripGoId;
        existingRoundTrip.TripBackId = roundTrip.TripBackId;
        existingRoundTrip.PackageId = roundTrip.PackageId;
        existingRoundTrip.TransportId = roundTrip.TransportId;

        try
        {
            _roundTripRepository.Update(existingRoundTrip);
            await _unitOfWork.CompleteAsync();
            
            return new RoundTripResponse(existingRoundTrip);
        }
        catch (Exception e)
        {
            return new RoundTripResponse($"An error occurred while updating the roundTrip: {e.Message}");
        }
    }

    public async Task<RoundTripResponse> DeleteAsync(int roundTripId)
    {
        var existingRoundTrip = await _roundTripRepository.FindByIdAsync(roundTripId);
        
        if (existingRoundTrip == null)
            return new RoundTripResponse("RoundTrip not found.");
        
        try
        {
            _roundTripRepository.Remove(existingRoundTrip);
            await _unitOfWork.CompleteAsync();

            return new RoundTripResponse(existingRoundTrip);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new RoundTripResponse($"An error occurred while deleting the roundTrip: {e.Message}");
        }

    }
}