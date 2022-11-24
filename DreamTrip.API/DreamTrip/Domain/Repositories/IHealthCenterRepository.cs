using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IHealthCenterRepository
{
    Task<IEnumerable<HealthCenter>> ListAsync();
    Task<HealthCenter> FindByIdAsync(int id);
    Task<IEnumerable<HealthCenter>> FindByTypeAndLocationId(string type, int locationId);
    Task AddAsync(HealthCenter healthCenter);
    void Update(HealthCenter healthCenter);
    void Remove(HealthCenter healthCenter);
}