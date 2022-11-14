using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IOneWayService
{
    Task<IEnumerable<OneWay>> ListAsync();
    Task<OneWay> FindByPackageIdAsync(int packageId);
    Task<OneWayResponse> SaveAsync(OneWay oneWay);
    Task<OneWayResponse> UpdateAsync(int oneWayId, OneWay oneWay);
    Task<OneWayResponse> DeleteAsync(int oneWayId);
}