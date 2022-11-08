namespace DreamTrip.DreamTrip.Domain.Models;

public class TransportClass
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Relationships
    // One Way
    public OneWay OneWay { get; set; }
    // Round Trip
    public RoundTrip RoundTrip { get; set; }
}
