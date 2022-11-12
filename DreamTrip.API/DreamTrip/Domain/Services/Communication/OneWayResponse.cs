using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class OneWayResponse : BaseResponse<OneWay>
{
    public OneWayResponse(string message) : base(message)
    {
    }

    public OneWayResponse(OneWay resource) : base(resource)
    {
    }
}