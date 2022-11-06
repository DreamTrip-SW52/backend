using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IHealthCenterService
{
    Task<IEnumerable<HealthCenter>> ListAsync();
    Task<HealthCenterResponse> SaveAsync(HealthCenter healthCenter);
    Task<HealthCenterResponse> UpdateAsync(int healthCenterId, HealthCenter healthCenter);
    Task<HealthCenterResponse> DeleteAsync(int healthCenterId);
}