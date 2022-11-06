using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class LocationResponse : BaseResponse<Location>
{
    public LocationResponse(string message) : base(message)
    {
    }

    public LocationResponse(Location resource) : base(resource)
    {
    }
}