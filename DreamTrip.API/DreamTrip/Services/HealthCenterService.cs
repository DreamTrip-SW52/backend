using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class HealthCenterService : IHealthCenterService
{
    private readonly IHealthCenterRepository _healthCenterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HealthCenterService(IHealthCenterRepository healthCenterRepository, IUnitOfWork unitOfWork)
    {
        _healthCenterRepository = healthCenterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<HealthCenter>> ListAsync()
    {
        return await _healthCenterRepository.ListAsync();
    }

    public async Task<IEnumerable<HealthCenter>> FindByTypeAndLocationIdAsync(string type, int locationId)
    {
        return await _healthCenterRepository.FindByTypeAndLocationId(type, locationId);
    }

    public async Task<HealthCenterResponse> SaveAsync(HealthCenter healthCenter)
    {
        try
        {
            await _healthCenterRepository.AddAsync(healthCenter);
            await _unitOfWork.CompleteAsync();
            return new HealthCenterResponse(healthCenter);
        }
        catch (Exception e)
        {
            return new HealthCenterResponse($"An error occurred while saving the healthCenter: {e.Message}");
        }
    }

    public async Task<HealthCenterResponse> UpdateAsync(int healthCenterId, HealthCenter healthCenter)
    {
        var existingHealthCenter = await _healthCenterRepository.FindByIdAsync(healthCenterId);

        if (existingHealthCenter == null)
            return new HealthCenterResponse("HealthCenter not found.");

        existingHealthCenter.Type = healthCenter.Type;
				existingHealthCenter.Name = healthCenter.Name;
				existingHealthCenter.Address = healthCenter.Address;
				existingHealthCenter.Phone = healthCenter.Phone;
				existingHealthCenter.LocationId = healthCenter.LocationId;


        try
        {
            _healthCenterRepository.Update(existingHealthCenter);
            await _unitOfWork.CompleteAsync();

            return new HealthCenterResponse(existingHealthCenter);
        }
        catch (Exception e)
        {
            return new HealthCenterResponse($"An error occurred while updating the healthCenter: {e.Message}");
        }
    }

    public async Task<HealthCenterResponse> DeleteAsync(int healthCenterId)
    {
        var existingHealthCenter = await _healthCenterRepository.FindByIdAsync(healthCenterId);

        if (existingHealthCenter == null)
            return new HealthCenterResponse("HealthCenter not found.");

        try
        {
            _healthCenterRepository.Remove(existingHealthCenter);
            await _unitOfWork.CompleteAsync();

            return new HealthCenterResponse(existingHealthCenter);

        }
        catch (Exception e)
        {
            // Error Handling
            return new HealthCenterResponse($"An error occurred while deleting the healthCenter: {e.Message}");
        }

    }
}