using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class EconomicFollowingResponse : BaseResponse<EconomicFollowing>
{
    public EconomicFollowingResponse(string message) : base(message)
    {
    }

    public EconomicFollowingResponse(EconomicFollowing resource) : base(resource)
    {
    }
}