namespace DreamTrip.API.DreamTrip.Domain.Models;

public class Transport
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    // Relationships
    // One Way
    public List<OneWay> OneWays { get; set; } = new List<OneWay>();
    public List<RoundTrip> RoundTrips { get; set; } = new List<RoundTrip>();
    
}
