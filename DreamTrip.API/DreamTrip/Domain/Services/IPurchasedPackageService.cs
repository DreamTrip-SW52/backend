using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IPurchasedPackageService
{
    Task<IEnumerable<PurchasedPackage>> ListAsync();
    Task<PurchasedPackage> FindActiveSync();
    Task<PurchasedPackageResponse> SaveAsync(PurchasedPackage purchasedPackage);
    Task<PurchasedPackageResponse> UpdateAsync(int purchasedPackageId, PurchasedPackage purchasedPackage);
    Task<PurchasedPackageResponse> DeleteAsync(int purchasedPackageId);
}