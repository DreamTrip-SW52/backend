using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class RentCarService : IRentCarService
{
    private readonly IRentCarRepository _rentCarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RentCarService(IRentCarRepository rentCarRepository, IUnitOfWork unitOfWork)
    {
        _rentCarRepository = rentCarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RentCar>> ListAsync()
    {
        return await _rentCarRepository.ListAsync();
    }

    public async Task<IEnumerable<RentCar>> FindByFiltersAsync(int locationId, int priceMin, int priceMax,
        int capacityMin, int capacityMax, string brand)
    {
        return await _rentCarRepository.FindByFilters(locationId, priceMin, priceMax, capacityMin,
            capacityMax, brand);
    }

    public async Task<RentCarResponse> SaveAsync(RentCar rentCar)
    {
        try
        {
            await _rentCarRepository.AddAsync(rentCar);
            await _unitOfWork.CompleteAsync();
            return new RentCarResponse(rentCar);
        }
        catch (Exception e)
        {
            return new RentCarResponse($"An error occurred while saving the rentCar: {e.Message}");
        }
    }

    public async Task<RentCarResponse> UpdateAsync(int rentCarId, RentCar rentCar)
    {
        var existingRentCar = await _rentCarRepository.FindByIdAsync(rentCarId);

        if (existingRentCar == null)
            return new RentCarResponse("RentCar not found.");

        existingRentCar.Name = rentCar.Name;
				existingRentCar.Brand = rentCar.Brand;
				existingRentCar.Address = rentCar.Address;
				existingRentCar.Capacity = rentCar.Capacity;
				existingRentCar.Photo = rentCar.Photo;
				existingRentCar.Price = rentCar.Price;
				existingRentCar.PickUpHour = rentCar.PickUpHour;
				existingRentCar.DropOffHour = rentCar.DropOffHour;
				existingRentCar.PackageId = rentCar.PackageId;
        try
        {
            _rentCarRepository.Update(existingRentCar);
            await _unitOfWork.CompleteAsync();

            return new RentCarResponse(existingRentCar);
        }
        catch (Exception e)
        {
            return new RentCarResponse($"An error occurred while updating the rentCar: {e.Message}");
        }
    }

    public async Task<RentCarResponse> DeleteAsync(int rentCarId)
    {
        var existingRentCar = await _rentCarRepository.FindByIdAsync(rentCarId);

        if (existingRentCar == null)
            return new RentCarResponse("RentCar not found.");

        try
        {
            _rentCarRepository.Remove(existingRentCar);
            await _unitOfWork.CompleteAsync();

            return new RentCarResponse(existingRentCar);

        }
        catch (Exception e)
        {
            // Error Handling
            return new RentCarResponse($"An error occurred while deleting the rentCar: {e.Message}");
        }

    }
}