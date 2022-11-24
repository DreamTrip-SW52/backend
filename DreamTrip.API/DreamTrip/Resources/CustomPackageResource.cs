namespace DreamTrip.API.DreamTrip.Resources;

public class CustomPackageResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int TravelerId { get; set; }
    public int LocationId { get; set; }
    public int? RentCarId { get; set; }
    public int? AccommodationId { get; set; }
    public int? TourId { get; set; }
    public int? RoundTripId { get; set; }
    public int? OneWayId { get; set; }
}