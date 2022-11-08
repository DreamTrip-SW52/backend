namespace DreamTrip.DreamTrip.Domain.Models;

public class Review
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public int Stars { get; set; }

    // Relationships

    // Package
    public int PackageId { get; set; }
    public Package Package { get; set; }
    // Traveler
    public int TravelerId { get; set; }
    public Traveler Traveler { get; set; }
}

