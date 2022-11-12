using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IRentCarRepository
{
    Task<IEnumerable<RentCar>> ListAsync();
    Task AddAsync(RentCar rentCar);
    Task<RentCar> FindByIdAsync(int id);
    void Update(RentCar rentCar);
    void Remove(RentCar rentCar);
}