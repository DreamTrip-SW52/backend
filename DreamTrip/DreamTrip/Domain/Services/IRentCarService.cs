using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Domain.Services;

public interface IRentCarService
{
    Task<IEnumerable<RentCar>> ListAsync();
    Task<RentCarResponse> SaveAsync(RentCar rentCar);
    Task<RentCarResponse> UpdateAsync(int rentCarId, RentCar rentCar);
    Task<RentCarResponse> DeleteAsync(int rentCarId);
}