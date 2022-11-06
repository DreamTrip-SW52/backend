using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface ITransportService
{
    Task<IEnumerable<Transport>> ListAsync();
    Task<TransportResponse> SaveAsync(Transport transport);
    Task<TransportResponse> UpdateAsync(int transportId, Transport transport);
    Task<TransportResponse> DeleteAsync(int transportId);
}