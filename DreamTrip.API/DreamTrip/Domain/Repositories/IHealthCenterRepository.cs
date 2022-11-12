using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IHealthCenterRepository
{
    Task<IEnumerable<HealthCenter>> ListAsync();
    Task AddAsync(HealthCenter healthCenter);
    Task<HealthCenter> FindByIdAsync(int id);
    void Update(HealthCenter healthCenter);
    void Remove(HealthCenter healthCenter);
}