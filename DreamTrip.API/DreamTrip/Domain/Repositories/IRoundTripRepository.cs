using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IRoundTripRepository
{
    Task<IEnumerable<RoundTrip>> ListAsync();
    Task<RoundTrip> FindByIdAsync(int id);
    Task<RoundTrip> FindByPackageId(int packageId);
    Task AddAsync(RoundTrip roundTrip);
    void Update(RoundTrip roundTrip);
    void Remove(RoundTrip roundTrip);
}