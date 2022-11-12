using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class TransportClassResponse : BaseResponse<TransportClass>
{
    public TransportClassResponse(string message) : base(message)
    {
    }

    public TransportClassResponse(TransportClass resource) : base(resource)
    {
    }
}