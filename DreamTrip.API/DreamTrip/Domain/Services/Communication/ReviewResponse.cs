using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class ReviewResponse : BaseResponse<Review>
{
    public ReviewResponse(string message) : base(message)
    {
    }

    public ReviewResponse(Review resource) : base(resource)
    {
    }
}