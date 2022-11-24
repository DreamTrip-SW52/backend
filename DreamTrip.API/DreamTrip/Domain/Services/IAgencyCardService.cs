using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IAgencyCardService
{
    Task<IEnumerable<AgencyCard>> ListAsync();
    Task<IEnumerable<AgencyCard>> FindByAgencyIdAsync(int agencyId);
    Task<AgencyCardResponse> SaveAsync(AgencyCard agencyCard);
    Task<AgencyCardResponse> UpdateAsync(int agencyCardId, AgencyCard agencyCard);
    Task<AgencyCardResponse> DeleteAsync(int agencyCardId);
}