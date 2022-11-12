using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class LocationResponse : BaseResponse<Location>
{
    public LocationResponse(string message) : base(message)
    {
    }

    public LocationResponse(Location resource) : base(resource)
    {
    }
}