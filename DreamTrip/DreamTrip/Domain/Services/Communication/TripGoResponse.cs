using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class TripGoResponse : BaseResponse<TripGo>
{
    public TripGoResponse(string message) : base(message)
    {
    }

    public TripGoResponse(TripGo resource) : base(resource)
    {
    }
}