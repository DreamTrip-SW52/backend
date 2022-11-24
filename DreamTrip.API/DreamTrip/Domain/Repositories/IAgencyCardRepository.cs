using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IAgencyCardRepository
{
    Task<IEnumerable<AgencyCard>> ListAsync();
    Task<AgencyCard> FindByIdAsync(int id);
    Task<IEnumerable<AgencyCard>> FindByAgencyId(int agencyId);
    Task AddAsync(AgencyCard agencyCard);
    void Update(AgencyCard agencyCard);
    void Remove(AgencyCard agencyCard);
}
