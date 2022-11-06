using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface IPoliceStationRepository
{
    Task<IEnumerable<PoliceStation>> ListAsync();
    Task AddAsync(PoliceStation policeStation);
    Task<PoliceStation> FindByIdAsync(int id);
    void Update(PoliceStation policeStation);
    void Remove(PoliceStation policeStation);
}