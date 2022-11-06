using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class TripBackResponse : BaseResponse<TripBack>
{
    public TripBackResponse(string message) : base(message)
    {
    }

    public TripBackResponse(TripBack resource) : base(resource)
    {
    }
}