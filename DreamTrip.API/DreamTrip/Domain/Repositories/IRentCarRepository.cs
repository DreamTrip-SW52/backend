using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IRentCarRepository
{
    Task<IEnumerable<RentCar>> ListAsync();
    Task<RentCar> FindByIdAsync(int id);
    Task<IEnumerable<RentCar>> FindByFilters(int priceMin, int priceMax, int capacityMin,
        int capacityMax, string brand);
    Task AddAsync(RentCar rentCar);
    void Update(RentCar rentCar);
    void Remove(RentCar rentCar);
}