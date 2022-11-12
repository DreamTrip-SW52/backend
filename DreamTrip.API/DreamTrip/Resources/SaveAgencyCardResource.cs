using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SaveAgencyCardResource
{
    [Required]
    [MaxLength(50)]
    public string HolderName { get; set; }

    [Required]
    [MaxLength(16)]
    public string CardNumber { get; set; }

    [Required]
    public DateTime ExpirationDate { get; set; }

    [Required]
    public int AgencyId { get; set; }
}
