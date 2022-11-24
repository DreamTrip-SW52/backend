using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class PoliceStationService : IPoliceStationService
{
    private readonly IPoliceStationRepository _policeStationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PoliceStationService(IPoliceStationRepository policeStationRepository, IUnitOfWork unitOfWork)
    {
        _policeStationRepository = policeStationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PoliceStation>> ListAsync()
    {
        return await _policeStationRepository.ListAsync();
    }

    public async Task<IEnumerable<PoliceStation>> FindByLocationIdAsync(int policeStationId)
    {
        return await _policeStationRepository.FindByLocationId(policeStationId);
    }

    public async Task<PoliceStationResponse> SaveAsync(PoliceStation policeStation)
    {
        try
        {
            await _policeStationRepository.AddAsync(policeStation);
            await _unitOfWork.CompleteAsync();
            return new PoliceStationResponse(policeStation);
        }
        catch (Exception e)
        {
            return new PoliceStationResponse($"An error occurred while saving the policeStation: {e.Message}");
        }
    }

    public async Task<PoliceStationResponse> UpdateAsync(int policeStationId, PoliceStation policeStation)
    {
        var existingPoliceStation = await _policeStationRepository.FindByIdAsync(policeStationId);

        if (existingPoliceStation == null)
            return new PoliceStationResponse("PoliceStation not found.");

        existingPoliceStation.Name = policeStation.Name;
				existingPoliceStation.Address = policeStation.Address;
				existingPoliceStation.Phone = policeStation.Phone;
				existingPoliceStation.LocationId = policeStation.LocationId;

        try
        {
            _policeStationRepository.Update(existingPoliceStation);
            await _unitOfWork.CompleteAsync();

            return new PoliceStationResponse(existingPoliceStation);
        }
        catch (Exception e)
        {
            return new PoliceStationResponse($"An error occurred while updating the policeStation: {e.Message}");
        }
    }

    public async Task<PoliceStationResponse> DeleteAsync(int policeStationId)
    {
        var existingPoliceStation = await _policeStationRepository.FindByIdAsync(policeStationId);

        if (existingPoliceStation == null)
            return new PoliceStationResponse("PoliceStation not found.");

        try
        {
            _policeStationRepository.Remove(existingPoliceStation);
            await _unitOfWork.CompleteAsync();

            return new PoliceStationResponse(existingPoliceStation);

        }
        catch (Exception e)
        {
            // Error Handling
            return new PoliceStationResponse($"An error occurred while deleting the policeStation: {e.Message}");
        }

    }
}