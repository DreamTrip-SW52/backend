using System.ComponentModel.DataAnnotations;

namespace DreamTrip.DreamTrip.Resources;

public class SaveServiceResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}
