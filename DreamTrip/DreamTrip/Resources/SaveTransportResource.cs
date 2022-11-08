﻿using System.ComponentModel.DataAnnotations;

namespace DreamTrip.DreamTrip.Resources;

public class SaveTransportResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Type { get; set; }
}
