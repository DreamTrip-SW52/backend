using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class TransportService : ITransportService
{
    private readonly ITransportRepository _transportRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TransportService(ITransportRepository transportRepository, IUnitOfWork unitOfWork)
    {
        _transportRepository = transportRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Transport>> ListAsync()
    {
        return await _transportRepository.ListAsync();
    }

    public async Task<Transport> FindByIdAsync(int transportId)
    {
        return await _transportRepository.FindByIdAsync(transportId);
    }

    public async Task<TransportResponse> SaveAsync(Transport transport)
    {
        try
        {
            await _transportRepository.AddAsync(transport);
            await _unitOfWork.CompleteAsync();
            return new TransportResponse(transport);
        }
        catch (Exception e)
        {
            return new TransportResponse($"An error occurred while saving the transport: {e.Message}");
        }
    }

    public async Task<TransportResponse> UpdateAsync(int transportId, Transport transport)
    {
        var existingTransport = await _transportRepository.FindByIdAsync(transportId);

        if (existingTransport == null)
            return new TransportResponse("Transport not found.");

        existingTransport.Name = transport.Name;
        existingTransport.Type = transport.Type;

        try
        {
            _transportRepository.Update(existingTransport);
            await _unitOfWork.CompleteAsync();

            return new TransportResponse(existingTransport);
        }
        catch (Exception e)
        {
            return new TransportResponse($"An error occurred while updating the transport: {e.Message}");
        }
    }

    public async Task<TransportResponse> DeleteAsync(int transportId)
    {
        var existingTransport = await _transportRepository.FindByIdAsync(transportId);

        if (existingTransport == null)
            return new TransportResponse("Transport not found.");

        try
        {
            _transportRepository.Remove(existingTransport);
            await _unitOfWork.CompleteAsync();

            return new TransportResponse(existingTransport);

        }
        catch (Exception e)
        {
            // Error Handling
            return new TransportResponse($"An error occurred while deleting the transport: {e.Message}");
        }

    }
}