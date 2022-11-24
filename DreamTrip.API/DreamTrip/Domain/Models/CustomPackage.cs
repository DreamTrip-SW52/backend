namespace DreamTrip.API.DreamTrip.Domain.Models;

public class CustomPackage
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    // Relationships
    // Traveler
    public int? TravelerId { get; set; }
    public Traveler Traveler { get; set; }
    // Location
    public int? LocationId { get; set; }
    public Location Location { get; set; }
    // Rent Car
    public int? RentCarId { get; set; }
    public RentCar RentCar { get; set; }
    // Accommodation
    public int? AccommodationId { get; set; }
    public Accommodation Accommodation { get; set; }
    // Tour
    public int? TourId { get; set; }
    public Tour Tour { get; set; }
    // Round Trip
    public int? RoundTripId { get; set; }
    public RoundTrip RoundTrip { get; set; }
    // One Way
    public int? OneWayId { get; set; }
    public OneWay OneWay { get; set; }
    
    // Purchased Packages
    public List<PurchasedPackage> PurchasedPackages { get; set; } = new List<PurchasedPackage>();
}