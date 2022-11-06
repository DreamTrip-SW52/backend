using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class AgencyResponse : BaseResponse<Agency>
{
    public AgencyResponse(string message) : base(message)
    {
    }

    public AgencyResponse(Agency resource) : base(resource)
    {
    }
}