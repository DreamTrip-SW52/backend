using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class TransportResponse : BaseResponse<Transport>
{
    public TransportResponse(string message) : base(message)
    {
    }

    public TransportResponse(Transport resource) : base(resource)
    {
    }
}