using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
    {
        _serviceRepository = serviceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Service>> ListAsync()
    {
        return await _serviceRepository.ListAsync();
    }

    public async Task<Service> ListByServiceIdAsync(int serviceId)
    {
        return await _serviceRepository.FindByIdAsync(serviceId);
    }

    public async Task<ServiceResponse> SaveAsync(Service service)
    {
        try
        {
            await _serviceRepository.AddAsync(service);
            await _unitOfWork.CompleteAsync();
            return new ServiceResponse(service);
        }
        catch (Exception e)
        {
            return new ServiceResponse($"An error occurred while saving the service: {e.Message}");
        }
    }

    public async Task<ServiceResponse> UpdateAsync(int serviceId, Service service)
    {
        var existingService = await _serviceRepository.FindByIdAsync(serviceId);

        if (existingService == null)
            return new ServiceResponse("Service not found.");

        existingService.Name = service.Name;

        try
        {
            _serviceRepository.Update(existingService);
            await _unitOfWork.CompleteAsync();

            return new ServiceResponse(existingService);
        }
        catch (Exception e)
        {
            return new ServiceResponse($"An error occurred while updating the service: {e.Message}");
        }
    }

    public async Task<ServiceResponse> DeleteAsync(int serviceId)
    {
        var existingService = await _serviceRepository.FindByIdAsync(serviceId);

        if (existingService == null)
            return new ServiceResponse("Service not found.");

        try
        {
            _serviceRepository.Remove(existingService);
            await _unitOfWork.CompleteAsync();

            return new ServiceResponse(existingService);

        }
        catch (Exception e)
        {
            // Error Handling
            return new ServiceResponse($"An error occurred while deleting the service: {e.Message}");
        }

    }
}