using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class AgencyCardResponse : BaseResponse<AgencyCard>
{
    public AgencyCardResponse(string message) : base(message)
    {
    }

    public AgencyCardResponse(AgencyCard resource) : base(resource)
    {
    }
}