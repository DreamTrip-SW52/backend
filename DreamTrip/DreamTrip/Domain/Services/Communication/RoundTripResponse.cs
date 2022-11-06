using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class RoundTripResponse : BaseResponse<RoundTrip>
{
    public RoundTripResponse(string message) : base(message)
    {
    }

    public RoundTripResponse(RoundTrip resource) : base(resource)
    {
    }
}