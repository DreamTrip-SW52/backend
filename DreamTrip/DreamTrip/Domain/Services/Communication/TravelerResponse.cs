using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class TravelerResponse : BaseResponse<Traveler>
{
    public TravelerResponse(string message) : base(message)
    {
    }

    public TravelerResponse(Traveler resource) : base(resource)
    {
    }
}