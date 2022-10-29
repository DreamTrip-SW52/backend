using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IAgencyService
{
    Task<IEnumerable<Agency>> ListAsync();
    // Task<IEnumerable<Agency>> ListByAgencyIdAsync(int agencyId);
    Task<AgencyResponse> SaveAsync(Agency agency);
    Task<AgencyResponse> UpdateAsync(int agencyId, Agency agency);
    Task<AgencyResponse> DeleteAsync(int agencyId);
}