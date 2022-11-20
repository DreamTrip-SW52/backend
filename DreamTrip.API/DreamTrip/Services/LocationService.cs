using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LocationService(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
    {
        _locationRepository = locationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Location>> ListAsync()
    {
        return await _locationRepository.ListAsync();
    }
    
    public async Task<Location> FindByIdAsync(int id)
    {
        return await _locationRepository.FindByIdAsync(id);
    }

    public async Task<Location> FindByDepartmentAsync(string department)
    {
        return await _locationRepository.FindByDepartment(department);
    }

    public async Task<LocationResponse> SaveAsync(Location location)
    {
        try
        {
            await _locationRepository.AddAsync(location);
            await _unitOfWork.CompleteAsync();
            return new LocationResponse(location);
        }
        catch (Exception e)
        {
            return new LocationResponse($"An error occurred while saving the location: {e.Message}");
        }
    }

    public async Task<LocationResponse> UpdateAsync(int locationId, Location location)
    {
        var existingLocation = await _locationRepository.FindByIdAsync(locationId);

        if (existingLocation == null)
            return new LocationResponse("Location not found.");

        existingLocation.Department = location.Department;
        existingLocation.Abbr = location.Abbr;

        try
        {
            _locationRepository.Update(existingLocation);
            await _unitOfWork.CompleteAsync();

            return new LocationResponse(existingLocation);
        }
        catch (Exception e)
        {
            return new LocationResponse($"An error occurred while updating the location: {e.Message}");
        }
    }

    public async Task<LocationResponse> DeleteAsync(int locationId)
    {
        var existingLocation = await _locationRepository.FindByIdAsync(locationId);

        if (existingLocation == null)
            return new LocationResponse("Location not found.");

        try
        {
            _locationRepository.Remove(existingLocation);
            await _unitOfWork.CompleteAsync();

            return new LocationResponse(existingLocation);

        }
        catch (Exception e)
        {
            // Error Handling
            return new LocationResponse($"An error occurred while deleting the location: {e.Message}");
        }

    }
}