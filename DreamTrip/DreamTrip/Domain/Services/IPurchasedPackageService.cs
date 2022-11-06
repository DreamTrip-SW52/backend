using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IPurchasedPackageService
{
    Task<IEnumerable<PurchasedPackage>> ListAsync();
    Task<PurchasedPackageResponse> SaveAsync(PurchasedPackage purchasedPackage);
    Task<PurchasedPackageResponse> UpdateAsync(int purchasedPackageId, PurchasedPackage purchasedPackage);
    Task<PurchasedPackageResponse> DeleteAsync(int purchasedPackageId);
}