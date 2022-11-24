using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;
    private readonly IMapper _mapper;

    public LocationController(ILocationService locationService, IMapper mapper)
    {
        _locationService = locationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<LocationResource>> GetAllAsync()
    {
        var locations = await _locationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Location>, IEnumerable<LocationResource>>(locations);

        return resources;
    }

    [HttpGet("department/{department}")]
    public async Task<LocationResource> GetByDepartment(string department)
    {
        var location = await _locationService.FindByDepartmentAsync(department);
        var resource = _mapper.Map<Location, LocationResource>(location);

        return resource;
    }

    [HttpGet ("{id}")]
    public async Task<LocationResource> GetById(int id)
    {
        var location = await _locationService.FindByIdAsync(id);
        var resource = _mapper.Map<Location, LocationResource>(location);

        return resource;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveLocationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var location = _mapper.Map<SaveLocationResource, Location>(resource);
        
        var result = await _locationService.SaveAsync(location);

        if (!result.Success)
            return BadRequest(result.Message);
        var locationResource = _mapper.Map<Location, LocationResource>(result.Resource);

        return Ok(locationResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLocationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var location = _mapper.Map<SaveLocationResource, Location>(resource);
        
        var result = await _locationService.UpdateAsync(id, location);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var locationResource = _mapper.Map<Location, LocationResource>(result.Resource);
        
        return Ok(locationResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _locationService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var locationResource = _mapper.Map<Location, LocationResource>(result.Resource);

        return Ok(locationResource);
    }
}
