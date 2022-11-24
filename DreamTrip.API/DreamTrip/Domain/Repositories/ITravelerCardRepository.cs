using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface ITravelerCardRepository
{
    Task<IEnumerable<TravelerCard>> ListAsync();
    Task<TravelerCard> FindByIdAsync(int id);
    Task<IEnumerable<TravelerCard>> FindByTravelerId(int travelerId);
    Task AddAsync(TravelerCard travelerCard);
    void Update(TravelerCard travelerCard);
    void Remove(TravelerCard travelerCard);
}