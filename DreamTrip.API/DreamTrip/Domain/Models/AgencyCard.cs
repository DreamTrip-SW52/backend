namespace DreamTrip.API.DreamTrip.Domain.Models;

public class AgencyCard
{
    public int Id { get; set; }
    public string HolderName { get; set; }
    public string CardNumber { get; set; }
    public string ExpirationDate { get; set; }

    // Relationships

    // Traveler
    public int AgencyId { get; set; }
    public Agency Agency { get; set; }
}
