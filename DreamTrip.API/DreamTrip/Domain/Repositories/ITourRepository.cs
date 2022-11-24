using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface ITourRepository
{
    Task<IEnumerable<Tour>> ListAsync();
    Task<Tour> FindByIdAsync(int id);
    Task<Tour> FindByPackageId(int packageId);
    Task<IEnumerable<Tour>> FindByLocationId(int locationId);
    Task AddAsync(Tour tour);
    void Update(Tour tour);
    void Remove(Tour tour);
}