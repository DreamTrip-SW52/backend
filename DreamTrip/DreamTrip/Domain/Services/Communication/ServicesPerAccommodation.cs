using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class ServicesPerAccommodationResponse : BaseResponse<ServicesPerAccommodation>
{
    public ServicesPerAccommodationResponse(string message) : base(message)
    {
    }

    public ServicesPerAccommodationResponse(ServicesPerAccommodation resource) : base(resource)
    {
    }
}