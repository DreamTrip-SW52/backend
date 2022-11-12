using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface ITransportService
{
    Task<IEnumerable<Transport>> ListAsync();
    Task<TransportResponse> SaveAsync(Transport transport);
    Task<TransportResponse> UpdateAsync(int transportId, Transport transport);
    Task<TransportResponse> DeleteAsync(int transportId);
}