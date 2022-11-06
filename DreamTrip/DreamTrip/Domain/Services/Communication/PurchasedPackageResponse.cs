using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services.Communication;

public class PurchasedPackageResponse : BaseResponse<PurchasedPackage>
{
    public PurchasedPackageResponse(string message) : base(message)
    {
    }

    public PurchasedPackageResponse(PurchasedPackage resource) : base(resource)
    {
    }
}