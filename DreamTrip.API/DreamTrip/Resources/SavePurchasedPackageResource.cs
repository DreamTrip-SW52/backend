using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DreamTrip.API.DreamTrip.Resources;

public class SavePurchasedPackageResource
{
    [Required]
    public bool Active { get; set; }

    [Required]
    public int TravelerId { get; set; }

    [AllowNull]
    public int? PackageId { get; set; }
    
    [AllowNull]
    public int? CustomPackageId { get; set; } 
}
