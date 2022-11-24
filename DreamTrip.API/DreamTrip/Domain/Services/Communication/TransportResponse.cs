using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class TransportResponse : BaseResponse<Transport>
{
    public TransportResponse(string message) : base(message)
    {
    }

    public TransportResponse(Transport resource) : base(resource)
    {
    }
}