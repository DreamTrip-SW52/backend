namespace DreamTrip.API.DreamTrip.Resources;

public class PurchasedPackageResource
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public int TravelerId { get; set; }
    public int? PackageId { get; set; }
    public int? CustomPackageId { get; set; }
}
