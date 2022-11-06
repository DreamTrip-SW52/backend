using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IPackageService
{
    Task<IEnumerable<Package>> ListAsync();
    Task<PackageResponse> SaveAsync(Package package);
    Task<PackageResponse> UpdateAsync(int packageId, Package package);
    Task<PackageResponse> DeleteAsync(int packageId);
}