namespace DreamTrip.API.DreamTrip.Domain.Models;

public class RentCar
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

    // Relationships

    // Package
    public int PackageId { get; set; }
    public Package Package { get; set; }
    
    // Custom package
    public List<CustomPackage> CustomPackages { get; set; } = new List<CustomPackage>();
}
