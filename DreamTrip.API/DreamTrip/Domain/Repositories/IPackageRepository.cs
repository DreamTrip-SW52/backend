using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IPackageRepository
{
    Task<IEnumerable<Package>> ListAsync();
    Task AddAsync(Package package);
    Task<Package> FindByIdAsync(int id);
    Task<IEnumerable<Package>> FindByAgencyId(int agencyId);
    Task<IEnumerable<Package>> FindByPrice(int price);
    Task<IEnumerable<Package>> FindByDuration(int duration);
    Task<IEnumerable<Package>> FindByCategory(string category);
    void Update(Package package);
    void Remove(Package package);
}