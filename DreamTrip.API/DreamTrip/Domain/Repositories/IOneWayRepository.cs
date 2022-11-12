using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IOneWayRepository
{
    Task<IEnumerable<OneWay>> ListAsync();
    Task AddAsync(OneWay oneWay);
    Task<OneWay> FindByIdAsync(int id);
    void Update(OneWay oneWay);
    void Remove(OneWay oneWay);
}