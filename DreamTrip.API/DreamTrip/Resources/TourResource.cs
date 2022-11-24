namespace DreamTrip.API.DreamTrip.Resources;

public class TourResource
{
    public int Id { get; set; }
    public string Details { get; set; }
    public string Location { get; set; }
    public string MeetingPoint { get; set; }
    public decimal Price { get; set; }
    public int PackageId { get; set; }
}
