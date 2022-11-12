using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class TripBackResponse : BaseResponse<TripBack>
{
    public TripBackResponse(string message) : base(message)
    {
    }

    public TripBackResponse(TripBack resource) : base(resource)
    {
    }
}