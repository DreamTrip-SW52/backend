using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IOneWayService
{
    Task<IEnumerable<OneWay>> ListAsync();
    Task<OneWayResponse> SaveAsync(OneWay oneWay);
    Task<OneWayResponse> UpdateAsync(int oneWayId, OneWay oneWay);
    Task<OneWayResponse> DeleteAsync(int oneWayId);
}