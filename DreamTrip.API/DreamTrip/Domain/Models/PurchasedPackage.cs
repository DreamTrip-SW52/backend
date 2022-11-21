namespace DreamTrip.API.DreamTrip.Domain.Models;

public class PurchasedPackage
{
    public bool Active { get; set; }

    // Relationships

    // Traveler
    public int TravelerId { get; set; }
    public Traveler Traveler { get; set; }
    // Package
    public int PackageId { get; set; }
    public Package Package { get; set; }
    // Custom Package
    public int CustomPackageId { get; set; }
    public CustomPackage CustomPackage { get; set; }
}
