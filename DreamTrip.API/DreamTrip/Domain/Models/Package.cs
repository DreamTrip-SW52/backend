namespace DreamTrip.API.DreamTrip.Domain.Models;

public class Package
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string LocationAddress { get; set; }
    public int Duration { get; set; }
    public int Capacity { get; set; }
    public int Price { get; set; }
    public string Image { get; set; }
    public bool Custom { get; set; }

    // Relationships
    
    // Travel Agency
    public int AgencyId { get; set; }
    public Agency Agency { get; set; }
    // Location
    public int LocationId { get; set; }
    public Location Location { get; set; }
    
    // Accommodation
    public Accommodation Accommodation { get; set; }
    // Rent Car
    public RentCar RentCar { get; set; }
    // Tour
    public Tour Tour { get; set; }
    // One Way
    public OneWay OneWay { get; set; }
    // Round Trip
    public RoundTrip RoundTrip { get; set; }
    
    // Comments
    public List<Review> Reviews { get; set; }
    // Purchased Packages
    public List<PurchasedPackage> PurchasedPackages { get; set; }
}