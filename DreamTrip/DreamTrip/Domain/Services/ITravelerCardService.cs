using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface ITravelerCardService
{
    Task<IEnumerable<TravelerCard>> ListAsync();
    Task<TravelerCardResponse> SaveAsync(TravelerCard travelerCard);
    Task<TravelerCardResponse> UpdateAsync(int travelerCardId, TravelerCard travelerCard);
    Task<TravelerCardResponse> DeleteAsync(int travelerCardId);
}