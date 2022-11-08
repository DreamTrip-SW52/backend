namespace DreamTrip.DreamTrip.Resources;

public class ReviewResource
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public int Stars { get; set; }
    public int PackageId { get; set; }
    public int TravelerId { get; set; }
}

