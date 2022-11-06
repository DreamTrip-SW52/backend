using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class TourResponse : BaseResponse<Tour>
{
    public TourResponse(string message) : base(message)
    {
    }

    public TourResponse(Tour resource) : base(resource)
    {
    }
}