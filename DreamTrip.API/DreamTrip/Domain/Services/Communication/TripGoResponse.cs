using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class TripGoResponse : BaseResponse<TripGo>
{
    public TripGoResponse(string message) : base(message)
    {
    }

    public TripGoResponse(TripGo resource) : base(resource)
    {
    }
}