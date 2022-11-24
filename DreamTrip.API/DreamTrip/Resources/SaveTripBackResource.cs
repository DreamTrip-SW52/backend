using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SaveTripBackResource
{
    [Required]
    public int LocationId { get; set; }
}
