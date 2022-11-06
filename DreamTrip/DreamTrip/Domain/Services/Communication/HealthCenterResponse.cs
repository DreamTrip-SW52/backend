using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class HealthCenterResponse : BaseResponse<HealthCenter>
{
    public HealthCenterResponse(string message) : base(message)
    {
    }

    public HealthCenterResponse(HealthCenter resource) : base(resource)
    {
    }
}