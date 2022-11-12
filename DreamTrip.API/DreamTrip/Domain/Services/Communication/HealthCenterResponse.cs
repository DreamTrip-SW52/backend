using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class HealthCenterResponse : BaseResponse<HealthCenter>
{
    public HealthCenterResponse(string message) : base(message)
    {
    }

    public HealthCenterResponse(HealthCenter resource) : base(resource)
    {
    }
}