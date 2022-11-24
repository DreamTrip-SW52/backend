namespace DreamTrip.API.DreamTrip.Domain.Models;

public class HealthCenter
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    // Relationships

    // Location
    public int LocationId { get; set; }
    public Location Location { get; set; }
}
