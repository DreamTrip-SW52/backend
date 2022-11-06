using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class TransportClassResponse : BaseResponse<TransportClass>
{
    public TransportClassResponse(string message) : base(message)
    {
    }

    public TransportClassResponse(TransportClass resource) : base(resource)
    {
    }
}