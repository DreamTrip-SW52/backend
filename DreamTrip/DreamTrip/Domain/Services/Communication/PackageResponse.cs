using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class PackageResponse : BaseResponse<Package>
{
    public PackageResponse(string message) : base(message)
    {
    }

    public PackageResponse(Package resource) : base(resource)
    {
    }
}