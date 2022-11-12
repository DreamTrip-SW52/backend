using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IPackageService
{
    Task<IEnumerable<Package>> ListAsync();
    Task<PackageResponse> SaveAsync(Package package);
    Task<PackageResponse> UpdateAsync(int packageId, Package package);
    Task<PackageResponse> DeleteAsync(int packageId);
}