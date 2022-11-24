namespace DreamTrip.API.DreamTrip.Domain.Models;

public class Accommodation
{
    public int Id { get; set; }
    public string Details { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string Location { get; set; }
    public decimal Price { get; set; }

    // Relationship
    // Package
    public int PackageId { get; set; }
    public Package Package { get; set; }
    // Services per Accommodation
    public List<ServicesPerAccommodation> ServicesPerAccommodations { get; set; } = new List<ServicesPerAccommodation>();
    // Custom Packages
    public List<CustomPackage> CustomPackages { get; set; } = new List<CustomPackage>();

}
