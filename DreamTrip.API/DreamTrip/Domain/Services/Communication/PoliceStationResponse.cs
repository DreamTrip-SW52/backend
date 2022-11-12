using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class PoliceStationResponse : BaseResponse<PoliceStation>
{
    public PoliceStationResponse(string message) : base(message)
    {
    }

    public PoliceStationResponse(PoliceStation resource) : base(resource)
    {
    }
}