using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SavePurchasedPackageResource
{
    [Required]
    public bool Active { get; set; }

    [Required]
    public int TravelerId { get; set; }

    public int PackageId { get; set; }
    
    public int CustomPackageId { get; set; } 
}
