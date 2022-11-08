namespace DreamTrip.DreamTrip.Domain.Models;

public class Tour
{
    public int Id { get; set; }
    public string Details { get; set; }
    public string Location { get; set; }
    public string MeetingPoint { get; set; }
    public decimal Price { get; set; }
    // Relationship

    // Package
    public int PackageId { get; set; }
    public Package Package { get; set; }
}
