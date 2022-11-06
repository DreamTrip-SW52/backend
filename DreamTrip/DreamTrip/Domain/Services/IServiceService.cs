using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IServiceService
{
    Task<IEnumerable<Service>> ListAsync();
    Task<ServiceResponse> SaveAsync(Service service);
    Task<ServiceResponse> UpdateAsync(int serviceId, Service service);
    Task<ServiceResponse> DeleteAsync(int serviceId);
}