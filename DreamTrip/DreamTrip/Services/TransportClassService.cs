using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Repositories;
using DreamTrip.DreamTrip.Domain.Services;
using DreamTrip.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.DreamTrip.Services;

public class TransportClassService : ITransportClassService
{
    private readonly ITransportClassRepository _transportClassRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TransportClassService(ITransportClassRepository transportClassRepository, IUnitOfWork unitOfWork)
    {
        _transportClassRepository = transportClassRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TransportClass>> ListAsync()
    {
        return await _transportClassRepository.ListAsync();
    }

    public async Task<TransportClass> ListByTransportClassIdAsync(int transportClassId)
    {
        return await _transportClassRepository.FindByIdAsync(transportClassId);
    }

    public async Task<TransportClassResponse> SaveAsync(TransportClass transportClass)
    {
        try
        {
            await _transportClassRepository.AddAsync(transportClass);
            await _unitOfWork.CompleteAsync();
            return new TransportClassResponse(transportClass);
        }
        catch (Exception e)
        {
            return new TransportClassResponse($"An error occurred while saving the transportClass: {e.Message}");
        }
    }

    public async Task<TransportClassResponse> UpdateAsync(int transportClassId, TransportClass transportClass)
    {
        var existingTransportClass = await _transportClassRepository.FindByIdAsync(transportClassId);

        if (existingTransportClass == null)
            return new TransportClassResponse("TransportClass not found.");

        existingTransportClass.Name = transportClass.Name;

        try
        {
            _transportClassRepository.Update(existingTransportClass);
            await _unitOfWork.CompleteAsync();

            return new TransportClassResponse(existingTransportClass);
        }
        catch (Exception e)
        {
            return new TransportClassResponse($"An error occurred while updating the transportClass: {e.Message}");
        }
    }

    public async Task<TransportClassResponse> DeleteAsync(int transportClassId)
    {
        var existingTransportClass = await _transportClassRepository.FindByIdAsync(transportClassId);

        if (existingTransportClass == null)
            return new TransportClassResponse("TransportClass not found.");

        try
        {
            _transportClassRepository.Remove(existingTransportClass);
            await _unitOfWork.CompleteAsync();

            return new TransportClassResponse(existingTransportClass);

        }
        catch (Exception e)
        {
            // Error Handling
            return new TransportClassResponse($"An error occurred while deleting the transportClass: {e.Message}");
        }

    }
}