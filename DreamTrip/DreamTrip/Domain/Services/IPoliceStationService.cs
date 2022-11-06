using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IPoliceStationService
{
    Task<IEnumerable<PoliceStation>> ListAsync();
    Task<PoliceStationResponse> SaveAsync(PoliceStation policeStation);
    Task<PoliceStationResponse> UpdateAsync(int policeStationId, PoliceStation policeStation);
    Task<PoliceStationResponse> DeleteAsync(int policeStationId);
}