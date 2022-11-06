using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface ITransportClassService
{
    Task<IEnumerable<TransportClass>> ListAsync();
    Task<TransportClassResponse> SaveAsync(TransportClass transportClass);
    Task<TransportClassResponse> UpdateAsync(int transportClassId, TransportClass transportClass);
    Task<TransportClassResponse> DeleteAsync(int transportClassId);
}