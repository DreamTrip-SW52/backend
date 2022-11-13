using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IPackageService
{
    Task<IEnumerable<Package>> ListAsync();
    Task<Package> FindByIdAsync(int id);
    Task<IEnumerable<Package>> FindByAgencyIdAsync(int agencyId);
    Task<IEnumerable<Package>> FindByPriceAsync(int price);
    Task<IEnumerable<Package>> FindByDurationAsync(int duration);
    Task<IEnumerable<Package>> FindByCategoryAsync(string category);
    Task<PackageResponse> SaveAsync(Package package);
    Task<PackageResponse> UpdateAsync(int packageId, Package package);
    Task<PackageResponse> DeleteAsync(int packageId);
}