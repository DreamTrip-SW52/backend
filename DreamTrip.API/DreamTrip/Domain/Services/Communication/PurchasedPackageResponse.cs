using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services.Communication;

public class PurchasedPackageResponse : BaseResponse<PurchasedPackage>
{
    public PurchasedPackageResponse(string message) : base(message)
    {
    }

    public PurchasedPackageResponse(PurchasedPackage resource) : base(resource)
    {
    }
}