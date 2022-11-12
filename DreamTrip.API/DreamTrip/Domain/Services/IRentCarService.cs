﻿using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface IRentCarService
{
    Task<IEnumerable<RentCar>> ListAsync();
    Task<RentCarResponse> SaveAsync(RentCar rentCar);
    Task<RentCarResponse> UpdateAsync(int rentCarId, RentCar rentCar);
    Task<RentCarResponse> DeleteAsync(int rentCarId);
}