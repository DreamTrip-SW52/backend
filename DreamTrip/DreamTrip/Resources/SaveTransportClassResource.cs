using System.ComponentModel.DataAnnotations;

namespace DreamTrip.DreamTrip.Resources;

public class SaveTransportClassResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}
