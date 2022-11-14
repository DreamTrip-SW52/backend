using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IRoundTripService
{
    Task<IEnumerable<RoundTrip>> ListAsync();
    Task<RoundTrip> FindByPackageIdAsync(int packageId);
    Task<IEnumerable<RoundTrip>> FindByFiltersAsync(string from, string to,
        DateTime departureDate,  DateTime returnDate, string transportClass,
        string transportType);
    Task<RoundTripResponse> SaveAsync(RoundTrip roundTrip);
    Task<RoundTripResponse> UpdateAsync(int roundTripId, RoundTrip roundTrip);
    Task<RoundTripResponse> DeleteAsync(int roundTripId);
}