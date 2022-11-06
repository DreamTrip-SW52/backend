using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class TravelerCardResponse : BaseResponse<TravelerCard>
{
    public TravelerCardResponse(string message) : base(message)
    {
    }

    public TravelerCardResponse(TravelerCard resource) : base(resource)
    {
    }
}