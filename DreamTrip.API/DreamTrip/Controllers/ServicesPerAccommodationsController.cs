using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ServicesPerAccommodationsController : ControllerBase
{
    private readonly IServicesPerAccommodationService _servicesPerAccommodationService;
    private readonly IMapper _mapper;

    public ServicesPerAccommodationsController(IServicesPerAccommodationService servicesPerAccommodationService, IMapper mapper)
    {
        _servicesPerAccommodationService = servicesPerAccommodationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ServicesPerAccommodationResource>> GetAllAsync()
    {
        var servicesPerAccommodations = await _servicesPerAccommodationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<ServicesPerAccommodation>, IEnumerable<ServicesPerAccommodationResource>>(servicesPerAccommodations);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveServicesPerAccommodationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var servicesPerAccommodation = _mapper.Map<SaveServicesPerAccommodationResource, ServicesPerAccommodation>(resource);

        var result = await _servicesPerAccommodationService.SaveAsync(servicesPerAccommodation);

        if (!result.Success)
            return BadRequest(result.Message);
        var servicesPerAccommodationResource = _mapper.Map<ServicesPerAccommodation, ServicesPerAccommodationResource>(result.Resource);

        return Ok(servicesPerAccommodationResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveServicesPerAccommodationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var servicesPerAccommodation = _mapper.Map<SaveServicesPerAccommodationResource, ServicesPerAccommodation>(resource);

        var result = await _servicesPerAccommodationService.UpdateAsync(id, servicesPerAccommodation);

        if (!result.Success)
            return BadRequest(result.Message);

        var servicesPerAccommodationResource = _mapper.Map<ServicesPerAccommodation, ServicesPerAccommodationResource>(result.Resource);

        return Ok(servicesPerAccommodationResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _servicesPerAccommodationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var servicesPerAccommodationResource = _mapper.Map<ServicesPerAccommodation, ServicesPerAccommodationResource>(result.Resource);

        return Ok(servicesPerAccommodationResource);
    }
}
