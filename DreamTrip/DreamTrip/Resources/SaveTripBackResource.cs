using System.ComponentModel.DataAnnotations;

namespace DreamTrip.DreamTrip.Resources;

public class SaveTripBackResource
{
    [Required]
    public int LocationId { get; set; }
}
