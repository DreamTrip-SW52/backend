using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface IOneWayRepository
{
    Task<IEnumerable<OneWay>> ListAsync();
    Task AddAsync(OneWay oneWay);
    Task<OneWay> FindByIdAsync(int id);
    void Update(OneWay oneWay);
    void Remove(OneWay oneWay);
}