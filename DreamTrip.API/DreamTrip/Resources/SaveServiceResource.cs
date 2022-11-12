using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SaveServiceResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}
