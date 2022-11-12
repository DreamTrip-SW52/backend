using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IAgencyService
{
    Task<IEnumerable<Agency>> ListAsync();
    Task<AgencyResponse> SaveAsync(Agency agency);
    Task<AgencyResponse> UpdateAsync(int agencyId, Agency agency);
    Task<AgencyResponse> DeleteAsync(int agencyId);
}