using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class PoliceStationResponse : BaseResponse<PoliceStation>
{
    public PoliceStationResponse(string message) : base(message)
    {
    }

    public PoliceStationResponse(PoliceStation resource) : base(resource)
    {
    }
}