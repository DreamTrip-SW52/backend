using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface ITransportClassService
{
    Task<IEnumerable<TransportClass>> ListAsync();
    Task<TransportClass> FindByIdAsync(int id);
    Task<TransportClassResponse> SaveAsync(TransportClass transportClass);
    Task<TransportClassResponse> UpdateAsync(int transportClassId, TransportClass transportClass);
    Task<TransportClassResponse> DeleteAsync(int transportClassId);
}