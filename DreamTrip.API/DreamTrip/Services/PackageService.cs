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

    public async Task<Package> ListByPackageIdAsync(int packageId)
    {
        return await _packageRepository.FindByIdAsync(packageId);
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
				existingPackage.Custom = package.Custom;
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