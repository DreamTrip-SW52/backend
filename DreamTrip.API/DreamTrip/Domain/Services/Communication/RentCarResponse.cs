using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class RentCarResponse : BaseResponse<RentCar>
{
    public RentCarResponse(string message) : base(message)
    {
    }

    public RentCarResponse(RentCar resource) : base(resource)
    {
    }
}