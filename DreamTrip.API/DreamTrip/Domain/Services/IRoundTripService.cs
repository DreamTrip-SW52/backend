using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IRoundTripService
{
    Task<IEnumerable<RoundTrip>> ListAsync();
    Task<RoundTripResponse> SaveAsync(RoundTrip roundTrip);
    Task<RoundTripResponse> UpdateAsync(int roundTripId, RoundTrip roundTrip);
    Task<RoundTripResponse> DeleteAsync(int roundTripId);
}