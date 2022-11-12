using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IRoundTripRepository
{
    Task<IEnumerable<RoundTrip>> ListAsync();
    Task AddAsync(RoundTrip roundTrip);
    Task<RoundTrip> FindByIdAsync(int id);
    void Update(RoundTrip roundTrip);
    void Remove(RoundTrip roundTrip);
}