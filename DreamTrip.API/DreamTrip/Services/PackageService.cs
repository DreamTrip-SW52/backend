using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class PackageService : IPackageService
{
    private readonly IPackageRepository _packageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PackageService(IPackageRepository packageRepository, IUnitOfWork unitOfWork)
    {
        _packageRepository = packageRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Package>> ListAsync()
    {
        return await _packageRepository.ListAsync();
    }

    public async Task<Package> FindByIdAsync(int id)
    {
        return await _packageRepository.FindByIdAsync(id);
    }
    
    public async Task<IEnumerable<Package>> FindByAgencyIdAsync(int agencyId)
    {
        return await _packageRepository.FindByAgencyId(agencyId);
    }
    
    public async Task<IEnumerable<Package>> FindByPriceAsync(int price) 
    {
        return await _packageRepository.FindByPrice(price);
    }
    
    public async Task<IEnumerable<Package>> FindByDurationAsync(int duration)
    {
        return await _packageRepository.FindByDuration(duration);
    }
    
    public async Task<IEnumerable<Package>> FindByCategoryAsync(string category)
    {
        return await _packageRepository.FindByCategory(category);
    }

    public async Task<PackageResponse> SaveAsync(Package package)
    {
        try
        {
            await _packageRepository.AddAsync(package);
            await _unitOfWork.CompleteAsync();
            return new PackageResponse(package);
        }
        catch (Exception e)
        {
            return new PackageResponse($"An error occurred while saving the package: {e.Message}");
        }
    }

    public async Task<PackageResponse> UpdateAsync(int packageId, Package package)
    {
        var existingPackage = await _packageRepository.FindByIdAsync(packageId);

        if (existingPackage == null)
            return new PackageResponse("Package not found.");

        existingPackage.Name = package.Name;
		existingPackage.Description = package.Description;
		existingPackage.LocationAddress = package.LocationAddress;
		existingPackage.Duration = package.Duration;
		existingPackage.Capacity = package.Capacity;
		existingPackage.Price = package.Price;
		existingPackage.Image=  package.Image;
		existingPackage.Views = package.Views;
		existingPackage.Sales = package.Sales;
        existingPackage.Category = package.Category;
        existingPackage.AgencyId= package.AgencyId;
		existingPackage.LocationId = package.LocationId;

        try
        {
            _packageRepository.Update(existingPackage);
            await _unitOfWork.CompleteAsync();

            return new PackageResponse(existingPackage);
        }
        catch (Exception e)
        {
            return new PackageResponse($"An error occurred while updating the package: {e.Message}");
        }
    }

    public async Task<PackageResponse> DeleteAsync(int packageId)
    {
        var existingPackage = await _packageRepository.FindByIdAsync(packageId);

        if (existingPackage == null)
            return new PackageResponse("Package not found.");

        try
        {
            _packageRepository.Remove(existingPackage);
            await _unitOfWork.CompleteAsync();

            return new PackageResponse(existingPackage);

        }
        catch (Exception e)
        {
            // Error Handling
            return new PackageResponse($"An error occurred while deleting the package: {e.Message}");
        }

    }
}