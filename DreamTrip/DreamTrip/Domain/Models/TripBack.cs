namespace DreamTrip.DreamTrip.Domain.Models;

public class TripBack
{
    public int Id { get; set; }

    // Relationship
    
    // Location
    public int LocationId { get; set; }
    public Location Location { get; set; }
}
