using System.Reflection.Metadata.Ecma335;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Domain.Services;

public interface ICustomPackageService
{
    Task<IEnumerable<CustomPackage>> ListAsync();
    Task<CustomPackage> FindByIdAsync(int id);
    Task<CustomPackageResponse> SaveAsync(CustomPackage customPackage);
    Task<CustomPackageResponse> UpdateAsync(int customPackageId, CustomPackage customPackage);
    Task<CustomPackageResponse> DeleteAsync(int customPackageId);
}