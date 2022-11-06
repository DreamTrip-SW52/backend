using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class RentCarResponse : BaseResponse<RentCar>
{
    public RentCarResponse(string message) : base(message)
    {
    }

    public RentCarResponse(RentCar resource) : base(resource)
    {
    }
}