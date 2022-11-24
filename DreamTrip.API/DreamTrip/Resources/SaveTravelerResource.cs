using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SaveTravelerResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Lastname { get; set; }

    [Required]
    [MaxLength(50)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Password { get; set; }

    [Required]
    [MaxLength(8)]
    public string Dni { get; set; }

    [Required]
    [MaxLength(9)]
    public string Phone { get; set; }

    public string Photo { get; set; }
}