namespace DreamTrip.API.DreamTrip.Domain.Models;

public class TravelerCard
{
    public int Id { get; set; }
    public string HolderName { get; set; }
    public string CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }

    // Relationships

    // Traveler
    public int TravelerId { get; set; }
    public Traveler Traveler { get; set; }
}
