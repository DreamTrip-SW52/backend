using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface ITravelerCardRepository
{
    Task<IEnumerable<TravelerCard>> ListAsync();
    Task AddAsync(TravelerCard travelerCard);
    Task<TravelerCard> FindByIdAsync(int id);
    void Update(TravelerCard travelerCard);
    void Remove(TravelerCard travelerCard);
}