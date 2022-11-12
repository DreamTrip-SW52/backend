using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class ServicesPerAccommodationResponse : BaseResponse<ServicesPerAccommodation>
{
    public ServicesPerAccommodationResponse(string message) : base(message)
    {
    }

    public ServicesPerAccommodationResponse(ServicesPerAccommodation resource) : base(resource)
    {
    }
}