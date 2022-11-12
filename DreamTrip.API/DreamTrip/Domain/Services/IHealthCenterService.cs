using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IHealthCenterService
{
    Task<IEnumerable<HealthCenter>> ListAsync();
    Task<HealthCenterResponse> SaveAsync(HealthCenter healthCenter);
    Task<HealthCenterResponse> UpdateAsync(int healthCenterId, HealthCenter healthCenter);
    Task<HealthCenterResponse> DeleteAsync(int healthCenterId);
}