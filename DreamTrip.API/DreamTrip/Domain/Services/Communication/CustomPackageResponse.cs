using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class CustomPackageResponse : BaseResponse<CustomPackage>
{
    public CustomPackageResponse(string message) : base(message)
    {
    }

    public CustomPackageResponse(CustomPackage resource) : base(resource)
    {
    }
}