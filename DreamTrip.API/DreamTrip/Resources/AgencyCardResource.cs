namespace DreamTrip.API.DreamTrip.Resources;

public class AgencyCardResource
{
    public int Id { get; set; }
    public string HolderName { get; set; }
    public string CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int AgencyId { get; set; }
}
