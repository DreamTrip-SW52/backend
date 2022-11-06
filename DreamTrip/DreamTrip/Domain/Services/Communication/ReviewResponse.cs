using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class ReviewResponse : BaseResponse<Review>
{
    public ReviewResponse(string message) : base(message)
    {
    }

    public ReviewResponse(Review resource) : base(resource)
    {
    }
}