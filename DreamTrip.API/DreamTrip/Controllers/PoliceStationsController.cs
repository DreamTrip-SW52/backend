using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PoliceStationController : ControllerBase
{
    private readonly IPoliceStationService _policeStationService;
    private readonly IMapper _mapper;

    public PoliceStationController(IPoliceStationService policeStationService, IMapper mapper)
    {
        _policeStationService = policeStationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PoliceStationResource>> GetAllAsync()
    {
        var policeStations = await _policeStationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<PoliceStation>, IEnumerable<PoliceStationResource>>(policeStations);

        return resources;
    }

    [HttpGet("locationId/{locationId}")]
    public async Task<IEnumerable<PoliceStationResource>> GetByLocationId(int locationId)
    {
        var policeStation = await _policeStationService.FindByLocationIdAsync(locationId);
        var resources = _mapper.Map<IEnumerable<PoliceStation>, IEnumerable<PoliceStationResource>>(policeStation);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePoliceStationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var policeStation = _mapper.Map<SavePoliceStationResource, PoliceStation>(resource);
        
        var result = await _policeStationService.SaveAsync(policeStation);

        if (!result.Success)
            return BadRequest(result.Message);
        var policeStationResource = _mapper.Map<PoliceStation, PoliceStationResource>(result.Resource);

        return Ok(policeStationResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePoliceStationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var policeStation = _mapper.Map<SavePoliceStationResource, PoliceStation>(resource);
        
        var result = await _policeStationService.UpdateAsync(id, policeStation);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var policeStationResource = _mapper.Map<PoliceStation, PoliceStationResource>(result.Resource);
        
        return Ok(policeStationResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _policeStationService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var policeStationResource = _mapper.Map<PoliceStation, PoliceStationResource>(result.Resource);

        return Ok(policeStationResource);
    }
}
