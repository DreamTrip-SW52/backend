using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class TravelerCardResponse : BaseResponse<TravelerCard>
{
    public TravelerCardResponse(string message) : base(message)
    {
    }

    public TravelerCardResponse(TravelerCard resource) : base(resource)
    {
    }
}