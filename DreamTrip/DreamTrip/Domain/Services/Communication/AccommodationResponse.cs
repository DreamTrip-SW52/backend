using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class AccommodationResponse : BaseResponse<Accommodation>
{
    public AccommodationResponse(string message) : base(message)
    {
    }

    public AccommodationResponse(Accommodation resource) : base(resource)
    {
    }
}