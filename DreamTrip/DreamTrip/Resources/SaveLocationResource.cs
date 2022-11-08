using System.ComponentModel.DataAnnotations;

namespace DreamTrip.DreamTrip.Resources;

public class SaveLocationResource
{
    [Required]
    [MaxLength(40)]
    public string Department { get; set; }

    [Required]
    [MaxLength(10)]
    public string Abbr { get; set; }
}
