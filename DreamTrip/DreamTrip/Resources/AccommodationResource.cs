namespace DreamTrip.DreamTrip.Resources;

public class AccommodationResource
{
    public int Id { get; set; }
    public string Details { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string Location { get; set; }
    public decimal Price { get; set; }
    public int PackageId { get; set; }
}
