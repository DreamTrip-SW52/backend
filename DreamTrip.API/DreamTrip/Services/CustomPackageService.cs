using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;
using Microsoft.VisualBasic;

namespace DreamTrip.API.DreamTrip.Services;

public class CustomPackageService : ICustomPackageService
{
    private readonly ICustomPackageRepository _customPackageRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CustomPackageService(ICustomPackageRepository customPackageRepository, IUnitOfWork unitOfWork)
    {
        _customPackageRepository = customPackageRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<CustomPackage>> ListAsync()
    {
        return await _customPackageRepository.ListAsync();
    }

    public async Task<CustomPackage> FindByIdAsync(int id)
    {
        return await _customPackageRepository.FindByIdAsync(id);
    }

    public async Task<CustomPackageResponse> SaveAsync(CustomPackage customPackage)
    {
        try
        {
            await _customPackageRepository.AddAsync(customPackage);
            await _unitOfWork.CompleteAsync();
            return new CustomPackageResponse(customPackage);
        }
        catch (Exception e)
        {
            return new CustomPackageResponse(message: $"An error occurred while saving the customPackage: {e.Message}");
        }
    }

    public async Task<CustomPackageResponse> UpdateAsync(int customPackageId, CustomPackage customPackage)
    {
        var existingCustomPackage = await _customPackageRepository.FindByIdAsync(customPackageId);

        if (existingCustomPackage == null)
            return new CustomPackageResponse("Custom package not found.");

        existingCustomPackage.Name = customPackage.Name;
        existingCustomPackage.Price = customPackage.Price;
        existingCustomPackage.TravelerId = customPackage.TravelerId;
        existingCustomPackage.LocationId = customPackage.LocationId;
        existingCustomPackage.RentCarId = customPackage.RentCarId;
        existingCustomPackage.AccommodationId = customPackage.AccommodationId;
        existingCustomPackage.TourId = customPackage.TourId;
        existingCustomPackage.RoundTripId = customPackage.RoundTripId;
        existingCustomPackage.OneWayId = customPackage.OneWayId;

        try
        {
            _customPackageRepository.Update(existingCustomPackage);
            await _unitOfWork.CompleteAsync();

            return new CustomPackageResponse(existingCustomPackage);
        }
        catch (Exception e)
        {
            return new CustomPackageResponse($"An error occurred while updating the customPackage: {e.Message}");
        }
    }

    public async Task<CustomPackageResponse> DeleteAsync(int customPackageId)
    {
        var existingCustomPackage = await _customPackageRepository.FindByIdAsync(customPackageId);

        if (existingCustomPackage == null)
            return new CustomPackageResponse("Custom package not found.");

        try
        {
            _customPackageRepository.Remove(existingCustomPackage);
            await _unitOfWork.CompleteAsync();

            return new CustomPackageResponse(existingCustomPackage);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CustomPackageResponse($"An error occurred while deleting the customPackage: {e.Message}");
        }
    }
}