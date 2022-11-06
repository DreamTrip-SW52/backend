using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IAgencyCardService
{
    Task<IEnumerable<AgencyCard>> ListAsync();
    Task<AgencyCardResponse> SaveAsync(AgencyCard agencyCard);
    Task<AgencyCardResponse> UpdateAsync(int agencyCardId, AgencyCard agencyCard);
    Task<AgencyCardResponse> DeleteAsync(int agencyCardId);
}