using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Domain.Services;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Services;

public class OneWayService : IOneWayService
{
    private readonly IOneWayRepository _oneWayRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OneWayService(IOneWayRepository oneWayRepository, IUnitOfWork unitOfWork)
    {
        _oneWayRepository = oneWayRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<OneWay>> ListAsync()
    {
        return await _oneWayRepository.ListAsync();
    }

    public async Task<OneWay> ListByOneWayIdAsync(int oneWayId)
    {
        return await _oneWayRepository.FindByIdAsync(oneWayId);
    }

    public async Task<OneWayResponse> SaveAsync(OneWay oneWay)
    {
        try
        {
            await _oneWayRepository.AddAsync(oneWay);
            await _unitOfWork.CompleteAsync();
            return new OneWayResponse(oneWay);
        }
        catch (Exception e)
        {
            return new OneWayResponse($"An error occurred while saving the oneWay: {e.Message}");
        }
    }

    public async Task<OneWayResponse> UpdateAsync(int oneWayId, OneWay oneWay)
    {
        var existingOneWay = await _oneWayRepository.FindByIdAsync(oneWayId);

        if (existingOneWay == null)
            return new OneWayResponse("OneWay not found.");

        existingOneWay.DepartureDate = oneWay.DepartureDate;
				existingOneWay.ReturnDate = oneWay.ReturnDate;
				existingOneWay.Price = oneWay.Price;
				existingOneWay.TripGoId = oneWay.TripGoId;
				existingOneWay.TransportClassId = oneWay.TransportClassId;
				existingOneWay.PackageId = oneWay.PackageId;
				existingOneWay.TransportId = oneWay.TransportId;

        try
        {
            _oneWayRepository.Update(existingOneWay);
            await _unitOfWork.CompleteAsync();

            return new OneWayResponse(existingOneWay);
        }
        catch (Exception e)
        {
            return new OneWayResponse($"An error occurred while updating the oneWay: {e.Message}");
        }
    }

    public async Task<OneWayResponse> DeleteAsync(int oneWayId)
    {
        var existingOneWay = await _oneWayRepository.FindByIdAsync(oneWayId);

        if (existingOneWay == null)
            return new OneWayResponse("OneWay not found.");

        try
        {
            _oneWayRepository.Remove(existingOneWay);
            await _unitOfWork.CompleteAsync();

            return new OneWayResponse(existingOneWay);

        }
        catch (Exception e)
        {
            // Error Handling
            return new OneWayResponse($"An error occurred while deleting the oneWay: {e.Message}");
        }

    }
}