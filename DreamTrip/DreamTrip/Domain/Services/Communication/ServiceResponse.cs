using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class ServiceResponse : BaseResponse<Service>
{
    public ServiceResponse(string message) : base(message)
    {
    }

    public ServiceResponse(Service resource) : base(resource)
    {
    }
}