using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class TravelerResponse : BaseResponse<Traveler>
{
    public TravelerResponse(string message) : base(message)
    {
    }

    public TravelerResponse(Traveler resource) : base(resource)
    {
    }
}