using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SaveTransportClassResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}
