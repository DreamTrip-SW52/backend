﻿namespace DreamTrip.DreamTrip.Domain.Models;

public class Package
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string LocationAddress { get; set; }
    public int Duration { get; set; }
    public int Capacity { get; set; }
    public int Price { get; set; }
    public string Image { get; set; }
    public bool Custom { get; set; }

    // Relationships
    
    // Travel Agency
    public int AgencyId { get; set; }
    public Agency Agency { get; set; }
    // Location
    public int LocationId { get; set; }
    public Location Location { get; set; }

    // Comments
    public List<Review> Reviews { get; set; }
    // Purchased Packages
    public List<PurchasedPackage> PurchasedPackages { get; set; }
}
