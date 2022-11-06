using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface IPurchasedPackageRepository
{
    Task<IEnumerable<PurchasedPackage>> ListAsync();
    Task AddAsync(PurchasedPackage purchasedPackage);
    Task<PurchasedPackage> FindByIdAsync(int id);
    void Update(PurchasedPackage purchasedPackage);
    void Remove(PurchasedPackage purchasedPackage);
}