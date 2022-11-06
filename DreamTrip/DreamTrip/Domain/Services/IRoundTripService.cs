using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IRoundTripService
{
    Task<IEnumerable<RoundTrip>> ListAsync();
    Task<RoundTripResponse> SaveAsync(RoundTrip roundTrip);
    Task<RoundTripResponse> UpdateAsync(int roundTripId, RoundTrip roundTrip);
    Task<RoundTripResponse> DeleteAsync(int roundTripId);
}