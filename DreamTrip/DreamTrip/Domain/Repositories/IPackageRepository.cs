using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface IPackageRepository
{
    Task<IEnumerable<Package>> ListAsync();
    Task AddAsync(Package package);
    Task<Package> FindByIdAsync(int id);
    void Update(Package package);
    void Remove(Package package);
}