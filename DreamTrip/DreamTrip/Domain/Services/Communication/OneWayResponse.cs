using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class OneWayResponse : BaseResponse<OneWay>
{
    public OneWayResponse(string message) : base(message)
    {
    }

    public OneWayResponse(OneWay resource) : base(resource)
    {
    }
}