using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IPurchasedPackageRepository
{
    Task<IEnumerable<PurchasedPackage>> ListAsync();
    Task<PurchasedPackage> FindByIdAsync(int id);
    Task<PurchasedPackage> FindActiveByTravelerId(int travelerId);
    Task AddAsync(PurchasedPackage purchasedPackage);
    void Update(PurchasedPackage purchasedPackage);
    void Remove(PurchasedPackage purchasedPackage);
}