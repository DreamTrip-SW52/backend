using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class AgencyCardResponse : BaseResponse<AgencyCard>
{
    public AgencyCardResponse(string message) : base(message)
    {
    }

    public AgencyCardResponse(AgencyCard resource) : base(resource)
    {
    }
}