﻿using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface ITripBackRepository
{
    Task<IEnumerable<TripBack>> ListAsync();
    Task AddAsync(TripBack tripBack);
    Task<TripBack> FindByIdAsync(int id);
    void Update(TripBack tripBack);
    void Remove(TripBack tripBack);
}