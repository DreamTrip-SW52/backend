using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class AccommodationResponse : BaseResponse<Accommodation>
{
    public AccommodationResponse(string message) : base(message)
    {
    }

    public AccommodationResponse(Accommodation resource) : base(resource)
    {
    }
}