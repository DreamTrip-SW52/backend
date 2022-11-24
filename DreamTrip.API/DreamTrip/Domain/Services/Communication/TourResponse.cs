using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class TourResponse : BaseResponse<Tour>
{
    public TourResponse(string message) : base(message)
    {
    }

    public TourResponse(Tour resource) : base(resource)
    {
    }
}