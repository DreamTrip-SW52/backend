using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class AgencyResponse : BaseResponse<Agency>
{
    public AgencyResponse(string message) : base(message)
    {
    }

    public AgencyResponse(Agency resource) : base(resource)
    {
    }
}