namespace DreamTrip.API.DreamTrip.Domain.Models;

public class TripGo
{
    public int Id { get; set; }

    // Relationship
    
    // Location
    public int LocationId { get; set; }
    public Location Location { get; set; }
    
    // One Way
    public OneWay OneWay { get; set; }
    // Round Trip
    public RoundTrip RoundTrip { get; set; }
}
