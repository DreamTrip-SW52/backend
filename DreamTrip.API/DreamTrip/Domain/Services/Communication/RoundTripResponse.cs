using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class RoundTripResponse : BaseResponse<RoundTrip>
{
    public RoundTripResponse(string message) : base(message)
    {
    }

    public RoundTripResponse(RoundTrip resource) : base(resource)
    {
    }
}