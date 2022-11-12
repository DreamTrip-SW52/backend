using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IAgencyCardRepository
{
    Task<IEnumerable<AgencyCard>> ListAsync();
    Task AddAsync(AgencyCard agencyCard);
    Task<AgencyCard> FindByIdAsync(int id);
    void Update(AgencyCard agencyCard);
    void Remove(AgencyCard agencyCard);
}
