namespace DreamTrip.API.DreamTrip.Resources;

public class RentCarResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Brand{ get; set; }
    public string Address{ get; set; }
    public int Capacity { get; set; }
    public string Photo { get; set; }
    public decimal Price { get; set; }
    public DateTime PickUpHour { get; set; }
    public DateTime DropOffHour { get; set; }
    public int PackageId { get; set; }
}
