using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface ITravelerCardService
{
    Task<IEnumerable<TravelerCard>> ListAsync();
    Task<IEnumerable<TravelerCard>> FindByTravelerIdAsync(int travelerId);
    Task<TravelerCardResponse> SaveAsync(TravelerCard travelerCard);
    Task<TravelerCardResponse> UpdateAsync(int travelerCardId, TravelerCard travelerCard);
    Task<TravelerCardResponse> DeleteAsync(int travelerCardId);
}