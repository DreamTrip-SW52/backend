using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface ICustomPackageRepository
{
    Task<IEnumerable<CustomPackage>> ListAsync();
    Task<CustomPackage> FindByIdAsync(int id);
    Task AddAsync(CustomPackage accommodation);
    void Update(CustomPackage accommodation);
    void Remove(CustomPackage accommodation);
}