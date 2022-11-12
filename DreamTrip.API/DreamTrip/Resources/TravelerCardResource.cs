namespace DreamTrip.API.DreamTrip.Resources;

public class TravelerCardResource
{
    public int Id { get; set; }
    public string HolderName { get; set; }
    public string CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int TravelerId { get; set; }
}
