using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SavePurchasedPackageResource
{
    [Required]
    public bool Active { get; set; }

    [Required]
    public int TravelerId { get; set; }

    [Required]
    public int PackageId { get; set; }
}
