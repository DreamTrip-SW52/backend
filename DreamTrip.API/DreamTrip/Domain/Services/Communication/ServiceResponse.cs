using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class ServiceResponse : BaseResponse<Service>
{
    public ServiceResponse(string message) : base(message)
    {
    }

    public ServiceResponse(Service resource) : base(resource)
    {
    }
}