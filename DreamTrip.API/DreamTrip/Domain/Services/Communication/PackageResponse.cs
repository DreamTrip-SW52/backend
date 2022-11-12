using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class PackageResponse : BaseResponse<Package>
{
    public PackageResponse(string message) : base(message)
    {
    }

    public PackageResponse(Package resource) : base(resource)
    {
    }
}