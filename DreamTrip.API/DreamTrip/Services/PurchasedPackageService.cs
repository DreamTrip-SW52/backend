using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class PurchasedPackageService : IPurchasedPackageService
{
    private readonly IPurchasedPackageRepository _purchasedPackageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PurchasedPackageService(IPurchasedPackageRepository purchasedPackageRepository, IUnitOfWork unitOfWork)
    {
        _purchasedPackageRepository = purchasedPackageRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PurchasedPackage>> ListAsync()
    {
        return await _purchasedPackageRepository.ListAsync();
    }

    public async Task<PurchasedPackage> FindActiveByTravelerIdSync(int travelerId)
    {
        return await _purchasedPackageRepository.FindActiveByTravelerId(travelerId);
    }

    public async Task<PurchasedPackageResponse> SaveAsync(PurchasedPackage purchasedPackage)
    {
        try
        {
            await _purchasedPackageRepository.AddAsync(purchasedPackage);
            await _unitOfWork.CompleteAsync();
            return new PurchasedPackageResponse(purchasedPackage);
        }
        catch (Exception e)
        {
            return new PurchasedPackageResponse($"An error occurred while saving the purchasedPackage: {e.Message}");
        }
    }

    public async Task<PurchasedPackageResponse> UpdateAsync(int purchasedPackageId, PurchasedPackage purchasedPackage)
    {
        var existingPurchasedPackage = await _purchasedPackageRepository.FindByIdAsync(purchasedPackageId);

        if (existingPurchasedPackage == null)
            return new PurchasedPackageResponse("PurchasedPackage not found.");

				existingPurchasedPackage.PackageId = purchasedPackage.PackageId;
				existingPurchasedPackage.Active = purchasedPackage.Active;
				existingPurchasedPackage.TravelerId = purchasedPackage.TravelerId;

        try
        {
            _purchasedPackageRepository.Update(existingPurchasedPackage);
            await _unitOfWork.CompleteAsync();

            return new PurchasedPackageResponse(existingPurchasedPackage);
        }
        catch (Exception e)
        {
            return new PurchasedPackageResponse($"An error occurred while updating the purchasedPackage: {e.Message}");
        }
    }

    public async Task<PurchasedPackageResponse> DeleteAsync(int purchasedPackageId)
    {
        var existingPurchasedPackage = await _purchasedPackageRepository.FindByIdAsync(purchasedPackageId);

        if (existingPurchasedPackage == null)
            return new PurchasedPackageResponse("PurchasedPackage not found.");

        try
        {
            _purchasedPackageRepository.Remove(existingPurchasedPackage);
            await _unitOfWork.CompleteAsync();

            return new PurchasedPackageResponse(existingPurchasedPackage);

        }
        catch (Exception e)
        {
            // Error Handling
            return new PurchasedPackageResponse($"An error occurred while deleting the purchasedPackage: {e.Message}");
        }

    }
}