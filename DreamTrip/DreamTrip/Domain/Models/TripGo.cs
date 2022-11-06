namespace DreamTrip.DreamTrip.Domain.Models;

public class TripGo
{
    public int Id { get; set; }

    // Relationship
    
    // Location
    public int LocationId { get; set; }
    public Location Location { get; set; }
}
